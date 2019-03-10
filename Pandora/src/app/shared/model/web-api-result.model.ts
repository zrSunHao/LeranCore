export class WebApiResult {
  data: any;
  success: boolean;
  allMessages: string;
  messages: string;
  hasErrors: boolean;
  errors: [];
}

export class WebApiPagingResult {
  data: any;
  success: boolean;
  rowsCount: number;
  allMessages: string;
  messages: string;
  hasErrors: boolean;
  errors: [];
}
