import { Component, OnInit } from '@angular/core';
import { SFSchema } from '@delon/form';
import { NzModalRef, NzNotificationService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';

const activeItem = [
  { label: '请选择', value: 2 },
  { label: '开启', value: 1 },
  { label: '禁用', value: 0 },
];

@Component({
  selector: 'app-account-lockout',
  templateUrl: './account-lockout.component.html',
  styles: [],
})
export class AccountLockoutComponent implements OnInit {
  entity: any = {};
  title = '';
  warningMsg = '';

  schema: SFSchema = {
    properties: {
      lockoutEndAt: {
        type: 'string',
        title: '锁定到期时间',
        format: 'date',
        ui: { grid: { span: 12 } },
      },
      active: {
        type: 'string',
        title: '启用或禁用',
        enum: activeItem,
        default: 2,
        ui: { widget: 'select', grid: { span: 12 } },
      },
    },
    required: [],
    ui: {
      span: 24,
      spanLabelFixed: 130,
    },
  };

  constructor(
    private modal: NzModalRef,
    public http: _HttpClient,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {}

  save(value: any) {}

  close() {
    this.modal.destroy();
  }
}
