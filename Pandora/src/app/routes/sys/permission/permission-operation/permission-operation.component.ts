import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { PermissionAddComponent } from '../permission-add/permission-add.component';

@Component({
  selector: 'app-permission-operation',
  templateUrl: './permission-operation.component.html',
  styles: []
})
export class PermissionOperationComponent implements OnInit {

  initLoading = false; // bug
  loadingMore = false;
  item: any;

  list = [];

  constructor(private http: _HttpClient, private modal: ModalHelper, private notification: NzNotificationService) { }

  ngOnInit() {
  }

  public loadData(item: any) {
    const url = 'permission/getoperatepermission';
    this.item = item;

    this.http.get(url, { id: item.id })
      .subscribe((res: any) => {
        if (!res.success) {
          console.log(res);
          return;
        }
        this.list = res.data;
      });
  }

  onLoadMore(): void {
    this.loadingMore = true;
  }

  edit(item: any): void {
    const isEdit = true;
    const title = '修改操作权限';
    const entity = {
      id: item.id,
      name: item.name,
      code: item.code,
      icon: item.icon,
      tagColor: item.tagColor,
      intro: item.intro,
      parentId: item.parentId
    };

    this.modal
      .createStatic(PermissionAddComponent, { entity, isEdit, title })
      .subscribe(res => {
        this.loadData(this.item);
        console.log(res);
      });
  }

  active(item: any) {
    const url = 'permission/active';
    const active = item.active;
    let msg = '';
    if (active) {
      msg = '关闭';
    } else {
      msg = '开启';
    }

    this.http.post(url, { id: item.id, active: !active }).subscribe((res: any) => {
      if (!res.success) {
        item.active = active;
        this.notification.create('error', msg + '失败', res.allMessages);
        return;
      }
      this.notification.create('success', msg + '成功', res.allMessages);
      this.loadData(this.item);
    });
  }

  delete(item: any): void {
    const url = 'permission/delete';

    this.http.get(url, { id: item.id }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '删除失败', res.allMessages);
        return;
      }
      this.notification.create('success', '删除成功', res.allMessages);
      this.loadData(this.item);
    });
  }



}
