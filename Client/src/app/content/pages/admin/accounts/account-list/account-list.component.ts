import { AccountListModel } from './../../_core/models/accountListModel';
import { AccountsService } from './../../_core/services/accounts.service';
import { Component, OnInit, ElementRef, ViewChild, ChangeDetectionStrategy } from '@angular/core';
// Material
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, MatSort, MatSnackBar, MatDialog } from '@angular/material';
// RXJS
import { debounceTime, distinctUntilChanged, tap } from 'rxjs/operators';
import { fromEvent, merge, forkJoin } from 'rxjs';
import { TranslateService } from '@ngx-translate/core';
import { PagingOptions } from '../../_core/models/query-params.model';
import { AccountsDataSource } from '../../_core/models/data-sources/accounts.datasource';
import { AccountEditDialogComponent } from '../account-edit-dialog/account-edit-dialog.component';

@Component({
  selector: 'm-account-list',
  templateUrl: './account-list.component.html'
})
export class AccountListComponent implements OnInit {

  displayedColumns = [
    'select', 'email', 'role', 'userName', 'active', 'latestLoginAt',
    'lockoutEndAt', 'accessFailedCount', 'createdAt', 'updatedAt', 'actions'
  ];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  @ViewChild('searchInput') searchInput: ElementRef;
  filterStatus: string = '';
  filterType: string = '';
  hasItems: boolean = false;

  selection = new SelectionModel<AccountListModel>(true, []);
  accountsResult: AccountListModel[] = [];
  loading = true;
  dataSource: AccountsDataSource;
  page: number = 0;

  constructor(
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private accountsService: AccountsService
  ) {
  }

  ngOnInit() {

    this.sort.sortChange.subscribe(() => (this.paginator.pageIndex = 0));


    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        tap(() => {
          this.loadAccountsList();
        })
      )
      .subscribe();


    fromEvent(this.searchInput.nativeElement, 'keyup')
      .pipe(
        debounceTime(150),
        distinctUntilChanged(),
        tap(() => {
          this.paginator.pageIndex = 0;
          this.loadAccountsList();
        })
      )
      .subscribe();

    this.dataSource = new AccountsDataSource(this.accountsService);

    const queryParams = new PagingOptions<AccountListModel>(
      new AccountListModel(),
      this.sort.direction,
      this.sort.active,
      this.paginator.pageIndex,
      this.paginator.pageSize
    );
    this.dataSource.loadAccounts(queryParams);
    this.dataSource.entitySubject.subscribe(res => (this.accountsResult = res));
  }


  loadAccountsList() {
    this.selection.clear();
    const queryParams = new PagingOptions<AccountListModel>(
      new AccountListModel(),
      this.sort.direction,
      this.sort.active,
      this.paginator.pageIndex,
      this.paginator.pageSize
    );
    console.log(this.sort.direction);
    console.log(this.sort.active);
    console.log(this.paginator.pageIndex);
    console.log(this.paginator.pageSize);
    console.log(queryParams);
    this.dataSource.loadAccounts(queryParams);
    this.selection.clear();
  }

  addAccount() {

  }



/** Edit */
editAccount(account: AccountListModel) {

  // const _saveMessage = this.translate.instant(saveMessageTranslateParam);
  // const _messageType = customer.id > 0 ? MessageType.Update : MessageType.Create;
  const dialogRef = this.dialog.open(AccountEditDialogComponent, { data: { account } });
  dialogRef.afterClosed().subscribe(res => {
    if (!res) {
      return;
    }

    // this.layoutUtilsService.showActionNotification(_saveMessage, _messageType, 10000, true, false);
    this.loadAccountsList();
  });
}

  deleteAccount(event: any) {

  }


  /** SELECTION */
	isAllSelected(): boolean {
		const numSelected = this.selection.selected.length;
		const numRows = this.accountsResult.length;
		return numSelected === numRows;
	}

	masterToggle() {
		if (this.selection.selected.length === this.accountsResult.length) {
			this.selection.clear();
		} else {
			this.accountsResult.forEach(row => this.selection.select(row));
		}
	}



  /** UI */
  getItemCssClassByStatus(status: number = 0): string {
    switch (status) {
      case 0:
        return 'metal';
      case 1:
        return 'success';
      case 2:
        return 'danger';
    }
    return '';
  }

  getItemStatusString(status: number = 0): string {
    switch (status) {
      case 0:
        return 'Suspended';
      case 1:
        return 'Active';
      case 2:
        return 'Pending';
    }
    return '';
  }

  getItemCssClassByType(status: number = 0): string {
    switch (status) {
      case 0:
        return 'accent';
      case 1:
        return 'primary';
      case 2:
        return '';
    }
    return '';
  }

  getItemTypeString(status: number = 0): string {
    switch (status) {
      case 0:
        return 'Business';
      case 1:
        return 'Individual';
    }
    return '';
  }

}
