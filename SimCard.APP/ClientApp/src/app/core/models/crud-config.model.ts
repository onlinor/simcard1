import { ModalOptions } from 'ngx-bootstrap';

import { CrudColumnType, CrudColumnTypeValue } from '../enums';

export class CrudConfigModel {
  name: string;
  allowCreate?: boolean;
  allowEdit?: boolean;
  allowDelete?: boolean;
  allowSearch?: boolean;
  allowCustomCreate?: boolean;
  allowCustomEdit?: boolean;
  allowCustomDelete?: boolean;
  showActionColumn?: boolean;
  modalComponent?: any;
  modalConfig?: ModalOptions;
  columns: CrudColumnModel[];
  titles: {
    create?: string;
    edit?: string;
    delete?: string;
    get?: string;
  };
  messages: {
    deleteConfirm?: string;
    deleteSuccess?: string;
    updateSuccess?: string;
    createSuccess?: string;
    deleteError?: string;
    createError?: string;
    updateError?: string;
    getError?: string;
  };
  events: {
    getItemsCallback?: Function;
    addCallback?: Function;
    updateCallback?: Function;
    deleteCallback?: Function;
  };
  data: {
    getAll?;
    getById?;
    create?;
    update?;
    delete?;
  };
  permission: {
    create?: string;
    delete?: string;
    edit?: string;
  };

  constructor(entity: string) {
    entity = entity || 'item';
    this.name = 'crud';
    this.allowCreate = true;
    this.allowEdit = true;
    this.allowDelete = true;
    this.allowSearch = true;
    this.showActionColumn = true;
    this.allowCustomCreate = false;
    this.allowCustomEdit = false;
    this.allowCustomDelete = false;
    this.permission = {};
    this.columns = [];

    this.modalConfig = { class: 'modal-lg', ignoreBackdropClick: true };

    this.titles = {
      create: `Create New ${entity}`,
      edit: `Edit ${entity}`,
      delete: `Delete ${entity}`,
      get: `Get Data`
    };

    this.messages = {
      deleteConfirm: `Do you really want to delete this ${entity}?`,
      deleteSuccess: `The ${entity} deleted successfully.`,
      updateSuccess: `The ${entity} updated successfully.`,
      createSuccess: `The ${entity} created successfully.`,
      deleteError: `There was an error while deleting data.`,
      createError: `There was an error while adding data.`,
      updateError: `There was an error while updating data.`,
      getError: `There was an error while getting data.`
    };
    this.events = {};
    this.data = {
      getAll: null,
      getById: null,
      create: null,
      update: null,
      delete: null
    };
  }
}

export class CrudColumnModel {
  name: string;
  text: string;
  type?: CrudColumnType;
  actionName?: string;
  typeValue?: CrudColumnTypeValue;
  indexValue?: number;
  keyValue?: string;
  cssClass?: string;
}
