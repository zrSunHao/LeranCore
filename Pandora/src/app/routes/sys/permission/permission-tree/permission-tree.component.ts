import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { NzFormatEmitEvent, NzTreeNode, NzTreeBaseService, NzDropdownContextComponent, NzDropdownService } from 'ng-zorro-antd';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { PermissionEditDto } from '../../_model/permissions/permission-edit.dto';
import { PermissionAddComponent } from '../permission-add/permission-add.component';

@Component({
  selector: 'app-permission-tree',
  templateUrl: './permission-tree.component.html',
  styles: []
})
export class PermissionTreeComponent implements OnInit {

  nodes = [];

  isCheckedButton: any;

  node1s = [{
    title: 'parent 1',
    key: '100',
    icon: 'anticon anticon-meh-o',
    expanded: true,
    children: [{
      title: 'parent 1-0',
      key: '1001',
      icon: 'anticon anticon-meh-o',
      expanded: true,
      children: [
        { title: 'leaf', key: '10010', icon: 'anticon anticon-meh-o', isLeaf: true },
        { title: 'leaf', key: '10011', icon: 'anticon anticon-meh-o', isLeaf: true },
        { title: 'leaf', key: '10012', icon: 'anticon anticon-meh-o', isLeaf: true }
      ]
    }, {
      title: 'parent 1-1',
      key: '1002',
      icon: 'anticon anticon-meh-o',
      children: [
        { title: 'leaf', key: '10020', isLeaf: true }
      ]
    }, {
      title: 'parent 1-2',
      key: '1003',
      icon: 'anticon anticon-meh-o',
      children: [
        { title: 'leaf', key: '10030', icon: 'anticon anticon-meh-o', isLeaf: true },
        { title: 'leaf', key: '10031', icon: 'anticon anticon-meh-o', isLeaf: true }
      ]
    }]
  }];

  listOfData = [
    {
      key: '1',
      name: 32,
      ckecked: false,
      children: [{
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
      }]
    },
    {
      key: '2',
      name: 42,
      ckecked: false,
      children: [{
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
      }]
    },
    {
      key: '3',
      name: 32,
      ckecked: false,
      children: [{
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
      }]
    }
  ];

  /**
   * 激活的节点，只能激活一个
   */
  activedNode: NzTreeNode;

  defaultCheckedKeys = ['1001', '1002'];
  defaultSelectedKeys = ['10010', '10020'];
  defaultExpandedKeys = ['100', '1001'];


  @ViewChild('treeCom') treeCom;

  constructor(
    private http: _HttpClient,
    private modal: ModalHelper,
    private nzDropdownService: NzDropdownService,
  ) { }

  ngOnInit() {
    this.loadDatas();
  }

  loadDatas() {
    this.http
      .get('permission/getpermissions')
      .subscribe((res: any) => {
        if (!res.success) {
          console.log(res);
          return;
        }
        // this.nodes = res.data;
        this.nodes = [{ title: 'leaf', key: '10030', icon: 'anticon anticon-meh-o', isLeaf: true }];
        console.log(this.nodes);
      });
  }


  nzEvent(event: NzFormatEmitEvent): void {
    console.log(event);
    this.activedNode = event.node;
  }

  nzCheck(event: NzFormatEmitEvent): void {
    console.log(event, event.checkedKeys, event.keys, event.nodes);
  }

  // nzSelectedKeys change
  nzSelect(keys: string[]): void {
    console.log(keys, this.treeCom.getSelectedNodeList());
  }

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



  add() {
    const entity = new PermissionEditDto();
    if (this.activedNode != null) {
      const node = this.activedNode;
      entity.id = node.key;
      entity.name = node.title;
      entity.icon = '';
      entity.intro = '';
    }

    this.modal
      .createStatic(PermissionAddComponent, { entity })
      .subscribe((res) => this.addNode(res));
  }

  addNode(data: any) {
    console.log(data);

    const newNode = new NzTreeNode({
      title: data.name,
      key: data.code,
      icon: 'anticon anticon-meh-o', // 'anticon anticon-meh-o'
      isLeaf: true
    });

    newNode.origin.intro = 'jianjie';

    if (this.activedNode == null) {
      console.log('null');

      this.nodes.push(newNode);
    } else {
      console.log(this.activedNode);
      this.activedNode.isLeaf = false;
      this.activedNode.children.push(newNode);
    }
  }

  edit() {
    this.activedNode.title = 'sjdhfsjfs';
  }

  delete() {
    const child = this.activedNode.children;
    child.splice(0);
    this.activedNode.isLeaf = true;
  }


}
