/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FormphieuthubankbookComponent } from './formphieuthubankbook.component';

describe('FormphieuthubankbookComponent', () => {
  let component: FormphieuthubankbookComponent;
  let fixture: ComponentFixture<FormphieuthubankbookComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormphieuthubankbookComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormphieuthubankbookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
