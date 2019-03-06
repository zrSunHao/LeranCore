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
  listOfData = [
    {
      key: '1',
      name: 'John Brown',
      ckecked: true,
      children: [
        {
          key: '2',
          name: 'Jim Green',
          ckecked: true,
          address: 'London No. 1 Lake Park',
        },
        {
          key: '3',
          name: 'Joe Black',
          ckecked: true,
          address: 'Sidney No. 1 Lake Park',
        },
      ],
    },
  ];

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
    console.log(data);
    const ddd = this.listOfData[0];
    ddd.ckecked = true;
  }

  checkOperate(data) {
    console.log(data);
  }
}
