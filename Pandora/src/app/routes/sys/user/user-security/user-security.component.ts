import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-user-security',
  templateUrl: './user-security.component.html',
  styles: [],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserSecurityComponent implements OnInit {
  constructor(public msg: NzMessageService) {}

  ngOnInit() {}
}
