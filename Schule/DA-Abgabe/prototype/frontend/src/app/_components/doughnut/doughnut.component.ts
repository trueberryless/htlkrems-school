import {
  ChangeDetectionStrategy,
  Component,
  Input,
  ViewChild,
} from '@angular/core';
import { DarkModeService } from '@app/_services';
import { ChartConfiguration, ChartData, ChartEvent, ChartType } from 'chart.js';
import { NgChartsModule } from 'ng2-charts';

@Component({
  selector: 'app-doughnut',
  standalone: true,
  imports: [NgChartsModule],
  templateUrl: './doughnut.component.html',
  styleUrl: './doughnut.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DoughnutComponent {
  @Input() public labels!: string[];
  @Input() public data!: number[];
  public doughnutChartData!: ChartData<'doughnut'>;
  public doughnutChartOptions: ChartConfiguration<'doughnut'>['options'] = {};

  constructor(private darkModeService: DarkModeService) {}

  ngAfterContentInit() {
    this.darkModeService.darkMode$.subscribe((darkMode) => {
      console.log(darkMode);
      if (darkMode) {
        this.doughnutChartOptions = {
          responsive: true,
          color: '#ddd',
          plugins: {
            legend: {
              position: 'bottom',
              title: {
                display: true,
                padding: 10,
              },
            },
          },
          maintainAspectRatio: false,
        };
      } else {
        this.doughnutChartOptions = {
          responsive: true,
          color: '#333',
          plugins: {
            legend: {
              position: 'bottom',
              title: {
                display: true,
                padding: 10,
              },
            },
          },
          maintainAspectRatio: false,
        };
      }
    });
  }

  ngOnChanges() {
    this.doughnutChartData = {
      labels: this.labels,
      datasets: [
        {
          data: this.data,

          backgroundColor: [
            'rgb(54, 162, 235)',
            'rgb(255, 205, 86)',
            'rgb(54, 230, 123)',
            'rgb(255, 99, 132)',
          ],
        },
      ],
    };
  }

  // events
  public chartClicked({
    event,
    active,
  }: {
    event: ChartEvent;
    active: object[];
  }): void {
    console.log(event, active);
  }

  public chartHovered({
    event,
    active,
  }: {
    event: ChartEvent;
    active: object[];
  }): void {
    console.log(event, active);
  }
}
