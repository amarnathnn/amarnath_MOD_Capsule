import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchtechnologyComponent } from './searchtechnology.component';

describe('SearchtechnologyComponent', () => {
  let component: SearchtechnologyComponent;
  let fixture: ComponentFixture<SearchtechnologyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchtechnologyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchtechnologyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
