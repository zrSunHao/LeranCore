import {
  Component,
  OnInit,
  ChangeDetectorRef,
} from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { STColumn } from '@delon/abc';
import { format } from 'date-fns';
import { getTimeDistance } from '@delon/util';
import { _HttpClient } from '@delon/theme';
import { I18NService } from '@core';
import { yuan } from '@shared';


const visitData = [];
const beginDay = new Date().getTime();

const fakeY = [7, 5, 4, 2, 4, 7, 5, 6, 5, 9, 6, 3, 1, 5, 3, 6, 5];
for (let i = 0; i < fakeY.length; i += 1) {
  visitData.push({
    x: format(new Date(beginDay + 1000 * 60 * 60 * 24 * i), 'YYYY-MM-DD'),
    y: fakeY[i],
  });
}

const visitData2 = [];
const fakeY2 = [1, 6, 4, 8, 3, 7, 2];
for (let i = 0; i < fakeY2.length; i += 1) {
  visitData2.push({
    x: format(new Date(beginDay + 1000 * 60 * 60 * 24 * i), 'YYYY-MM-DD'),
    y: fakeY2[i],
  });
}

const salesData = [];
for (let i = 0; i < 12; i += 1) {
  salesData.push({
    x: `${i + 1}月`,
    y: Math.floor(Math.random() * 1000) + 200,
  });
}
const searchData = [];
for (let i = 0; i < 50; i += 1) {
  searchData.push({
    index: i + 1,
    keyword: `搜索关键词-${i}`,
    count: Math.floor(Math.random() * 1000),
    range: Math.floor(Math.random() * 100),
    status: Math.floor((Math.random() * 10) % 2),
  });
}
const salesTypeData = [
  {
    x: '家用电器',
    y: 4544,
  },
  {
    x: '食用酒水',
    y: 3321,
  },
  {
    x: '个护健康',
    y: 3113,
  },
  {
    x: '服饰箱包',
    y: 2341,
  },
  {
    x: '母婴产品',
    y: 1231,
  },
  {
    x: '其他',
    y: 1231,
  },
];

const salesTypeDataOnline = [
  {
    x: '家用电器',
    y: 244,
  },
  {
    x: '食用酒水',
    y: 321,
  },
  {
    x: '个护健康',
    y: 311,
  },
  {
    x: '服饰箱包',
    y: 41,
  },
  {
    x: '母婴产品',
    y: 121,
  },
  {
    x: '其他',
    y: 111,
  },
];

const salesTypeDataOffline = [
  {
    x: '家用电器',
    y: 99,
  },
  {
    x: '个护健康',
    y: 188,
  },
  {
    x: '服饰箱包',
    y: 344,
  },
  {
    x: '母婴产品',
    y: 255,
  },
  {
    x: '其他',
    y: 65,
  },
];

const offlineData = [];
for (let i = 0; i < 10; i += 1) {
  offlineData.push({
    name: `门店${i}`,
    cvr: Math.ceil(Math.random() * 9) / 10,
  });
}
const offlineChartData = [];
for (let i = 0; i < 20; i += 1) {
  offlineChartData.push({
    x: new Date().getTime() + 1000 * 60 * 30 * i,
    y1: Math.floor(Math.random() * 100) + 10,
    y2: Math.floor(Math.random() * 100) + 10,
  });
}

const radarOriginData = [
  {
    name: '个人',
    ref: 10,
    koubei: 8,
    output: 4,
    contribute: 5,
    hot: 7,
  },
  {
    name: '团队',
    ref: 3,
    koubei: 9,
    output: 6,
    contribute: 3,
    hot: 1,
  },
  {
    name: '部门',
    ref: 4,
    koubei: 1,
    output: 6,
    contribute: 5,
    hot: 7,
  },
];

//
const radarData = [];
const radarTitleMap = {
  ref: '引用',
  koubei: '口碑',
  output: '产量',
  contribute: '贡献',
  hot: '热度',
};
radarOriginData.forEach(item => {
  Object.keys(item).forEach(key => {
    if (key !== 'name') {
      radarData.push({
        name: item.name,
        label: radarTitleMap[key],
        value: item[key],
      });
    }
  });
});




@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.less'],
})
export class DashboardComponent implements OnInit {
  data: any = {};
  loading = true;
  // tslint:disable-next-line:variable-name
  date_range: Date[] = [];
  rankingListData: any[] = Array(7)
    .fill({})
    .map((item, i) => {
      return {
        title: this.i18n.fanyi('app.analysis.test', { no: i }),
        total: 323234,
      };
    });
  titleMap = {
    y1: this.i18n.fanyi('app.analysis.traffic'),
    y2: this.i18n.fanyi('app.analysis.payments'),
  };
  searchColumn: STColumn[] = [
    { title: '排名', i18n: 'app.analysis.table.rank', index: 'index' },
    {
      title: '搜索关键词',
      i18n: 'app.analysis.table.search-keyword',
      index: 'keyword',
      click: (item: any) => this.msg.success(item.keyword),
    },
    {
      type: 'number',
      title: '用户数',
      i18n: 'app.analysis.table.users',
      index: 'count',
      sorter: (a, b) => a.count - b.count,
    },
    {
      type: 'number',
      title: '周涨幅',
      i18n: 'app.analysis.table.weekly-range',
      index: 'range',
      render: 'range',
      sorter: (a, b) => a.range - b.range,
    },
  ];


  constructor(
    private http: _HttpClient,
    public msg: NzMessageService,
    private i18n: I18NService,
    private cdr: ChangeDetectorRef,
  ) {}

  ngOnInit() {

    const res = JSON.parse(JSON.stringify({
      visitData,
      visitData2,
      salesData,
      searchData,
      offlineData,
      offlineChartData,
      salesTypeData,
      salesTypeDataOnline,
      salesTypeDataOffline,
      radarData,
    }));
    res.offlineData.forEach((item: any, idx: number) => {
      item.show = idx === 0;
      console.log(item);
      item.chart = Object.assign([], res.offlineChartData);
    });
    this.data = res;
    this.loading = false;
    // this.http.get('/chart').subscribe((res: any) => {
    //   res.offlineData.forEach((item: any, idx: number) => {
    //     item.show = idx === 0;
    //     item.chart = Object.assign([], res.offlineChartData);
    //   });
    //   this.data = res;
    //   this.loading = false;
    //   this.changeSaleType();
    // });
  }

  setDate(type: any) {
    this.date_range = getTimeDistance(type);
    setTimeout(() => this.cdr.detectChanges());
  }

  // tslint:disable-next-line:member-ordering
  salesType = 'all';
  // tslint:disable-next-line:member-ordering
  salesPieData: any;
  // tslint:disable-next-line:member-ordering
  salesTotal = 0;
  changeSaleType() {
    this.salesPieData =
      this.salesType === 'all'
        ? this.data.salesTypeData
        : this.salesType === 'online'
        ? this.data.salesTypeDataOnline
        : this.data.salesTypeDataOffline;
    if (this.salesPieData) {
      this.salesTotal = this.salesPieData.reduce((pre, now) => now.y + pre, 0);
    }
    this.cdr.detectChanges();
  }

  handlePieValueFormat(value: any) {
    return yuan(value);
  }

  // tslint:disable-next-line:member-ordering
  saleTabs: any[] = [{ key: 'sales', show: true }, { key: 'visits' }];
  salesChange(idx: number) {
    if (this.saleTabs[idx].show !== true) {
      this.saleTabs[idx].show = true;
      this.cdr.detectChanges();
    }
  }

  // tslint:disable-next-line:member-ordering
  offlineIdx = 0;
  offlineChange(idx: number) {
    if (this.data.offlineData[idx].show !== true) {
      this.data.offlineData[idx].show = true;
      this.cdr.detectChanges();
    }
  }
}
