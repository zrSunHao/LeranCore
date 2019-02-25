export class WebApiPagingResult<T> {
    data: T[];
    rowsCount: number;
    errorMessage: string;
    hasErrors: boolean;
    success: boolean;
    allMessages: string;
    errors: any[];
    messages: string[];
}

export class WebApiResult {
    data: any;
    errorMessage: string;
    hasErrors: boolean;
    success: boolean;
    allMessages: string;
    errors: any[];
    messages: string[];
}
