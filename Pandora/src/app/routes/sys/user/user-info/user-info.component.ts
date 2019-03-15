import {
  Component,
  ChangeDetectionStrategy,
  OnInit,
  ChangeDetectorRef,
} from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { zip } from 'rxjs';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.less'],
})
export class UserInfoComponent implements OnInit {
  avatar = '';
  userLoading = false;
  user: any;

  constructor(
    private http: _HttpClient,
    private cdr: ChangeDetectorRef,
    private msg: NzMessageService,
  ) {}

  ngOnInit(): void {
    // zip(
    //   this.http.get('/user/current'),
    //   this.http.get('/geo/province'),
    // ).subscribe(([user, province]: any) => {
    //   this.userLoading = false;
    //   this.user = user;
    //   this.provinces = province;
    //   this.choProvince(user.geographic.province.key, false);
    //   this.cdr.detectChanges();
    // });
    this.user = {
      name: null,
      avatar:
        'http://zeus-dev.oss-cn-qingdao.aliyuncs.com/a54af76a-0c2c-99ed-8694-997d7fe49b26.jpg',
      userid: null,
      email: 'cipchk@qq.com',
      signature: '海纳百川，有容乃大',
      title: '交互专家',
      group: '蚂蚁金服－某某某事业群－某某平台部－某某技术部－UED',
      tags: [
        {
          key: '0',
          label: '很有想法的',
        },
        {
          key: '1',
          label: '专注撩妹',
        },
        {
          key: '2',
          label: '帅~',
        },
        {
          key: '3',
          label: '通吃',
        },
        {
          key: '4',
          label: '专职后端',
        },
        {
          key: '5',
          label: '海纳百川',
        },
      ],
      notifyCount: 12,
      country: 'China',
      geographic: {
        province: {
          label: '上海',
          key: '330000',
        },
        city: {
          label: '市辖区',
          key: '330100',
        },
      },
      address: 'XX区XXX路 XX 号',
      phone: '你猜-你猜你猜猜猜',
    };
    this.provinces = [
      {
        label: '上海',
        key: '330000',
      },
    ];
  }

  // #region geo

  provinces: any[] = [];
  cities: any[] = [];

  choProvince(pid: string, cleanCity = true) {
    this.http.get(`/geo/${pid}`).subscribe((res: any) => {
      this.cities = res;
      if (cleanCity) this.user.geographic.city.key = '';
      this.cdr.detectChanges();
    });
  }

  // #endregion

  editAvatar() {
    console.log(1111111111);
  }

  save() {
    this.msg.success(JSON.stringify(this.user));
    return false;
  }
}
