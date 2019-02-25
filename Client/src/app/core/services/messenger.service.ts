import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { MessageData } from '../interfaces/message-data';
import { environment } from '../../../environments/environment';

@Injectable()
export class MessengerService {
	API_URL: any = environment.api.default;
	API_ENDPOINT: any = '/message/messages';

	constructor(private http: HttpClient) {}

	public getData(): Observable<any> {
		return this.http
			.get(this.API_URL + this.API_ENDPOINT);
	}
}
