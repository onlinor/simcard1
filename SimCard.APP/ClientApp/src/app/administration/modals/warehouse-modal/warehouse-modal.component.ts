import { Component, OnInit } from '@angular/core';
import { BaseModalComponent } from '../../../core/base';
import { BsModalRef } from 'ngx-bootstrap';
import { WarehouseService } from '../../../core/services';
import { Validators } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-warehouse-modal',
  templateUrl: './warehouse-modal.component.html',
  styleUrls: ['./warehouse-modal.component.scss']
})
export class WarehouseModalComponent extends BaseModalComponent implements OnInit  {

  constructor(
    private bsModalRef: BsModalRef,
    private warehouseService: WarehouseService
  ) {
    super();
    this.viewModel = {warehouse: {}};
  }

  ngOnInit() {
    super.ngOnInit();
    this.initForm();
  /*   setTimeout(() => {
      this.initFormValue();
    }); */
  }

  protected closeModal(): void {
    this.bsModalRef.hide();
  }

  protected saveObservable(viewModel: any): Observable<any> {
/*     if (viewModel !== null && viewModel.warehouse !== null) {
      return this.warehouseService.saveWarehouse(viewModel);
    } else {

    } */
    return this.warehouseService.save(viewModel);
  }

  save() {
    super.save();
  }

  cancel() {
    this.closeModal();
  }

  private initForm() {
    this.modalForm = this.formBuilder.group({
      id: 0,
      warehouse: this.formBuilder.group(
        {
          id: 0,
          name: [null, Validators.required],
          note: [null, Validators.required]
        }
      )
    });
  }

/*   private initFormValue() {
    this.modalForm.patchValue(this.viewModel);
  } */
}
