/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DebtbookComponent } from './debtbook.component';

describe('DebtbookComponent', () => {
  let component: DebtbookComponent;
  let fixture: ComponentFixture<DebtbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DebtbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DebtbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
