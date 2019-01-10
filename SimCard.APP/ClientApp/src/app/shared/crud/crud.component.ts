import { Component, Injectable, Input, OnInit } from '@angular/core';

import { BsModalService, BsModalRef } from 'ngx-bootstrap';

import {
  CrudConfigModel,
  PagingModel,
  PagingQueryModel
} from '../../core/models';
import { CrudColumnType, CrudColumnTypeValue } from '../../core/enums';
import {
  CrudService,
  PermissionService,
  CommonService
} from '../../core/services';
import { CrudActionType, DefaultDataConstant } from '../../core/constants';
import { BaseComponent } from '../../core/base';

@Component({
  selector: 'app-crud',
  templateUrl: './crud.component.html',
  styleUrls: ['./crud.component.scss']
})
@Injectable()
export class CrudComponent extends BaseComponent implements OnInit {
  @Input() config: CrudConfigModel;
  @Input() options: any;

  crudColumnTypes = CrudColumnType;
  crudColumnTypeValues = CrudColumnTypeValue;
  searchValue: string;
  paging: PagingModel;
  data: any[];
  defaulImage = DefaultDataConstant.IMG_DEFAULT_URL;

  private bsModalRef: BsModalRef;

  constructor(
    private crudService: CrudService,
    private commonService: CommonService,
    private modalService: BsModalService,
    private permissionService: PermissionService
  ) {
    super();
    this.searchValue = '';
    this.paging = new PagingModel();
    this.data = [];
    this.options = {};
    this.subscribe();
  }

  ngOnInit() {
    super.ngOnInit();
    this.initPermission();
    this.loadData();
  }

  create() {
    if (this.config.allowCustomCreate) {
      this.crudService.action({ action: CrudActionType.CREATE, data: null });
    } else {
      if (this.config.allowCreate) {
        this.openItem(0, this.config.titles.create);
      }
    }
  }

  edit(id) {
    if (this.config.allowEdit) {
      this.openItem(id, this.config.titles.edit);
    }
  }

  delete(id) {
    if (
      !this.config.allowDelete ||
      !this.config.data ||
      !this.config.data.delete
    ) {
      return;
    }
    this.messageService.showConfirmMessage(this, {
      title: this.config.titles.delete,
      message: this.config.messages.deleteConfirm,
      confirmCallback: function (context, confirmResult) {
        if (!confirmResult) {
          return;
        }
        // context.showLoading();
        context.config.data.delete(id).subscribe(
          result => {
           // context.hideLoading();
            if (result) {
/*               context.messageService.showSuccessMessage({
                title: context.config.titles.delete,
                message: context.config.messages.deleteSuccess
              }); */
              context.loadData();
            } else {
              context.messageService.showErrorMessage({
                title: context.config.titles.delete,
                message: context.config.messages.deleteError
              });
            }
          },
          () => {
            // context.hideLoading();
            context.showDefaultDeleteErrorMessage();
          }
        );
      }
    });
  }

  onActionClick(action: string, item: any) {
    switch (action) {
      case CrudActionType.EDIT:
        if (this.config.allowCustomEdit) {
          this.crudService.action({ action: action, data: item });
        } else {
          this.edit(item.id);
        }
        break;
      case CrudActionType.DELETE:
        if (this.config.allowCustomDelete) {
          this.crudService.action({ action: action, data: item });
        } else {
          this.delete(item.id);
        }
        break;
      default:
        this.crudService.action({ action: action, data: item });
        break;
    }
  }

  search() {
    this.paging = new PagingModel();
    this.loadData();
  }

  pageChanged(event: any) {
    this.paging.currentPage = event.page;
    this.paging.pageSize = event.itemsPerPage;
    this.loadData();
  }

  private initPermission() {
    if (this.config.permission && this.config.permission.create) {
      const hasCreate = this.permissionService.hasPermission([
        this.config.permission.create
      ]);
      this.config.allowCreate = this.config.allowCreate && hasCreate;
    }
    if (this.config.permission && this.config.permission.edit) {
      const hasEdit = this.permissionService.hasPermission([
        this.config.permission.edit
      ]);
      this.config.allowEdit = this.config.allowEdit && hasEdit;
    }
    if (this.config.permission && this.config.permission.delete) {
      const hasDelete = this.permissionService.hasPermission([
        this.config.permission.delete
      ]);
      this.config.allowDelete = this.config.allowDelete && hasDelete;
    }
  }

  private openItem(id: any, title: string) {
    if (!this.config.data || !this.config.data.getById) {
      return;
    }
    // this.showLoading();
    this.config.data.getById(id).subscribe(
      viewModel => {
        // this.hideLoading();
        this.openModal(title, viewModel);
      },
      err => {
        // this.hideLoading();
        this.messageService.showErrorMessage({
          title: this.config.titles.get,
          message: this.config.messages.getError
        });
      }
    );
  }

  private openModal(title: string, viewModel: any) {
    this.bsModalRef = this.modalService.show(
      this.config.modalComponent,
      this.config.modalConfig
    );
    this.bsModalRef.content.title = title;
    this.bsModalRef.content.viewModel = viewModel;
    this.bsModalRef.content.crudName = this.config.name;
  }

  private loadData() {
    if (!this.config.data || !this.config.data.getAll) {
      return;
    }

    const params = new PagingQueryModel();
    params.page = this.paging.currentPage;
    params.pageSize = this.paging.pageSize;
    if (this.config.allowSearch) {
      params.search = this.searchValue;
    }

    // this.showLoading();
    this.config.data.getAll(params).subscribe(
      response => {
        // this.hideLoading();
        if (response.results) {
          this.data = response.results;
          this.paging.currentPage = response.pageNumber;
          this.paging.totalRecords = response.totalRecords;
          this.paging.pageSize = response.pageSize;
          this.paging.totalPages = response.totalPages;
        } else {
          this.data = response;
        }
      },
      () => {
        // this.hideLoading();
        this.messageService.showErrorMessage({
          title: this.config.titles.get,
          message: this.config.messages.getError
        });
      }
    );
  }

  private showDefaultDeleteErrorMessage() {
    this.messageService.showErrorMessage({
      title: this.config.titles.delete,
      message: 'There was an error while delete data. Please try again !'
    });
  }

  private subscribe() {
    this.subscriptions.push(
      this.crudService.$saveResult.subscribe(saveData => {
        if (saveData.crudName === this.config.name) {
          this.showSaveMessage(saveData);
          if (saveData.result) {
            this.loadData();
          }
        }
      })
    );
    this.subscriptions.push(
      this.crudService.$create.subscribe((crudConfig: CrudConfigModel) => {
        if (crudConfig.name === this.config.name) {
          this.openItem(0, this.config.titles.create);
        }
      })
    );
    this.subscriptions.push(
      this.crudService.$load.subscribe((crudConfig: CrudConfigModel) => {
        if (crudConfig.name === this.config.name) {
          this.loadData();
        }
      })
    );
  }

  private showSaveMessage(saveData: any) {
    const result = saveData.result;
    const viewModel = saveData.viewModel;
    const isCreate = this.commonService.isCreateMode(viewModel);
    const title = isCreate
      ? this.config.titles.create
      : this.config.titles.edit;
    const messageSuccess = isCreate
      ? this.config.messages.createSuccess
      : this.config.messages.updateSuccess;
    const messageError = isCreate
      ? this.config.messages.createError
      : this.config.messages.updateError;
    if (result) {
      this.messageService.showSuccessMessage({
        title: title,
        message: messageSuccess
      });
    } else {
      this.messageService.showErrorMessage({
        title: title,
        message: messageError
      });
    }
  }
}
