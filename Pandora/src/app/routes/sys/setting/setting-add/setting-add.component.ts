import { Component, OnInit } from '@angular/core';
import {
  NzModalRef,
  NzMessageService,
  NzNotificationService,
} from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';
import { SFSchema } from '@delon/form';

const CreateSettingUrl = 'Setting/CreateSetting';
const EditSettingUrl = 'Setting/EditSetting';

@Component({
  selector: 'app-setting-add',
  templateUrl: './setting-add.component.html',
  styles: [],
})
export class SettingAddComponent implements OnInit {
  entity: any = {};
  title = '';
  isEdit = false;

  schema: SFSchema = {
    properties: {
      key: {
        type: 'string',
        title: 'Key',
        readOnly: this.isEdit,
        maxLength: 150,
        ui: { placeholder: 'SettingKey,最长150字' },
      },
      value: {
        type: 'string',
        title: 'Value',
        ui: {
          placeholder: 'SettingValue,最长500字',
          widget: 'textarea',
          grid: { span: 24 },
          autosize: { minRows: 2, maxRows: 6 },
        },
        maxLength: 500,
      },
    },
    required: ['name', 'rank', 'intro'],
    ui: {
      spanLabelFixed: 70,
      grid: { span: 24 },
    },
  };

  constructor(
    private modal: NzModalRef,
    public msgSrv: NzMessageService,
    public http: _HttpClient,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {}

  save(value: any) {
    if (this.isEdit) {
      this.edit(value);
    } else {
      this.add(value);
    }
  }

  add(entity: any) {
    this.http.post(CreateSettingUrl, entity).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '添加失败', res.allMessages);
      } else {
        this.notification.create('success', '添加成功', res.allMessages);
        this.modal.close(res);
      }
    });
  }

  edit(entity: any) {
    this.http.post(EditSettingUrl, entity).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '更新失败', res.allMessages);
      } else {
        this.notification.create('success', '更新成功', res.allMessages);
        this.modal.close(res);
      }
    });
  }

  close() {
    this.modal.destroy();
  }
}
