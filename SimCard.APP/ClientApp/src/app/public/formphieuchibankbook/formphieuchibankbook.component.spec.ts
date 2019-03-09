/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FormphieuchibankbookComponent } from './formphieuchibankbook.component';

describe('FormphieuchibankbookComponent', () => {
  let component: FormphieuchibankbookComponent;
  let fixture: ComponentFixture<FormphieuchibankbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormphieuchibankbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormphieuchibankbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
