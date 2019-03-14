import { Injectable, Injector, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { zip } from 'rxjs';
import { catchError } from 'rxjs/operators';
import {
  MenuService,
  SettingsService,
  TitleService,
  ALAIN_I18N_TOKEN,
  _HttpClient,
} from '@delon/theme';
import { DA_SERVICE_TOKEN, ITokenService } from '@delon/auth';
import { ACLService } from '@delon/acl';
import { TranslateService } from '@ngx-translate/core';
import { I18NService } from '../i18n/i18n.service';

import { NzIconService } from 'ng-zorro-antd';
import { ICONS_AUTO } from '../../../style-icons-auto';
import { ICONS } from '../../../style-icons';
import { environment } from '@env/environment';
import { CacheService } from '@delon/cache';
import { throwIfAlreadyLoaded } from '@core/module-import-guard';

const GetAccountInfoUrl = 'Auth/GetAccountInfo';
const GetAccountMenuUrl = 'Auth/GetAccountMenu';
const GetAccountPermissionUrl = 'Auth/GetAccountPermission';

/**
 * 用于应用启动时
 * 一般用来获取应用所需要的基础数据等
 */
@Injectable()
export class StartupService {
  constructor(
    iconSrv: NzIconService,
    private menuService: MenuService,
    private translate: TranslateService,
    @Inject(ALAIN_I18N_TOKEN) private i18n: I18NService,
    private settingService: SettingsService,
    private aclService: ACLService,
    private titleService: TitleService,
    @Inject(DA_SERVICE_TOKEN) private tokenService: ITokenService,
    private httpClient: HttpClient,
    public http: _HttpClient,
    private injector: Injector,
    public cacheService: CacheService,
  ) {
    iconSrv.addIcon(...ICONS_AUTO, ...ICONS);
  }

  private viaMockI18n(resolve: any, reject: any) {
    this.httpClient
      // .get(`http://localhost:4200/assets/tmp/i18n/${this.i18n.defaultLang}.json`)
      .get(`http://localhost:4200/assets/tmp/i18n/zh-CN.json`)
      .subscribe(langData => {
        this.translate.setTranslation(this.i18n.defaultLang, langData);
        this.translate.setDefaultLang(this.i18n.defaultLang);

        // this.viaMock(resolve, reject);
      });
  }

  private viaMock(resolve: any, reject: any) {
    // const tokenData = this.tokenService.get();
    // if (!tokenData.token) {
    //   this.injector.get(Router).navigateByUrl('/passport/login');
    //   resolve({});
    //   return;
    // }
    // mock

    const app: any = {
      name: `ng-alain`,
      description: `Ng-zorro admin panel front-end framework`,
    };
    const user: any = {
      name: 'Admin',
      avatar: './assets/tmp/img/avatar.jpg',
      email: 'cipchk@qq.com',
      token: '123456789',
    };
    // 应用信息：包括站点名、描述、年份
    this.settingService.setApp(app);
    // 用户信息：包括姓名、头像、邮箱地址
    this.settingService.setUser(user);
    // ACL：设置权限为全量
    this.aclService.setFull(true);
    resolve({});
  }

  load(): Promise<any> {
    return new Promise((resolve, reject) => {
      // 国际化配置
      this.viaMockI18n(resolve, reject);

      // 应用信息：包括站点名、描述、年份
      const appInfo = environment.appInfo;
      this.settingService.setApp(appInfo);
      // 设置页面标题的后缀
      this.titleService.suffix = appInfo.name;

      const tokenInfo = this.tokenService.get();
      if (tokenInfo.token == null || tokenInfo.token === undefined) {
        console.log('账号未登录');
        resolve(null);
      } else {
        this.loadAccountInfo(resolve, reject);
      }
    });
  }

  private loadAccountInfo(resolve: any, reject: any) {
    this.cacheService.get('PandoraCurrentInfo').subscribe(res => {
      this.settingService.setUser(res);
      // tslint:disable-next-line:no-string-literal
      const accountId = res['id'];
      console.log(accountId);
      this.viaHttp(resolve, reject, accountId);
      resolve(null);
    });
  }

  private viaHttp(resolve: any, reject: any, accountId: string) {
    const getAccountInfoUrl = `${GetAccountInfoUrl}?id=${accountId}`;
    const getAccountMenuUrl = `${GetAccountMenuUrl}?id=${accountId}`;
    const getAccountPermissionUrl = `${GetAccountPermissionUrl}?id=${accountId}`;

    zip(
      this.httpClient.get(getAccountInfoUrl),
      this.httpClient.get(getAccountMenuUrl),
      this.httpClient.get(getAccountPermissionUrl),
    )
      .pipe(
        // 接收其他拦截器后产生的异常消息
        catchError(([accountInfoRes, accountMenuRes, accountPermissionRes]) => {
          resolve(null);
          return [accountInfoRes, accountMenuRes, accountPermissionRes];
        }),
      )
      .subscribe(
        ([accountInfoRes, accountMenuRes, accountPermissionRes]) => {
          // ACL：设置权限
          this.setPermission(accountPermissionRes.data);
          // 初始化菜单
          this.menuService.add([accountMenuRes.data]);
        },
        () => {},
        () => {
          resolve(null);
        },
      );
  }

  setPermission(datas: any) {
    const useAcl = environment.useAcl;
    if (!useAcl) {
      this.aclService.setFull(true);
    } else {
      const permis = datas as [];
      this.aclService.setAbility(permis);
    }
  }

  // load1(): Promise<any> {
  //   return new Promise((resolve, reject) => {
  //     // 国际化配置
  //     this.viaMockI18n(resolve, reject);

  //     // 应用信息：包括站点名、描述、年份
  //     const appInfo = environment.appInfo;
  //     this.settingService.setApp(appInfo);
  //     // 设置页面标题的后缀
  //     this.titleService.suffix = appInfo.name;

  //     // 用户信息：包括姓名、头像、邮箱地址
  //     const userInfo = {
  //       accountId: '123456',
  //       name: 'Admin',
  //       avatar: './assets/tmp/img/avatar.jpg',
  //       email: 'cipchk@qq.com',
  //       role: '管理员',
  //     };
  //     this.settingService.setUser(userInfo);

  //     // ACL：设置权限为全量
  //     this.aclService.setFull(true);

  //     // 初始化菜单
  //     const menuInfo = [
  //       {
  //         text: '主导航',
  //         group: true,
  //         hideInBreadcrumb: false,
  //         children: [
  //           {
  //             text: '系统设置',
  //             icon: 'anticon anticon-setting',
  //             shortcutRoot: false,
  //             children: [
  //               {
  //                 text: '角色管理列表',
  //                 link: '/sys/role-list',
  //               },
  //               {
  //                 text: '权限管理列表',
  //                 link: '/sys/permission-list',
  //               },
  //               {
  //                 text: '菜单管理列表',
  //                 link: '/sys/menu-list',
  //               },
  //               {
  //                 text: '账号管理列表',
  //                 link: '/sys/account-list',
  //               },
  //             ],
  //           },
  //         ],
  //       },
  //     ];
  //     this.menuService.add(menuInfo);

  //     resolve(null);
  //   });
  // }
}
