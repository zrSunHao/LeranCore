export class PagingOptions<T> {
  // fields
  filters: T;
  sortOrder: string; // asc || desc
  sortField: string;
  pageIndex: number;
  pageSize: number;

  // constructor overrides
  constructor(
    filters: T,
    sortOrder: string = 'asc',
    sortField: string = '',
    pageIndex: number = 0,
    pageSize: number = 10) {
    this.filters = filters;
    this.sortOrder = sortOrder;
    this.sortField = sortField;
    this.pageIndex = pageIndex;
    this.pageSize = pageSize;
  }
}
