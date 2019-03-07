import { Component, OnInit } from '@angular/core';
import { SFSchema } from '@delon/form';
import { NzModalRef, NzNotificationService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-menu-add',
  templateUrl: './menu-add.component.html',
  styles: [],
})
export class MenuAddComponent implements OnInit {
  entity: any = {};
  isEdit = false;
  title = '';

  record: any = {};
  schema: SFSchema = {
    properties: {
      name: { type: 'string', title: '菜单名称', maxLength: 100 },
      url: { type: 'string', title: 'URL', maxLength: 100 },
      tagColor: { type: 'string', title: '标签颜色', maxLength: 100 },
      icon: { type: 'string', title: '图标', maxLength: 100 },
      intro: {
        type: 'string',
        title: '备注',
        maxLength: 200,
        ui: {
          widget: 'textarea',
          grid: { span: 24 },
          autosize: { minRows: 2, maxRows: 6 },
        },
      },
    },
    required: ['name', 'url', 'icon', 'intro', 'tagColor'],
    ui: {
      spanLabelFixed: 100,
      grid: { span: 12 },
    },
  };
  constructor(
    private modal: NzModalRef,
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
    const url = 'permission/create';
    console.log(entity);
    // this.http.post(url, entity).subscribe((res: any) => {
    //   if (!res.success) {
    //     this.notification.create('error', '添加失败', res.allMessages);
    //     return;
    //   }
    //   this.notification.create('success', '添加成功', res.allMessages);
    //   this.modal.close(res);
    // });
  }

  edit(entity: any) {
    const url = 'permission/edit';

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
