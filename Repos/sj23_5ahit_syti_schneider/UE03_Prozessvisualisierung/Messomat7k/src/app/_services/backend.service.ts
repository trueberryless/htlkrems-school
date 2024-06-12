import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, firstValueFrom } from 'rxjs';
import { Data, Status } from '@app/_models';

import { environment } from '@environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BackendService {
  apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Data[]> {
    return this.http.get<Data[]>(`${this.apiUrl}/all`);
  }

  getStatus() {
    return firstValueFrom(this.http.get<Status>(`${this.apiUrl}/status`));
  }

  setFan(on: number) {
    console.log('Request: ' + `${this.apiUrl}/set-fan?on=${on}`);
    return this.http.post(`${this.apiUrl}/set-fan?on=${on}`, null).subscribe({
      error: (error) => {
        console.error('There was an error!', error);
      },
    });
  }

  setSendMode(mode: string) {
    this.http
      .post(`${this.apiUrl}/set-send-mode?mode=${mode}`, null)
      .subscribe({
        error: (error) => {
          console.error('There was an error!', error);
        },
      });
  }

  setOn() {
    this.http.post(`${this.apiUrl}/set-on`, null).subscribe({
      error: (error) => {
        console.error('There was an error!', error);
      },
    });
  }

  setOff() {
    this.http.post(`${this.apiUrl}/set-off`, null).subscribe({
      error: (error) => {
        console.error('There was an error!', error);
      },
    });
  }
}
