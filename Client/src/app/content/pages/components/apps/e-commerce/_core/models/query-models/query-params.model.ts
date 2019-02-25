export class QueryParamsModel {
	// fields
	filter: any;
	sortOrder: string; // asc || desc
	sortField: string;
	pageNumber: number;
	pageSize: number;

	// constructor overrides
	constructor(
		_filter: any,
		_sortOrder: string = 'asc',
		_sortField: string = '',
		_pageNumber: number = 0,
		_pageSize: number = 10) {
		this.filter = _filter;
		this.sortOrder = _sortOrder;
		this.sortField = _sortField;
		this.pageNumber = _pageNumber;
		this.pageSize = _pageSize;
	}
}

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

export class PagingFilter {
	field: string;
	term: string;
	constructor(_field, _term) {
		this.field = _field;
		this.term = _term;
	}
}

export class TestModel {
	id: string = '0';
	name: string = 'hahahah';
}
