export class PagingOptions<T> {
  // fields
  filter: T;
  pageIndex: number;
  pageSize: number;
  sort: Array<PagingSort>;

  // constructor overrides
  constructor(
    filters: T = null,
    pageIndex: number = 0,
    pageSize: number = 10,
    sort: Array<PagingSort> = [],
  ) {
    this.filter = filters;
    this.pageIndex = pageIndex;
    this.pageSize = pageSize;
    this.sort = sort;
  }
}

export class PagingSort {
  field: string;
  sort: string;

  constructor(field, sort) {
    this.field = field;
    this.sort = sort;
  }
}
