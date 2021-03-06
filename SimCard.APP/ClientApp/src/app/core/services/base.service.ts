import { Injectable } from '@angular/core';

import { ServiceLocator } from '../service-locator';
import { ApiService } from './api.service';
import { CommonService } from './common.service';

@Injectable()
export class BaseService {
    protected BASE_URI: string;

    protected apiService: ApiService;
    protected commonService: CommonService;

constructor() {
    this.apiService = ServiceLocator.injecttor.get(ApiService);
    this.commonService = ServiceLocator.injecttor.get(CommonService);
}

}
