import { Component, OnInit } from '@angular/core';
import { SFSchema } from '@delon/form';
import { NzModalRef, NzMessageService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-permission-add',
  templateUrl: './permission-add.component.html',
  styles: [],
})
export class PermissionAddComponent implements OnInit {
  entity: any = {};
  i: any;
  title = '新建角色';

  record: any = {};
  schema: SFSchema = {
    properties: {
      name: { type: 'string', title: '权限名称', maxLength: 100 },
      code: { type: 'string', title: '编码', maxLength: 100 },
      icon: { type: 'string', title: '图标', maxLength: 100 },
      intro: {
        type: 'string',
        title: '备注',
        maxLength: 200,
        ui: {
          widget: 'textarea',
          autosize: { minRows: 2, maxRows: 6 },
        },
      },
    },
    required: ['name', 'code', 'icon', 'intro'],
    ui: {
      spanLabelFixed: 150,
      grid: { span: 24 },
    },
  };

  constructor(
    private modal: NzModalRef,
    public msgSrv: NzMessageService,
    public http: _HttpClient,
  ) {}

  ngOnInit() {}

  save(value: any) {
    console.log(value);
    const url = 'permission/create';
    this.http.post(url, value).subscribe((res: any) => {
      if (!res.success) {
        console.log(res);
        this.msgSrv.error('保存失败');
        return;
      }
      this.msgSrv.success('保存成功');
      this.modal.close(value);
    });
  }

  close() {
    this.modal.destroy();
  }
}
