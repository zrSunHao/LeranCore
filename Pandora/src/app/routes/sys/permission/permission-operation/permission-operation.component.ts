import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-permission-operation',
  templateUrl: './permission-operation.component.html',
  styles: []
})
export class PermissionOperationComponent implements OnInit {

  initLoading = false; // bug
  loadingMore = false;
  data = [];
  list = [
    {
      name: 111
    },
    {
      name: 111
    },
    {
      name: 111
    },
  ];
  template: TemplateRef<'<nz-switch [ngModel]="true" nzCheckedChildren="开" nzUnCheckedChildren="关"></nz-switch>'>;
  // template = '<nz-switch [ngModel]="true" nzCheckedChildren="开" nzUnCheckedChildren="关"></nz-switch>';

  constructor(private http: HttpClient, private msg: NzMessageService) { }

  ngOnInit() {
  }

  getData(callback: (res: any) => void): void {

  }

  onLoadMore(): void {
    this.loadingMore = true;

  }

  edit(item: any): void {
    this.msg.success(item.email);
  }

  forbid(item: any) {
    this.msg.success(item.email);
  }

  delete(item: any): void {

  }

  public test(event: any) {
    console.log(event);
  }

}
