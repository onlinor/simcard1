/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BankbookComponent } from './bankbook.component';

describe('BankbookComponent', () => {
  let component: BankbookComponent;
  let fixture: ComponentFixture<BankbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BankbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BankbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
