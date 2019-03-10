import { Injectable } from '@angular/core';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { Observable, from } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BasicOperateService {

  constructor(
    private modal: ModalHelper,
    private http: _HttpClient,
  ) { }

  loadDataNoneParameter_post(url: string): Observable<any> {
    return this.http.post<any>(url)
      .pipe(
        map(res => {
          return res;
        }),
        catchError(this.handleError('loadData', []))
      );
  }

  loadDataNoneParameter_get(url: string): Observable<any> {
    return this.http.get<any>(url)
      .pipe(
        map(res => {
          return res;
        }),
        catchError(this.handleError('loadData', []))
      );
  }

  loadDataHasParameter_get(dto: any, url: string): Observable<any> {
    return this.http.get<any>(url, dto)
      .pipe(
        map(res => {
          return res;
        }),
        catchError(this.handleError('loadData', []))
      );
  }

  loadDataHasParameter_post(dto: any, url: string): Observable<any> {
    return this.http.post<any>(url, dto)
      .pipe(
        map(res => {
          return res;
        }),
        catchError(this.handleError('loadData', []))
      );
  }

  add(dto: any, url: string): Observable<any> {
    return this.http.post<any>(url, dto)
      .pipe(
        map(res => {
          return res;
        }),
        catchError(this.handleError('add', []))
      );
  }

  edit(dto: any, url: string): Observable<any> {
    return this.http.post<any>(url, dto)
      .pipe(
        map(res => {
          return res;
        }),
        catchError(this.handleError('edit', []))
      );
  }

  active(item: any, url: string): Observable<any> {
    const active = item.active;
    const dto = { id: item.id, active: !active };
    return this.http.post<any>(url, dto)
      .pipe(
        map(res => {
          return res;
        }),
        catchError(this.handleError('active', []))
      );
  }

  delete(item: any, url: string): Observable<any> {
    const dto = { id: item.id };
    return this.http.post<any>(url, dto)
      .pipe(
        map(res => {
          return res;
        }),
        catchError(this.handleError('delete', []))
      );
  }

  private handleError<T>(operation = 'operation', result?: any) {
    return (error: any): Observable<any> => {
      return from(result);
    };
  }

}
