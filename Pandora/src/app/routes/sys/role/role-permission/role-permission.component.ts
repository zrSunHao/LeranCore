import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-role-permission',
  templateUrl: './role-permission.component.html',
  styles: [],
})
export class RolePermissionComponent implements OnInit {
  roleId: any;
  listOfData = [];

  constructor(private route: ActivatedRoute, private http: _HttpClient) {}

  ngOnInit() {
    this.roleId = this.route.snapshot.params[`id`];
    this.loadDatas();
    console.log(this.roleId);
  }

  loadDatas() {
    const url = 'role/getrolepermissions';

    this.http.get(url, { id: this.roleId }).subscribe((res: any) => {
      if (!res.success) {
        return;
      }
      this.listOfData = res.data;
    });
  }

  checkModule(data) {
    const checked = data.checked;
    // console.log(data.checked);
    // tslint:disable-next-line:prefer-for-of
    for (let i = 0; i < this.listOfData.length; i++) {
      // console.log(`${data.id}:${this.listOfData[i].id}`);
      if (this.listOfData[i].id === data.id) {
        // console.log(data.checked);
        this.listOfData[i].checked = !checked;
        // console.log(this.listOfData[i].children.length);
        if (this.listOfData[i].children.length > 0) {
          // tslint:disable-next-line:prefer-for-of
          for (let j = 0; j < this.listOfData[i].children.length; j++) {
            this.listOfData[i].children[j].checked = !checked;
          }
        }
      }
    }
    console.log(this.listOfData);
  }

  checkOperate(data) {
    const checked = data.checked;
    console.log(checked);
    const parentId = data.parentId;

    for (let i = 0; i < this.listOfData.length; i++) {
      // console.log(`${data.id}:${this.listOfData[i].id}`);
      if (this.listOfData[i].id === parentId) {
        let flag = true;
        for (let j = 0; j < this.listOfData[i].children.length; j++) {
          if (this.listOfData[i].children[j].id === data.id) {
            this.listOfData[i].children[j].checked = checked;
          }
          if (this.listOfData[i].children[j].checked === !checked) {
            flag = false;
          }
        }
        if (flag) {
          this.listOfData[i].checked = checked;
        }
      }
    }
    console.log(this.listOfData);
  }
}
