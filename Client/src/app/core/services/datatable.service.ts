import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DataTableItemModel } from '../models/datatable-item.model';
import { CarsDb } from '../../fake-api/fake-db/cars';
import { environment } from '../../../environments/environment';

const API_DATATABLE_URL = environment.api.default + '/car/cars';

@Injectable()
export class DataTableService {

	constructor(private http: HttpClient) {
	}

	getAllItems(): Observable<DataTableItemModel[]> {
		return this.http.get<DataTableItemModel[]>(API_DATATABLE_URL);
	}
}
