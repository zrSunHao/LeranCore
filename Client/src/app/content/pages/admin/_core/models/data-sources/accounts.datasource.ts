import { Observable, of } from 'rxjs';
import { catchError, finalize, tap } from 'rxjs/operators';

import { BaseDataSource } from './_base.datasource';
import { AccountsService } from '../../services/accounts.service';
import { AccountListModel } from '../accountListModel';
import { PagingOptions } from '../query-params.model';
import { WebApiPagingResult } from '../query-results.model';


export class AccountsDataSource extends BaseDataSource {
	constructor(private accountsService: AccountsService) {
		super();
	}

	loadAccounts(
		queryParams: PagingOptions<AccountListModel>
	) {
		console.log(queryParams);
		this.loadingSubject.next(true);
		this.accountsService.accounts(queryParams).pipe(
			tap(res => {
				this.entitySubject.next(res.data);
				this.paginatorTotalSubject.next(res.rowsCount);
			}),
			catchError(err => of(new WebApiPagingResult<AccountListModel>())),
			finalize(() => this.loadingSubject.next(false))
		).subscribe();
	}
}
