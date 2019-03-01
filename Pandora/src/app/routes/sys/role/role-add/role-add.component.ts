import { Component, OnInit, Input } from '@angular/core';
import { NzModalRef, NzMessageService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-sys-role-list-role-add',
  templateUrl: './role-add.component.html',
})
export class SysRoleListRoleAddComponent implements OnInit {
  entity: any = {};
  i: any;
  opration = '新建';

  constructor(
    private modal: NzModalRef,
    public msgSrv: NzMessageService,
    public http: _HttpClient
  ) { }

  ngOnInit(): void {
    // this.http.get(`/user/${this.record.id}`).subscribe(res => this.i = res);
    console.log(this.entity);
  }

  close() {
    this.modal.destroy();
  }
}
