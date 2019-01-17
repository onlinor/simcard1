/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FormphieuthuComponent } from './formphieuthu.component';

describe('FormphieuthuComponent', () => {
  let component: FormphieuthuComponent;
  let fixture: ComponentFixture<FormphieuthuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormphieuthuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormphieuthuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
