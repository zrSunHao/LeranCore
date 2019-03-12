import { Component, OnInit } from '@angular/core';
import { SFSchema } from '@delon/form';
import { NzModalRef, NzNotificationService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-account-lockout',
  templateUrl: './account-lockout.component.html',
  styles: [],
})
export class AccountLockoutComponent implements OnInit {
  entity: any = {};
  title = '';
  warningMsgTitle = '';
  warningMsg = '';

  schema: SFSchema = {
    properties: {
      lockoutEndAt: {
        type: 'string',
        title: '锁定到期时间',
        format: 'date',
        ui: { grid: { span: 12 } },
      },
    },
    required: ['lockoutEndAt'],
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

  save(value: any) {
    const url = 'auth/lockoutAccount';
    const entity = value;
    console.log(entity);
    this.http.post(url, entity).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '更新失败', res.allMessages);
        return;
      }
      this.notification.create('success', '更新成功', res.allMessages);
      this.modal.close(res);
    });
  }

  close() {
    this.modal.destroy();
  }
}