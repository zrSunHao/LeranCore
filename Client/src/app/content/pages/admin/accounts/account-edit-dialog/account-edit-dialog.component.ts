import { AccountsService } from './../../_core/services/accounts.service';
import { Component, OnInit, Inject, ChangeDetectionStrategy } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TypesUtilsService } from '../../_core/utils/types-utils.service';
import { AccountListModel } from '../../_core/models/accountListModel';

@Component({
  selector: 'm-account-edit-dialog',
  templateUrl: './account-edit-dialog.component.html'
})
export class AccountEditDialogComponent implements OnInit {

  account: AccountListModel;
  accountForm: FormGroup;
  hasFormErrors: boolean = false;
  viewLoading: boolean = false;
  loadingAfterSubmit: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<AccountEditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private accountsService: AccountsService,
    private typesUtilsService: TypesUtilsService) { }

  ngOnInit() {
    this.account = this.data.account;
    this.createForm();
  }
  // displayedColumns = [
  //   'select', 'email', 'role', 'userName', 'active', 'latestLoginAt',
  //   'lockoutEndAt', 'accessFailedCount', 'createdAt', 'updatedAt', 'actions'
  // ];

  createForm() {
    this.accountForm = this.fb.group({
      email: [
        this.account.email,
        [Validators.required, Validators.email]
      ],
      role: [this.account.role],
      userName: [this.account.userName, Validators.nullValidator],
      active: [this.account.active, Validators.required],
      latestLoginAt: [this.account.latestLoginAt, Validators.required],
      lockoutEndAt: [this.account.lockoutEndAt],
      accessFailedCount: [this.account.accessFailedCount, Validators.required],
      createdAt: [this.account.createdAt, Validators.required],
      updatedAt: [this.account.updatedAt]
    });
  }

  /** ACTIONS */
  prepareAccount(): AccountListModel {
    const controls = this.accountForm.controls;
    const _account = new AccountListModel();
    _account.id = this.account.id;
    const _latestLoginAt = controls['latestLoginAt'].value;
    if (_latestLoginAt) {
      _account.latestLoginAt = this.typesUtilsService.dateFormat(_latestLoginAt);
    } else {
      _account.latestLoginAt = '';
    }
    console.log('_account', _account);
    _account.email = controls['email'].value;
    _account.role = controls['role'].value;
    _account.userName = controls['userName'].value;
    _account.active = controls['active'].value;
    _account.lockoutEndAt = controls['lockoutEndAt'].value;
    _account.accessFailedCount = controls['accessFailedCount'].value;
    _account.createdAt = controls['createdAt'].value;
    _account.updatedAt = controls['updatedAt'].value;
    return _account;
  }

  // 提交
  onSubmit() {
  //   this.hasFormErrors = false;
  //   this.loadingAfterSubmit = false;
  //   const controls = this.customerForm.controls;
  //   /** check form */
  //   if (this.customerForm.invalid) {
  //     Object.keys(controls).forEach(controlName =>
  //       controls[controlName].markAsTouched()
  //     );

  //     this.hasFormErrors = true;
  //     return;
  //   }

  //   const editedCustomer = this.prepareCustomer();
  //   if (editedCustomer.id > 0) {
  //     this.updateCustomer(editedCustomer);
  //   } else {
  //     this.createCustomer(editedCustomer);
  //   }
  }

  // 更新
  updateCustomer(_account: AccountListModel) {
    // this.loadingAfterSubmit = true;
    // this.viewLoading = true;
    // this.customerService.updateCustomer(_customer).subscribe(res => {
    //   /* Server loading imitation. Remove this on real code */
    //   this.viewLoading = false;
    //   this.viewLoading = false;
    //   this.dialogRef.close({
    //     _customer,
    //     isEdit: true
    //   });
    // });
  }

  // 新建
  createCustomer(_account: AccountListModel) {
    // this.loadingAfterSubmit = true;
    // this.viewLoading = true;
    // this.customerService.createCustomer(_account).subscribe(res => {
    //   this.viewLoading = false;
    //   this.dialogRef.close({
    //     _customer,
    //     isEdit: false
    //   });
    // });
  }

  // 关闭错误提示
  onAlertClose($event) {
    this.hasFormErrors = false;
  }

  /** UI */
  getTitle(): string {
    if (this.account.id) {
      return `Edit customer '${this.account.userName} ${
        this.account.email
        }'`;
    }

    return 'New customer';
  }

  isControlInvalid(controlName: string): boolean {
    const control = this.accountForm.controls[controlName];
    const result = control.invalid && control.touched;
    return result;
  }

}
