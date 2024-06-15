import { HttpClient } from '@angular/common/http';
import { Component, ViewChild, AfterViewInit } from '@angular/core';

import {
  BehaviorSubject,
  combineLatest,
  merge,
  Observable,
  of as observableOf,
} from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';

import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {
  MatSort,
  MatSortModule,
  SortDirection as AngularSortDirection,
} from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatChipsModule } from '@angular/material/chips';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatListModule } from '@angular/material/list';

import { ColorPicker, FindingService } from '@app/_services';
import {
  AttachmentFinding,
  ClassNameInfo,
  ContainerFinding,
  EquipmentFinding,
  Finding,
  FindingInput,
  FindingResult,
  ModelObject,
  ModelObjectInfo,
  NodeFinding,
  SortDirection,
  SortFinding,
} from '@app/_models';
import { ActivatedRoute, Router } from '@angular/router';
import { filter } from 'lodash';
import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';

@Component({
  selector: 'app-findings',
  standalone: true,
  imports: [
    MatProgressSpinnerModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatChipsModule,
    MatGridListModule,
    MatSelectModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    FormsModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatMenuModule,
    MatButtonModule,
    MatProgressBarModule,
    MatListModule,
  ],
  animations: [
    trigger('detailExpand', [
      state('collapsed,void', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition(
        'expanded <=> collapsed',
        animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')
      ),
    ]),
  ],
  templateUrl: './findings.component.html',
  styleUrl: './findings.component.scss',
})
export class FindingsComponent {
  allDisplayedColumns: string[] = [
    'name',
    'class',
    'type',
    'category',
    'severity',
    'message',
    'expand',
  ];
  displayedColumns: string[] = this.allDisplayedColumns;
  formControlDisplayColumns = new FormControl();
  expandedRow!: Finding | null;

  currentPlaceholder: string | null = null;
  placeholder: string[] = [
    'Node',
    'Container',
    'Equipment',
    'Attachment',
    'ACLine',
    'Station',
    'Transformer',
    'Bay',
    'Equipment has different base voltage \\S+, then the node \\S+ it is connected to.',
    'Overhead Line has wrong r/x ratio. Should be < \\S+ and is \\S+.',
    'CRITICAL',
    'WARNING',
    'semantic',
    'syntax',
    '4a1d0df2-9327-46a5-bd9c-1ad36509da71',
    '8e41dd8f-8602-45a9-9117-ab11be768a6b',
    'a5dfd123-799f-496d-9600-7940f7574211',
  ];

  data: Finding[] = [];

  filterValue: string = '';
  private filterValue$ = new BehaviorSubject<string>('');

  formControlClasses = new FormControl();
  allClasses: ClassNameInfo[] = [];
  currentClasses: ClassNameInfo[] = [];
  private classesFilter$ = new BehaviorSubject<ClassNameInfo[]>([]);

  formControlCategories = new FormControl();
  allCategories: string[] = [];
  currentCategories: string[] = [];
  categoryColors: { [key: string]: string } = {};
  categoryColorPicker: ColorPicker = new ColorPicker();
  private categoryFilter$ = new BehaviorSubject<string[]>([]);

  formControlSeverities = new FormControl();
  allSeverities: string[] = [];
  currentSeverities: string[] = [];
  severityColors: { [key: string]: string } = {};
  severityColorPicker: ColorPicker = new ColorPicker();
  private severityFilter$ = new BehaviorSubject<string[]>([]);

  formControlVoltages = new FormControl();
  allVoltages: number[] = [];
  currentVoltages: number[] = [];
  private voltageFilter$ = new BehaviorSubject<number[]>([]);

  resultsLength = 0;
  isLoadingResults = true;
  noData = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private findingService: FindingService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.findingService.getAllClasses().subscribe((classes) => {
      this.allClasses = classes;
      this.classesFilter$.next(this.allClasses);
      this.currentClasses = this.allClasses;
    });

    this.findingService.getAllCategories().subscribe((categories) => {
      this.allCategories = categories;
      this.categoryFilter$.next(this.allCategories);
      this.allCategories.forEach((category) => {
        this.categoryColors[category] =
          this.categoryColorPicker.getNextColor(category);
      });

      this.currentCategories = this.allCategories;
    });

    this.findingService.getAllSeverities().subscribe((severities) => {
      this.allSeverities = severities;
      this.severityFilter$.next(this.allSeverities);
      this.allSeverities.forEach((severity) => {
        this.severityColors[severity] =
          this.severityColorPicker.getNextColor(severity);
      });

      this.currentSeverities = this.allSeverities;
    });

    this.findingService.getAllVoltages().subscribe((voltages) => {
      this.allVoltages = [-1].concat(voltages);
      this.voltageFilter$.next(this.allVoltages);
      this.currentVoltages = this.allVoltages;
    });

    this.currentPlaceholder = this.getRandomElementFromArray(this.placeholder);
  }

  ngAfterViewInit() {
    // If the user changes the sort order, reset back to the first page.
    this.sort.sortChange.subscribe(() => {
      this.paginator.pageIndex = 0;
    });

    combineLatest([
      this.sort.sortChange.pipe(startWith(null)),
      this.paginator.page.pipe(startWith(null)),
      this.classesFilter$,
      this.filterValue$,
      this.categoryFilter$,
      this.severityFilter$,
      this.voltageFilter$,
    ])
      .pipe(
        switchMap(
          ([
            sortChange,
            page,
            classes,
            filterValue,
            categories,
            severities,
            voltages,
          ]) => {
            this.filterValue = filterValue;

            // console.log(filterValue, categories, severities, sortChange, page);
            this.isLoadingResults = true;
            return this.findingService
              .getFindings({
                limit: this.paginator.pageSize,
                offset: this.paginator.pageIndex * this.paginator.pageSize,
                sorting: this.parseSorting(sortChange?.active ?? ''),
                direction: this.convertSortDirection(
                  sortChange?.direction ?? ''
                ),
                filter: filterValue,
                categories: categories,
                severities: severities,
                classes: classes.map((c) => c.fullName!),
                voltages: voltages,
              })
              .pipe(catchError(() => observableOf(null)));
          }
        )
      )
      .subscribe((data) => {
        if (data instanceof Error) return;
        var dataFinding = data as FindingResult;
        this.data = dataFinding?.findings || [];
        this.resultsLength = dataFinding?.findingCount ?? 0;
        this.noData = dataFinding === null;
        this.isLoadingResults = false;
      });
  }

  parseSorting(sorting: string): SortFinding {
    switch (sorting) {
      case 'category':
        return SortFinding.CATEGORY;
      case 'severity':
        return SortFinding.SEVERITY;
      case 'message':
        return SortFinding.MESSAGE;
      case 'type':
        return SortFinding.TYPE;
      case 'class':
        return SortFinding.CLASS;
      default:
        return SortFinding.GUID;
    }
  }

  convertSortDirection(
    original: AngularSortDirection
  ): SortDirection | undefined {
    switch (original) {
      case 'asc':
        return SortDirection.ASC;
      case 'desc':
        return SortDirection.DESC;
      default:
        return undefined;
    }
  }

  getModelObject(finding: Finding): ModelObjectInfo {
    if (
      (finding as AttachmentFinding).referencedEquipment &&
      (finding as AttachmentFinding).referencedNode
    ) {
      let attachmentFinding = finding as AttachmentFinding;
      return attachmentFinding.referencedEquipment;
    }

    if ((finding as NodeFinding).referencedNode) {
      let nodeFinding = finding as NodeFinding;
      return nodeFinding.referencedNode;
    }

    if ((finding as ContainerFinding).referencedContainer) {
      let containerFinding = finding as ContainerFinding;
      return containerFinding.referencedContainer;
    }

    if ((finding as EquipmentFinding).referencedEquipment) {
      let equipmentFinding = finding as EquipmentFinding;
      return equipmentFinding.referencedEquipment;
    }

    throw new Error('Unknown finding type');
  }

  getRandomElementFromArray(arr: string[]): string | null {
    if (arr.length === 0) {
      return null; // Return null for an empty array
    }

    const randomIndex = Math.floor(Math.random() * arr.length);
    return arr[randomIndex];
  }

  resetFilter() {
    this.paginator.pageIndex = 0;
    this.filterValue$.next('');
    this.classesFilter$.next(this.allClasses);
    this.categoryFilter$.next(this.allCategories);
    this.severityFilter$.next(this.allSeverities);
    this.voltageFilter$.next(this.allVoltages);
    this.sort.active = 'guid';
    this.sort.direction = '';
    this.sort.sortChange.emit();

    this.currentClasses = this.allClasses;
    this.currentCategories = this.allCategories;
    this.currentSeverities = this.allSeverities;
    this.currentVoltages = this.allVoltages;
  }

  clearFilter() {
    this.paginator.pageIndex = 0;
    this.filterValue$.next('');
  }

  applyFilter(event: Event) {
    this.paginator.pageIndex = 0;
    const filterValue = (event.target as HTMLInputElement).value;
    this.filterValue$.next(filterValue);
  }

  applyClasses(event: MatSelectChange) {
    this.paginator.pageIndex = 0;
    const classes = event.value;
    this.classesFilter$.next(classes);
  }

  applyCategories(event: MatSelectChange) {
    this.paginator.pageIndex = 0;
    const categories = event.value;
    this.categoryFilter$.next(categories);
  }

  applySeverities(event: MatSelectChange) {
    this.paginator.pageIndex = 0;
    const severities = event.value;
    this.severityFilter$.next(severities);
  }

  applyVoltages(event: MatSelectChange) {
    this.paginator.pageIndex = 0;
    const voltages = event.value;
    this.voltageFilter$.next(voltages);
  }

  applyDisplayedColumns(event: MatSelectChange) {
    const displayedColumns = event.value;
    this.displayedColumns = displayedColumns;
  }

  showGraph(row: any) {
    const start = this.getModelObject(row).guid;
    this.router.navigate(['/graph'], { queryParams: { start } });
  }
}
