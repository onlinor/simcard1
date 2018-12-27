import { Injectable } from '@angular/core';

import { ServiceLocator } from '../service-locator';
import { ApiService } from './api.service';

@Injectable()
export class BaseService {
    protected BASE_URI: string;

    protected apiService: ApiService;


constructor() {
    this.apiService = ServiceLocator.injecttor.get(ApiService);
}

}
