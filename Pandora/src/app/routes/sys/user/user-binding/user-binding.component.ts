import { Component, ChangeDetectionStrategy, OnInit } from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-user-binding',
  templateUrl: './user-binding.component.html',
  styles: [],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserBindingComponent implements OnInit {
  constructor(public msg: NzMessageService) {}

  ngOnInit() {}
}
