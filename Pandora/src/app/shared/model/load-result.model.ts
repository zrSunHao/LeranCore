export class LoadResult<T> {

  data: T;
  success: boolean;
  errMsg: string;

  // constructor overrides
  constructor(
    data: T,
    success: boolean = false,
    errMsg: string = ''
  ) {
    this.data = data;
    this.success = success;
    this.errMsg = errMsg;
  }
}
