import { Injectable, Injector, Inject } from '@angular/core';
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
import { Router } from '@angular/router';

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

  // 初始化应用信息
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
        this.injector.get(Router).navigateByUrl(`/passport/login`);
      } else {
        this.loadAccountInfo(resolve, reject);
      }
    });
  }

  // 缓存中获取账号信息
  private loadAccountInfo(resolve: any, reject: any) {

    const accountInfo = this.cacheService.getNone('PandoraCurrentInfo');
    if (accountInfo == null) {
      console.log('账号未登录');
      resolve(null);
      this.injector.get(Router).navigateByUrl(`/passport/login`);
    } else {
      this.settingService.setUser(accountInfo);
      console.log(accountInfo);
      // tslint:disable-next-line:no-string-literal
      const accountId = accountInfo['id'];
      console.log(accountId);
      this.viaHttp(resolve, reject, accountId);
      resolve(null);
    }
  }

  // 获取账号信息
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
          console.log(accountMenuRes.data);
          if (accountMenuRes.data == null) {
            this.menuService.add([]);
          } else {
            this.menuService.add([accountMenuRes.data]);
          }
        },
        () => { },
        () => {
          resolve(null);
        },
      );
  }

  // 设置权限
  private setPermission(datas: any) {
    const useAcl = environment.useAcl;
    if (!useAcl) {
      this.aclService.setFull(true);
    } else {
      const permis = datas as [];
      this.aclService.setAbility(permis);
    }
  }

}
