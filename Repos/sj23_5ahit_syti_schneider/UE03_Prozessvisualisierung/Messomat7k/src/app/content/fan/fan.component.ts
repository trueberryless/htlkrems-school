import { Component } from '@angular/core';

import { Status } from '@app/_models';
import { BackendService } from '@app/_services';

import { MatButtonModule } from '@angular/material/button';
import {
  MatSlideToggleChange,
  MatSlideToggleModule,
} from '@angular/material/slide-toggle';

import { NgClass } from '@angular/common';

@Component({
  selector: 'app-fan',
  standalone: true,
  imports: [MatSlideToggleModule, MatButtonModule, NgClass],
  templateUrl: './fan.component.html',
  styleUrl: './fan.component.scss',
})
export class FanComponent {
  status: Status = new Status();
  loading = true;
  isOn = false;
  fanIsOn = false;
  timer: any;
  currentFanClasses: Record<string, boolean> = {};
  timeoutId: any;

  constructor(private backendService: BackendService) {}

  ngOnInit() {
    this.status.fanOn = 0;
    this.update();
    this.timer = setInterval(() => {
      this.update();
    }, 2000);
  }

  ngOnDestroy() {
    clearInterval(this.timer);
  }

  private update() {
    const oldState = this.status;

    this.backendService.getStatus().then((fan) => {
      this.isOn = true;
      this.status = fan;
      this.fanIsOn = fan.fanOn == 1 ? true : false;
      this.loading = false;

      if (oldState.fanOn != this.status.fanOn) {
        if (this.status.fanOn == 1) {
          this.setFanCurrentClasses('start');
          this.timeoutId = setTimeout(() => {
            this.setFanCurrentClasses('rotating');
          }, 2000);
        } else {
          this.setFanCurrentClasses('stop');
          this.timeoutId = setTimeout(() => {
            this.setFanCurrentClasses('still');
          }, 2000);
        }
      }
    });
  }

  setFanCurrentClasses(current: string = 'still') {
    // CSS classes: added/removed per current state of component properties
    this.currentFanClasses = {
      fan: true,
      still: current == 'still',
      start: current == 'start',
      rotating: current == 'rotating',
      stop: current == 'stop',
    };
  }

  public setFan(event: MatSlideToggleChange) {
    const on = event.checked ? 1 : 0;
    this.backendService.setFan(on);
    clearTimeout(this.timeoutId);
  }

  public setOnOff(event: MatSlideToggleChange) {
    const on = event.checked;
    this.isOn = on;
    if (on) {
      this.backendService.setOn();
      this.timer = setInterval(() => {
        this.update();
      }, 2000);
    } else {
      clearInterval(this.timer);
      this.backendService.setOff();
    }

    if (this.fanIsOn) {
      this.fanIsOn = false;
      this.setFanCurrentClasses('stop');
      this.timeoutId = setTimeout(() => {
        this.setFanCurrentClasses('still');
      }, 2000);
    }
  }
}
