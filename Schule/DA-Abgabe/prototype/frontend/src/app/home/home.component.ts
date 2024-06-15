import { Component } from '@angular/core';

import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FindingService } from '@app/_services';
import { DoughnutComponent } from '@app/_components/doughnut/doughnut.component';
import { PercentageData } from '@app/_models';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatCardModule, MatProgressSpinnerModule, DoughnutComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  constructor(private findingService: FindingService) {
    this.loadData();
  }

  percentageClass: PercentageData[] = [];
  classNames!: string[];
  classPercentages!: number[];

  percentageCategory: PercentageData[] = [];
  categoryNames!: string[];
  categoryPercentages!: number[];

  percentageSeverity: PercentageData[] = [];
  severityNames!: string[];
  severityPercentages!: number[];

  percentageVoltage: PercentageData[] = [];
  voltageNames!: string[];
  voltagePercentages!: number[];

  loadData() {
    this.findingService.getPercentClass().subscribe((classPercent) => {
      this.percentageClass = classPercent;
      this.classNames = this.percentageClass.map((item) => item.name);
      this.classPercentages = this.percentageClass.map((item) => item.percent);
    });

    this.findingService.getPercentVoltage().subscribe((voltagePercent) => {
      this.percentageVoltage = voltagePercent;
      this.voltageNames = this.percentageVoltage.map((item) => item.name);
      this.voltagePercentages = this.percentageVoltage.map(
        (item) => item.percent
      );
    });

    this.findingService.getPercentCategory().subscribe((categoryPercent) => {
      this.percentageCategory = categoryPercent;
      this.categoryNames = this.percentageCategory.map((item) => item.name);
      this.categoryPercentages = this.percentageCategory.map(
        (item) => item.percent
      );
    });

    this.findingService.getPercentSeverity().subscribe((severityPercent) => {
      this.percentageSeverity = severityPercent;
      this.severityNames = this.percentageSeverity.map((item) => item.name);
      this.severityPercentages = this.percentageSeverity.map(
        (item) => item.percent
      );
    });
  }
}
