import { HttpClient } from '@angular/common/http';
import {AppHttpClient} from './app.httpclient';

export class BaseService {
  extendedHttp: AppHttpClient;
  constructor(private http: HttpClient) {
      this.extendedHttp = new AppHttpClient(http);
  }

}
