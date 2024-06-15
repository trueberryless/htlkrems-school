import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DarkModeService {
  private darkModeSubject = new BehaviorSubject<boolean>(
    JSON.parse(localStorage.getItem('darkMode') ?? 'true')
  );
  darkMode$: Observable<boolean> = this.darkModeSubject.asObservable();

  toggleDarkMode(): void {
    const currentMode = this.darkModeSubject.value;
    const newMode = !currentMode;
    this.darkModeSubject.next(newMode);
    localStorage.setItem('darkMode', JSON.stringify(newMode));
  }
}
