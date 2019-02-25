
import { Injectable } from '@angular/core';
import { Observable, forkJoin, of, from } from 'rxjs';
import { mergeMap, map, catchError } from 'rxjs/operators';
import { PagingOptions } from '../models/query-params.model';
import { WebApiPagingResult } from '../models/query-results.model';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../../../../../environments/environment';
import { AccountListModel } from '../models/accountListModel';

@Injectable()
export class AccountsService {

    API_URL = environment.api.default;
    API_ACCOUNTS_URL = '/auth/accounts';


    constructor(
        private http: HttpClient,
    ) { }

    public accounts(param: PagingOptions<AccountListModel>): Observable<any> {
        console.log(param);
        return this.http.post<any>(this.API_URL + this.API_ACCOUNTS_URL, param)
            .pipe(
                map(result => {
                    return result;
                }),
                catchError(this.handleError('account', []))
            );

    }
    private handleError<T>(operation = 'operation', result?: any) {
        return (error: any): Observable<any> => {
            return from(result);
        };
    }
}
