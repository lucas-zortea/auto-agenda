/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LocalComponent } from './local.component';

describe('LocalComponent', () => {
  let component: LocalComponent;
  let fixture: ComponentFixture<LocalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LocalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LocalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
