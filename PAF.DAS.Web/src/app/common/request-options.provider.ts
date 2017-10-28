import { Injectable } from '@angular/core';
import { BaseRequestOptions, RequestOptions } from '@angular/http';

@Injectable()
export class DefaultRequestOptionsProvider extends BaseRequestOptions {

  constructor() {
    super();

    // Set the default 'Content-Type' header
    this.headers.set('Content-Type', 'application/json');

    // get and set the token here
  }
}

export const RequestOptionsProvider = {
  provide: RequestOptions,
  useClass: DefaultRequestOptionsProvider
};
