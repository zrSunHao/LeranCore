import { Component, OnInit } from '@angular/core';
import { SFSchema } from '@delon/form';
import { NzModalRef, NzNotificationService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';

const BatchEditAccountUrl = 'Auth/BatchEditAccount';
const activeItem = [
  { label: '请选择', value: 2 },
  { label: '开启', value: 1 },
  { label: '禁用', value: 0 },
];

@Component({
  selector: 'app-account-status',
  templateUrl: './account-status.component.html',
  styles: [],
})
export class AccountStatusComponent implements OnInit {
  entity: any = {};
  title = '';
  warningMsg = '';

  schema: SFSchema = {
    properties: {
      lockoutEndAt: { type: 'string', title: '锁定到期时间', format: 'date', ui: { grid: { span: 12 } } },
      active: {
        type: 'string', title: '启用或禁用', enum: activeItem, default: 2,
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
  ) { }

  ngOnInit() { }

  save(value: any) {
    if (
      value.lockoutEndAt == null &&
      (value.active == null || value.active === 2)
    ) {
      this.notification.create('error', '账号状态批量更新失败', '请输入要更改的状态');
    } else {
      let realActive = null;
      if (value.active === 1) {
        realActive = true;
      }
      if (value.active === 0) {
        realActive = false;
      }
      const entity = {
        ids: value.ids,
        active: realActive,
        lockoutEndAt: value.lockoutEndAt
      };

      this.http.post(BatchEditAccountUrl, entity).subscribe((res: any) => {
        if (!res.success) {
          this.notification.create('error', '账号状态批量更新失败', res.allMessages);
        } else {
          this.notification.create('success', '账号状态批量更新成功', res.allMessages);
          this.modal.close(res);
        }
      });
    }
  }

  close() {
    this.modal.destroy();
  }
}
