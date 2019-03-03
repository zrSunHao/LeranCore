import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { NzFormatEmitEvent, NzTreeNode, NzDropdownContextComponent, NzDropdownService } from 'ng-zorro-antd';

@Component({
  selector: 'app-permission-tree',
  templateUrl: './permission-tree.component.html',
  styles: []
})
export class PermissionTreeComponent implements OnInit {

  nodes = [{
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

  dropdown: NzDropdownContextComponent;
  /**
   * 激活的节点，只能激活一个
   */
  activedNode: NzTreeNode;

  defaultCheckedKeys = ['1001', '1002'];
  defaultSelectedKeys = ['10010', '10020'];
  defaultExpandedKeys = ['100', '1001'];


  @ViewChild('treeCom') treeCom;

  constructor(
    private nzDropdownService: NzDropdownService,
  ) { }

  ngOnInit() {
  }

  nzEvent(event: NzFormatEmitEvent): void {
    console.log(event);
  }

  nzCheck(event: NzFormatEmitEvent): void {
    console.log(event, event.checkedKeys, event.keys, event.nodes);
  }

  // nzSelectedKeys change
  nzSelect(keys: string[]): void {
    console.log(keys, this.treeCom.getSelectedNodeList());
  }

  nzMenu(event: NzFormatEmitEvent): void {
    console.log(event);
  }

  openFolder(data: NzTreeNode | NzFormatEmitEvent): void {
    // do something if u want
    if (data instanceof NzTreeNode) {
      data.setExpanded(!data.isExpanded);
    } else {
      data.node.setExpanded(!data.node.isExpanded);
    }
  }

  activeNode(data: NzFormatEmitEvent): void {
    data.node.setExpanded(true);
    this.activedNode = data.node;
  }


}
