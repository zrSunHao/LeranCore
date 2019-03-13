import { Component, OnInit } from '@angular/core';
import { NzModalRef, NzMessageService } from 'ng-zorro-antd';
import { SFSchema } from '@delon/form';
import { _HttpClient } from '@delon/theme';

const CreateRoleUrl = 'Role/CreateRole';
const EditRoleUrl = 'Role/EditRole';

@Component({
  selector: 'app-sys-role-list-role-add',
  templateUrl: './role-add.component.html',
})
export class SysRoleListRoleAddComponent implements OnInit {
  entity: any = {};
  i: any;
  title = '新建角色';

  record: any = {};
  schema: SFSchema = {
    properties: {
      name: { type: 'string', title: '名称', maxLength: 50 },
      code: { type: 'string', title: '编码', maxLength: 50 },
      intro: {
        type: 'string',
        title: '描述',
        ui: {
          widget: 'textarea',
          grid: { span: 24 },
          autosize: { minRows: 2, maxRows: 6 },
        },
      },
    },
    required: ['name', 'code', 'intro'],
    ui: {
      spanLabelFixed: 70,
      grid: { span: 24 },
    },
  };

  constructor(
    private modal: NzModalRef,
    public msgSrv: NzMessageService,
    public http: _HttpClient,
  ) {}

  ngOnInit(): void {
    // this.http.get(`/user/${this.record.id}`).subscribe(res => this.i = res);
  }

  save(value: any) {
    console.log(value);
    this.msgSrv.success('保存成功');
    this.modal.close(value);
  }

  close() {
    this.modal.destroy();
  }
}
