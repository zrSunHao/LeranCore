import { async } from '@angular/core/testing';
import { Component, OnInit } from '@angular/core';
import { SFSchema, SFSchemaEnumType, SFDataSchema } from '@delon/form';
import { NzModalRef, NzNotificationService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';
import { Observable, of } from 'rxjs';
import { map, delay } from 'rxjs/operators';

@Component({
  selector: 'app-menu-page-add',
  templateUrl: './menu-page-add.component.html',
  styles: [],
})
export class MenuPageAddComponent implements OnInit {
  entity: any = {};
  isEdit = false;
  title = '';
  items = [];

  schema: SFSchema = {
    properties: {
      name: { type: 'string', title: '页面名称', maxLength: 100 },
      menuName: { type: 'string', title: '菜单', readOnly: true },
      tagColor: { type: 'string', title: '标签颜色', maxLength: 100 },
      url: { type: 'string', title: 'URL', maxLength: 100 },
      moudleId: {
        type: 'string',
        title: '所属模块',
        enum: this.items,
      },
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
    required: ['name', 'url', 'icon', 'intro', 'moudleId', 'tagColor'],
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

  ngOnInit() {
    // this.loadItems1();
    console.log(this.items);
  }

  loadItems() {
    const url = 'permission/getmoduleitems';
    this.http.get(url).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create(
          'error',
          '模块下拉框数据加载失败',
          res.allMessages,
        );
      }
      this.items = res.data;
      console.log(this.items);
    });
  }

  loadItems1(): Observable<any> {
    const url = 'permission/getmoduleitems';

    return this.http.get(url).pipe(
      map((res: any) => {
        console.log(res);
        if (!res.success) {
          this.notification.create(
            'error',
            '模块下拉框数据加载失败',
            res.allMessages,
          );
          return [];
        }

        const items = [
          {
            label: '系统模块',
            group: true,
            children: res.data,
          },
        ];
        return items;
      }),
      null,
    );
  }

  save(value: any) {
    if (this.isEdit) {
      this.edit(value);
    } else {
      this.add(value);
    }
  }

  add(entity: any) {
    const url = 'menu/addpage';
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
    const url = 'menu/editpage';

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
