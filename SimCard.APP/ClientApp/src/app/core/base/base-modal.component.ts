import {OnDestroy, OnInit} from '@angular/core';
import {FormGroup} from '@angular/forms';

import {ServiceLocator} from '../service-locator';
import {BaseComponent} from './base.component';
import {CrudService} from '../services/crud.service';
import {HttpStatusCode} from '../constants';
import {Observable} from 'rxjs/internal/Observable';

export abstract class BaseModalComponent extends BaseComponent
  implements OnInit, OnDestroy {
  protected crudService: CrudService;

  title: string;
  viewModel: any;
  crudName: string;
  modalForm: FormGroup;
  validForm: boolean;

  constructor() {
    super();
    this.crudService = ServiceLocator.injecttor.get(CrudService);
    this.viewModel = {};
    this.validForm = true;
  }

  protected abstract saveObservable(viewModel: any): Observable<any>;
  protected abstract closeModal(): void;

  ngOnInit() {
    super.ngOnInit();
  }

  ngOnDestroy() {
    super.ngOnDestroy();
  }

  protected save(saveCallback?: Function, errorCallback?: Function) {
    this.submitted = true;
    if (!this.modalForm.valid || !this.isValidForm()) {
      this.validForm = false;
      return;
    }
    this.validForm = true;
    // this.showLoading();
    this.saveObservable(this.modalForm.value.warehouse).subscribe(
      result => {
        // this.hideLoading();
        this.crudService.saveResult({
          result: result,
          viewModel: this.modalForm.value,
          crudName: this.crudName
        });
        if (result) {
          this.closeModal();
        } else {
          this.messageService.showErrorMessage({
            title: 'Save',
            message: 'There was an error while saving data. Please try again!!!'
          });
        }
        if (saveCallback) {
          saveCallback(result);
        }
      },
      (error) => {
        // this.hideLoading();
        if (error.status !== HttpStatusCode.SimCardError) {
          this.messageService.showErrorAlert({
            title: 'Save',
            message: 'There was an error while saving data. Please try again!!!'
          });
        }
        if (errorCallback) {
          errorCallback(false);
        }
      }
    );
  }

  protected isValidForm() {
    return true;
  }
}
