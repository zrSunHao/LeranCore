import { Component, OnInit } from '@angular/core';
import { NzModalRef, NzNotificationService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';
import { SFSchema } from '@delon/form';

@Component({
  selector: 'app-account-add',
  templateUrl: './account-add.component.html',
  styles: []
})
export class AccountAddComponent implements OnInit {

  entity: any = {};
  isEdit = false;
  title = '';

  schema: SFSchema = {
    properties: {
      userName: { type: 'string', title: '用户名', maxLength: 50 },
      email: { type: 'string', title: '邮箱', maxLength: 100 },
      roleId: {
        type: 'string',
        title: '角色',
        enum: JSON.parse(localStorage.getItem('roleItems')),
      },
    },
    required: ['name', 'email', 'roleId'],
    ui: {
      spanLabelFixed: 100,
      grid: { span: 12 },
    },
  };
  constructor(
    private modal: NzModalRef,
    public http: _HttpClient,
    private notification: NzNotificationService,
  ) { }

  ngOnInit() { }

  save(value: any) {
    if (this.isEdit) {
      this.edit(value);
    } else {
      this.add(value);
    }
  }

  add(entity: any) {
    const url = 'auth/addAccount';
    console.log(entity);
    this.http.post(url, entity).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '添加失败', res.allMessages);
        return;
      }
      this.notification.create('success', '添加成功', res.allMessages);
      this.modal.close(res);
    });
  }

  edit(entity: any) {
    const url = 'auth/editAccount';

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
