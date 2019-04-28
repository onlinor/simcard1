import { Injectable } from '@angular/core';
import { isFunction } from 'util';
import { ToastrService } from 'ngx-toastr';

import { MessageConfigModel } from '../models';

declare var swal: any;

@Injectable()
export class MessageService {
  constructor(private toastr: ToastrService) {}

  showErrorAlert(config: MessageConfigModel) {
    return swal(config.title, config.message, 'error');
  }

  showErrorMessage(config: MessageConfigModel) {
    this.toastr.error(config.message, config.title);
  }

  showSuccessAlert(config: MessageConfigModel) {
    return swal(config.title, config.message, 'success');
  }

  showSuccessMessage(config: MessageConfigModel) {
    this.toastr.success(config.message, config.title);
  }

  showWarningAlert(config: MessageConfigModel) {
    return swal(config.title, config.message, 'warning');
  }

  showWarningMessage(config: MessageConfigModel) {
    this.toastr.warning(config.message, config.title);
  }

  showInfoAlert(config: MessageConfigModel) {
    return swal(config.title, config.message, 'info');
  }

  showInfoMessage(config: MessageConfigModel) {
    this.toastr.info(config.message, config.title);
  }

  showConfirmMessage(context, config: any) {
    const defaultConfig = {
      title: config.title,
      text: config.message,
      type: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes',
      cancelButtonText: 'No',
      confirmButtonClass: 'btn btn-primary',
      cancelButtonClass: 'btn btn-danger'
    };

    Object.assign(defaultConfig, config);
    swal(
      defaultConfig,
      function(checkBoxValue) {
        if (isFunction(config.confirmCallback)) {
          config.confirmCallback(context, checkBoxValue);
        }
      },
      function(dismiss) {
        // dismiss can be 'overlay', 'cancel', 'close', 'esc', 'timer'
        if (isFunction(config.cancelCallback)) {
          config.cancelCallback();
        }
      }
    );
  }

  showAlertMessage(config: any, callback: any) {
    return swal(config, callback);
  }
}
