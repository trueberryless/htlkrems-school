import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

import { Data } from '@app/_models';
import { BackendService } from '@app/_services';

import { MatListModule } from '@angular/material/list';

@Component({
  selector: 'app-log',
  standalone: true,
  imports: [MatListModule],
  templateUrl: './log.component.html',
  styleUrl: './log.component.scss',
})
export class LogComponent {
  logs: Data[] = [];
  timer: any;

  constructor(private backendService: BackendService) {}

  ngOnInit() {
    this.backendService
      .getAll()
      .pipe(first())
      .subscribe((logs) => {
        this.logs = logs.reverse();
      });
    this.timer = setInterval(() => {
      this.update();
    }, 1000);
  }

  ngOnDestroy() {
    clearInterval(this.timer);
  }

  private update() {
    this.backendService
      .getAll()
      .pipe(first())
      .subscribe((logs) => {
        this.logs = logs.reverse();
      });
  }
}
