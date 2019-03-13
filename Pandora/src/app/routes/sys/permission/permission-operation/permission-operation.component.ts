import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { NzNotificationService } from 'ng-zorro-antd';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { PermissionAddComponent } from '../permission-add/permission-add.component';

const GetPermissionUrl = 'Permission/GetPermission';
const ActivePermissionUrl = 'Permission/ActivePermission';
const DeletePermissionUrl = 'Permission/DeletePermission';

@Component({
  selector: 'app-permission-operation',
  templateUrl: './permission-operation.component.html',
  styles: [],
})
export class PermissionOperationComponent implements OnInit {
  initLoading = false; // bug
  loadingMore = false;
  item: any;
  alertMsgShow = false;
  alertMsgTitle = '';
  alertMsgContent = '';

  list = [];

  constructor(
    private http: _HttpClient,
    private modal: ModalHelper,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {}

  public loadData(item: any) {
    this.item = item;

    this.alertMsgShow = true;
    this.alertMsgTitle = `${item.name}`;
    this.alertMsgContent = `注：列表显示内容为[${item.name}]下的操作权限`;

    this.http.get(GetPermissionUrl, { id: item.id }).subscribe((res: any) => {
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
    const title = '添加操作权限';
    const entity = {
      id: item.id,
      name: item.name,
      code: item.code,
      icon: item.icon,
      tagColor: item.tagColor,
      intro: item.intro,
      parentId: item.parentId,
    };

    this.modal
      .createStatic(PermissionAddComponent, { entity, isEdit, title })
      .subscribe(res => {
        this.loadData(this.item);
        console.log(res);
      });
  }

  active(item: any) {
    const active = item.active;
    let msg = '';
    if (active) {
      msg = '关闭';
    } else {
      msg = '开启';
    }

    this.http
      .post(ActivePermissionUrl, { id: item.id, active: !active })
      .subscribe((res: any) => {
        if (!res.success) {
          item.active = active;
          this.notification.create('error', msg + '失败', res.allMessages);
        } else {
          this.notification.create('success', msg + '成功', res.allMessages);
          this.loadData(this.item);
        }
      });
  }

  delete(item: any): void {
    this.http.get(DeletePermissionUrl, { id: item.id }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '删除失败', res.allMessages);
      } else {
        this.notification.create('success', '删除成功', res.allMessages);
        this.loadData(this.item);
      }
    });
  }
}
