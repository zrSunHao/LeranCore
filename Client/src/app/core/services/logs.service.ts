import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LogData } from '../interfaces/log-data';
import { UtilsService } from './utils.service';
import { tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable()
export class LogsService {
	API_URL: any = environment.api.default;
	API_ENDPOINT: any = '/log/logs';

	constructor(private http: HttpClient, private utils: UtilsService) {}

	getData(params?: any): Observable<any> {
		let url = this.API_URL + this.API_ENDPOINT;
		if (params) {
			url += '?' + this.utils.urlParam(params);
		}
		return this.http
			.get(url)
			.pipe(tap((message: LogData[]) => { }));
	}
}
