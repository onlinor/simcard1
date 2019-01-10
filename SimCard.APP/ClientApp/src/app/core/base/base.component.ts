import { OnInit, OnDestroy } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ServiceLocator } from '../service-locator';
import {SubscribeService} from '../services/subscribe.service';
import {SubscribeConstant} from '../constants';
import { Title } from '@angular/platform-browser';

import {MessageService} from '../services';
import {Subscription} from 'rxjs/internal/Subscription';

export class BaseComponent implements OnInit, OnDestroy {
    submitted: boolean;
    formBuilder: FormBuilder;
    subscriptions: Subscription[] = [];
    title: string;

    protected messageService: MessageService;
    protected subscribeService: SubscribeService;
    protected titleService: Title;

    constructor() {
        this.titleService = ServiceLocator.injecttor.get(Title);
        this.formBuilder = ServiceLocator.injecttor.get(FormBuilder);

        this.submitted = false;
        this.title = '';

        this.messageService = ServiceLocator.injecttor.get(MessageService);
        this.subscribeService = ServiceLocator.injecttor.get(SubscribeService);
    }

    ngOnInit() {
        this.title = this.titleService.getTitle();
    }

    showLoading() {
        this.subscribeService.publish(SubscribeConstant.SHOW_LOADING, true);
    }

    hideLoading() {
        this.subscribeService.publish(SubscribeConstant.SHOW_LOADING, false);
    }

    unsubscribe() {
        this.subscriptions.forEach(subscription => {
          subscription.unsubscribe();
        });
        this.subscriptions = [];
    }

    ngOnDestroy() {

    }
}
