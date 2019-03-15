import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-user-notification',
  templateUrl: './user-notification.component.html',
  styles: [],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserNotificationComponent implements OnInit {
  i: any = {
    password: true,
    messages: true,
    todo: true,
  };

  constructor(public msg: NzMessageService) {}

  ngOnInit() {}
}
