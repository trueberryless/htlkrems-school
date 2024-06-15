import { Component, HostBinding, effect, inject, signal } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';

import { AlertComponent } from '../_components/alert/alert.component';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { NgIf, AsyncPipe } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faBars, faMoon, faSun } from '@fortawesome/free-solid-svg-icons';
import { DarkModeService } from '@app/_services';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss'],
  standalone: true,
  imports: [
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    RouterLink,
    RouterLinkActive,
    NgIf,
    MatButtonModule,
    MatIconModule,
    MatSlideToggleModule,
    AlertComponent,
    RouterOutlet,
    AsyncPipe,
    FontAwesomeModule,
  ],
})
export class NavigationComponent {
  isDarkMode: boolean = true;
  menuIcon = faBars;
  darkModeIcon = faMoon;
  lightModeIcon = faSun;

  toggleDarkMode(): void {
    this.darkModeService.toggleDarkMode();
  }

  @HostBinding('class.dark') get modeDark() {
    return this.isDarkMode;
  }

  @HostBinding('class.light') get modeLight() {
    return !this.isDarkMode;
  }

  constructor(private darkModeService: DarkModeService) {
    this.darkModeService.darkMode$.subscribe((darkMode) => {
      this.isDarkMode = darkMode;
    });
  }

  private breakpointObserver = inject(BreakpointObserver);

  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map((result) => result.matches),
      shareReplay()
    );
}
