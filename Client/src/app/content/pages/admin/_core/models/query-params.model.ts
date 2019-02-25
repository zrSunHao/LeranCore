export class PagingOptions<T> {
	// fields
	filters: T;
	sortOrder: string; // asc || desc
	sortField: string;
	pageIndex: number;
	pageSize: number;

	// constructor overrides
	constructor(
		_filters: T,
		_sortOrder: string = 'asc',
		_sortField: string = '',
		_pageIndex: number = 0,
		_pageSize: number = 10) {
		this.filters = _filters;
		this.sortOrder = _sortOrder;
		this.sortField = _sortField;
		this.pageIndex = _pageIndex;
		this.pageSize = _pageSize;
	}
}
