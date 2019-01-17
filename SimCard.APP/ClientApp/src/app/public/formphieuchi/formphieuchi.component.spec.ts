/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FormphieuchiComponent } from './formphieuchi.component';

describe('FormphieuchiComponent', () => {
  let component: FormphieuchiComponent;
  let fixture: ComponentFixture<FormphieuchiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormphieuchiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormphieuchiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
