import { Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { GraphComponent } from './graph/graph.component';
import { FindingsComponent } from './findings/findings.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'graph', component: GraphComponent },
  { path: 'findings', component: FindingsComponent },
];
