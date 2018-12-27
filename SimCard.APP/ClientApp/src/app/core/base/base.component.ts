import { OnInit, OnDestroy } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ServiceLocator } from '../service-locator';
import { Title } from '@angular/platform-browser';

export class BaseComponent implements OnInit, OnDestroy {
    submitted: boolean;
    formBuilder: FormBuilder;
    title: string;

    protected titleService: Title;

    constructor() {
        this.titleService = ServiceLocator.injecttor.get(Title);
        this.formBuilder = ServiceLocator.injecttor.get(FormBuilder);

        this.submitted = false;
        this.title = '';
    }

    ngOnInit() {
        this.title = this.titleService.getTitle();
    }
    ngOnDestroy() {

    }
}
