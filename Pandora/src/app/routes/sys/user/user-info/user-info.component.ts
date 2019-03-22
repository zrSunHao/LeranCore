import { Component, OnInit, ViewChild } from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { SFSchema, SFButton } from '@delon/form';
import { NzNotificationService } from 'ng-zorro-antd';
import { STComponent } from '@delon/abc';
import { DatePipe } from '@angular/common';

const EditUserInfoUrl = 'User/EditUserInfo';
const GetUserInfoUrl = 'User/GetUserInfo';
const BindAccountAvatarUrl = 'Auth/BindAccountAvatar';
const GetUserAvatarUrl = 'Auth/GetUserAvatar';

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
      qq: { type: 'string', title: 'QQ', maxLength: 15 },
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
    required: ['name', 'sex', 'birthday'],
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
    this.GetAvatar();
  }

  GetAvatar() {
    this.http.get(GetUserAvatarUrl).subscribe((res: any) => {
      if (!res.success) {
        this.notification.create('error', '获取头像信息失败', res.allMessages);
      } else {
        if (res.data != null) {
          this.avatar = res.data;
        }
      }
    });
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
      .pipe((res: any) => {
        this.userLoading = false;
        return res;
      })
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
      });
  }

  uploadResult(event) {
    this.userLoading = true;
    if (event.success) {
      const file = event.file;
      this.uploadFile(file);
    } else {
      this.notification.create('error', '头像上传失败', event.reason);
      this.userLoading = false;
    }
  }

  uploadFile(file: any) {
    this.http
      .post(BindAccountAvatarUrl, file)
      .pipe((res: any) => {
        this.userLoading = false;
        return res;
      })
      .subscribe((res: any) => {
        if (!res.success) {
          this.notification.create('error', '头像更新失败', res.allMessages);
        } else {
          this.notification.create('success', '头像更新成功', res.allMessages);
          this.avatar = file.url;
        }
      });
  }
}
