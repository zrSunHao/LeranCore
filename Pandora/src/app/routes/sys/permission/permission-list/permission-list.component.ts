import { Component, OnInit, ViewChild } from '@angular/core';
import { SFSchema } from '@delon/form';
import { STComponent, STColumn } from '@delon/abc';

@Component({
  selector: 'app-permission-list',
  templateUrl: './permission-list.component.html',
  styles: [],
})
export class PermissionListComponent implements OnInit {
  listOfData = [
    {
      key: '1',
      name: 32,
      ckecked: false,
      children: [
        {
          key: '12',
          name: 12,
          ckecked: false,
        },
        {
          key: '13',
          name: 325,
          ckecked: false,
        },
        {
          key: '14',
          name: 326,
          ckecked: false,
        },
      ],
    },
    {
      key: '2',
      name: 42,
      ckecked: false,
      children: [
        {
          key: '62',
          name: 12,
          ckecked: false,
        },
        {
          key: '63',
          name: 325,
          ckecked: false,
        },
        {
          key: '64',
          name: 326,
          ckecked: false,
        },
      ],
    },
    {
      key: '3',
      name: 32,
      ckecked: false,
      children: [
        {
          key: '22',
          name: 12,
          ckecked: false,
        },
        {
          key: '23',
          name: 325,
          ckecked: false,
        },
        {
          key: '34',
          name: 326,
          ckecked: false,
        },
      ],
    },
  ];

  datas: Array<any> = [];
  searchSchema: SFSchema = {
    properties: {
      name: {
        type: 'string',
        title: '模块名称',
      },
    },
  };

  @ViewChild('st') st: STComponent;
  columns: STColumn[] = [
    { title: '模块名称', index: 'name' },
    { title: '备注', index: 'intro' },
    {
      title: '操作',
      buttons: [
        {
          text: '编辑',
          click: (item: any) => this.edit(),
        },
        {
          text: '权限',
          click: (item: any) => this.forbid(item),
        },
      ],
    },
  ];

  constructor() {}

  ngOnInit() {}

  hhhhhh(data) {
    console.log(data);
    const ddd = this.listOfData[0];
    ddd.ckecked = true;
  }

  hhhhhh1(data) {
    data.children[0].ckecked = data.ckecked;
    data.children[1].ckecked = data.ckecked;
    data.children[2].ckecked = data.ckecked;
    const yyyyyy = data.children as [];
    for (let i = 0; i < yyyyyy.length; i++) {
      data.children[i].ckecked = data.ckecked;
    }
    const yyy = {
      key: '1787',
      name: 353535,
      ckecked: false,
    };
    data.children.push(yyy);
  }

  add() {}

  edit() {}

  delete() {}

  loadDatas() {}

  forbid(item: any) {}
}
