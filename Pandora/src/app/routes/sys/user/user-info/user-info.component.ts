import {
  Component,
  ChangeDetectionStrategy,
  OnInit,
  ChangeDetectorRef,
  ViewChild,
} from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { SFSchema, SFButton, SFComponent } from '@delon/form';
import { NzNotificationService } from 'ng-zorro-antd';
import { STComponent } from '@delon/abc';
import { DatePipe } from '@angular/common';

const EditUserInfoUrl = 'User/EditUserInfo';
const GetUserInfoUrl = 'User/GetUserInfo';
const sexList = [{ label: '男', value: true }, { label: '女', value: false }];

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.less'],
})
export class UserInfoComponent implements OnInit {
  userLoading = false;
  info: any;
  avatar =
    'http://zeus-dev.oss-cn-qingdao.aliyuncs.com/a54af76a-0c2c-99ed-8694-997d7fe49b26.jpg';

  schema: SFSchema = {
    properties: {
      name: { type: 'string', title: '姓名', maxLength: 100 },
      sex: {
        type: 'string',
        title: '性别',
        enum: sexList,
        ui: { widget: 'radio', change: console.log },
      },
      birthday: { type: 'string', title: '生日', format: 'date' },
      phoneNum: {
        type: 'string',
        title: '电话',
        maxLength: 11,
        format: 'mobile',
      },
      qQ: { type: 'string', title: 'QQ', maxLength: 15 },
      weChart: { type: 'string', title: '微信', maxLength: 30 },
      occupation: { type: 'string', title: '职业', maxLength: 150 },
      company: { type: 'string', title: '公司/学校', maxLength: 150 },
      address: { type: 'string', title: '地址', maxLength: 150 },
      motto: {
        type: 'string',
        title: '座右铭',
        maxLength: 150,
        ui: {
          widget: 'textarea',
          autosize: { minRows: 2, maxRows: 6 },
        },
      },
      intro: {
        type: 'string',
        title: '个人简介',
        maxLength: 300,
        ui: {
          widget: 'textarea',
          autosize: { minRows: 2, maxRows: 6 },
        },
      },
    },
    required: ['name', 'sex', 'birthday', 'phoneNum'],
  };

  sfButton: SFButton = {
    submit: '提交',
  };

  @ViewChild('st') st: STComponent;

  constructor(
    public http: _HttpClient,
    private datePipe: DatePipe,
    private notification: NzNotificationService,
  ) {}

  ngOnInit(): void {
    this.userLoading = true;
    this.getUserInfo();
  }

  editAvatar() {
    console.log(1111111111);
  }

  submit(value: any) {
    this.userLoading = true;
    this.http.post(EditUserInfoUrl, value).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '更新失败', res.allMessages);
      } else {
        this.notification.create('success', '更新成功', res.allMessages);
      }
      this.userLoading = false;
    });
  }

  getUserInfo() {
    this.http
      .get(GetUserInfoUrl)
      .subscribe((res: any) => {
        if (!res.success) {
          this.notification.create(
            'error',
            '基本信息获取失败',
            res.allMessages,
          );
        } else {
          if (res.data != null) {
            this.info = res.data;
            if (this.info.birthday) {
              this.info.birthday = this.datePipe.transform(
                this.info.birthday,
                'yyyy-MM-dd',
              );
            }
            console.log(this.info);
          }
        }
        this.userLoading = false;
        console.log(this.userLoading);
      });
    console.log(this.userLoading);
  }

  test(event: any) {
    console.log(event.valid);
    console.log(event.errors);
  }
}
