import { Injectable } from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { catchError, map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SysService {

  constructor(
    public http: _HttpClient,
  ) { }

  getRoles(): Observable<any> {
    const url = '';
    return this.http.post(url, { name: '管理员' })
    .pipe(map(response:any)=>{
      
    })
  }

}
