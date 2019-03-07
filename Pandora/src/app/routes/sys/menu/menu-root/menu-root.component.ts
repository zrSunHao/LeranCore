import { Component, OnInit } from '@angular/core';
import { ModalHelper, _HttpClient } from '@delon/theme';
import { NzNotificationService } from 'ng-zorro-antd';
import { MenuAddComponent } from '../menu-add/menu-add.component';

@Component({
  selector: 'app-menu-root',
  templateUrl: './menu-root.component.html',
  styles: [],
})
export class MenuRootComponent implements OnInit {
  list = [];
  initLoading = false;

  constructor(
    private modal: ModalHelper,
    private http: _HttpClient,
    private notification: NzNotificationService,
  ) {}

  ngOnInit() {}

  add() {
    const isEdit = false;
    const title = '添加模块';
    const entity = {
      name: null,
      code: null,
      icon: null,
      tagColor: null,
      intro: null,
      isModule: true,
    };

    this.modal
      .createStatic(MenuAddComponent, { entity, isEdit, title })
      .subscribe(res => {});
  }

  edit(item) {}

  active(item) {}

  delete(item) {}
}
