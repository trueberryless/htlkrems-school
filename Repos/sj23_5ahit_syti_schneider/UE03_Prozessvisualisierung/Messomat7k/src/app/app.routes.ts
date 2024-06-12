import { Routes } from '@angular/router';

import { DataComponent } from './content/data/data.component';
import { FanComponent } from './content/fan/fan.component';
import { LogComponent } from './content/log/log.component';

export const routes: Routes = [
  { path: 'data', component: DataComponent },
  { path: 'fan', component: FanComponent },
  { path: 'log', component: LogComponent },
  { path: '**', redirectTo: 'data' },
];
