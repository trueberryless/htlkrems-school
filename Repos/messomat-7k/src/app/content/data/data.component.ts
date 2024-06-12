import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

import { Data, Status } from '@app/_models';
import { BackendService } from '@app/_services';

import { NgxChartsModule } from '@swimlane/ngx-charts';
import { MatTabsModule } from '@angular/material/tabs';
import { MatGridListModule } from '@angular/material/grid-list';

import {
  MatSlideToggleChange,
  MatSlideToggleModule,
} from '@angular/material/slide-toggle';

interface LineChartData {
  name: string;
  series: { name?: string; value?: number }[];
}

interface BarChartData {
  name: string;
  value?: number;
}

@Component({
  selector: 'app-data',
  standalone: true,
  imports: [
    MatSlideToggleModule,
    NgxChartsModule,
    MatGridListModule,
    MatTabsModule,
  ],
  templateUrl: './data.component.html',
  styleUrl: './data.component.scss',
})
export class DataComponent {
  data: Data[] = [];
  lineChartData: LineChartData[] = [];
  barChartData: BarChartData[] = [];
  status: Status = new Status();
  sendMode = false;
  isOn = false;
  timer: any;

  tempLineChartData: LineChartData[] = [];
  humiLineChartData: LineChartData[] = [];

  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA'],
  };

  constructor(private backendService: BackendService) {}

  ngOnInit() {
    this.backendService
      .getAll()
      .pipe(first())
      .subscribe((data) => {
        this.data = data;
        this.lineChartData = this.getLineChartData(this.data);
        this.tempLineChartData = this.lineChartData.filter(
          (data) => data.name === 'Temperature'
        );
        this.humiLineChartData = this.lineChartData.filter(
          (data) => data.name === 'Humidity'
        );
        console.log(this.lineChartData);
        this.barChartData = this.getBarChartData(this.data);
      });

    this.backendService.getStatus().then((status) => {
      this.status = status;
      this.sendMode = status.sendMode == 'fast' ? true : false;
      this.isOn = true;
    });

    this.timer = setInterval(() => {
      this.update();
    }, 1000);
  }

  ngOnDestroy() {
    clearInterval(this.timer);
  }

  update() {
    this.backendService
      .getAll()
      .pipe(first())
      .subscribe((data) => {
        this.data = data;
        this.lineChartData = this.getLineChartData(this.data);
        this.tempLineChartData = this.lineChartData.filter(
          (data) => data.name === 'Temperature'
        );
        this.humiLineChartData = this.lineChartData.filter(
          (data) => data.name === 'Humidity'
        );
        this.barChartData = this.getBarChartData(this.data);
      });
  }

  getLineChartData(data: Data[]): LineChartData[] {
    const result: LineChartData[] = [];

    // Extrahiere ein eindeutiges Array von Zeitstempeln
    const timestamps = Array.from(new Set(data.map((item) => item.timestamp)));

    // Erstelle für jede Eigenschaft (Temperature, Humidity usw.) ein transformiertes Objekt
    Object.keys(data[0]).forEach((property) => {
      if (property !== 'timestamp') {
        const transformedProperty: LineChartData = {
          name: property.charAt(0).toUpperCase() + property.slice(1),
          series: [],
        };

        timestamps.forEach((timestamp) => {
          const matchingData = data.find(
            (item: Data) => item.timestamp === timestamp
          );

          if (matchingData) {
            transformedProperty.series.push({
              name: String(new Date(timestamp!).getSeconds()),
              value: Number(matchingData[property as keyof Data]),
            });
          } else {
            // Behandle den Fall, wenn Daten für einen Zeitstempel fehlen
            transformedProperty.series.push({
              name: String(new Date(timestamp!).getSeconds()),
              value: undefined,
            });
          }
        });

        result.push(transformedProperty);
      }
    });

    return result;
  }

  getBarChartData(data: Data[]): BarChartData[] {
    const result: BarChartData[] = [];

    // Erstelle für jede Eigenschaft (Temperature, Humidity usw.) ein transformiertes Objekt
    Object.keys(data[data.length - 1]).forEach((property) => {
      if (property !== 'timestamp') {
        const transformedProperty: BarChartData = {
          name: property.charAt(0).toUpperCase() + property.slice(1),
          value: Number(data[data.length - 1][property as keyof Data]),
        };

        result.push(transformedProperty);
      }
    });

    return result;
  }

  public setSendMode(event: MatSlideToggleChange) {
    const sendMode = event.checked ? 'fast' : 'slow';
    this.backendService.setSendMode(sendMode);

    if (sendMode === 'fast') {
      clearInterval(this.timer);

      this.timer = setInterval(() => {
        this.update();
      }, 1000);
    } else {
      clearInterval(this.timer);

      this.timer = setInterval(() => {
        this.update();
      }, 4000);
    }
  }

  public setOnOff(event: MatSlideToggleChange) {
    const on = event.checked;
    this.isOn = on;
    if (on) {
      this.backendService.setOn();
    } else {
      this.backendService.setOff();
    }
  }

  onSelect(data: any): void {
    console.log('Item clicked', JSON.parse(JSON.stringify(data)));
  }

  onActivate(data: any): void {
    clearInterval(this.timer);
  }

  onDeactivate(data: any): void {
    this.timer = setInterval(() => {
      this.update();
    }, 1000);
  }
}
