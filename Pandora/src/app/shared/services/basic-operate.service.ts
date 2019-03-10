import { Injectable } from '@angular/core';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { NzNotificationService } from 'ng-zorro-antd/notification';

@Injectable({
  providedIn: 'root'
})
export class BasicOperateService {

  constructor(
    private modal: ModalHelper,
    private http: _HttpClient,
    private notification: NzNotificationService,
  ) { }

  loadDataNoneParameter_post(url: string, errMsg: string): any {
    console.log(url);

    this.http.post(url).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', errMsg, res.allMessages);
        return;
      }
      const data = res.data;
      return data;
    });
  }

  loadDataNoneParameter_get(url: string, errMsg: string): any {
    console.log(url);

    this.http.get(url).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', errMsg, res.allMessages);
        return;
      }
      const data = res.data;
      return data;
    });
  }

  loadDataHasParameter_get(dto: any, url: string, errMsg: string): any {
    console.log(dto);
    console.log(url);

    this.http.get(url, dto).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', errMsg, res.allMessages);
        return;
      }
      const data = res.data;
      return data;
    });
  }

  loadDataHasParameter_post(dto: any, url: string, errMsg: string): any {
    console.log(dto);
    console.log(url);

    this.http.post(url, dto).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', errMsg, res.allMessages);
        return;
      }
      const data = res.data;
      return data;
    });
  }

  add(entity: any, url: string): boolean {
    console.log(entity);
    console.log(url);

    let result = false;

    this.http.post(url, entity).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '添加失败', res.allMessages);
        result = false;
      }
      this.notification.create('success', '添加成功', res.allMessages);
      result = true;
    });

    return result;
  }

  edit(entity: any, url: string): boolean {
    console.log(entity);
    console.log(url);

    let result = false;

    this.http.post(url, entity).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '更新失败', res.allMessages);
        result = false;
      }
      this.notification.create('success', '更新成功', res.allMessages);
      result = true;
    });

    return result;
  }

  active(item: any, url: string): boolean {
    console.log(item);
    console.log(url);

    const active = item.active;
    const dto = { id: item.id, active: !active };

    let result = false;
    let msg = '';
    if (active) {
      msg = '关闭';
    } else {
      msg = '开启';
    }

    this.http.post(url, dto).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', msg + '失败', res.allMessages);
        item.active = active;
        result = false;
      }
      this.notification.create('success', msg + '成功', res.allMessages);
      item.active = !active;
      result = true;
    });

    return result;
  }

  delete(item: any, url: string): boolean {
    console.log(item);
    console.log(url);

    let result = false;

    this.http.get(url, { id: item.id }).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '删除失败', res.allMessages);
        result = false;
      }
      this.notification.create('success', '删除成功', res.allMessages);
      result = true;
    });

    return result;
  }


}
