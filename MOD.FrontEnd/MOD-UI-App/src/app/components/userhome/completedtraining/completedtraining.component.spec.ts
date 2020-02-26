import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompletedtrainingComponent } from './completedtraining.component';

describe('CompletedtrainingComponent', () => {
  let component: CompletedtrainingComponent;
  let fixture: ComponentFixture<CompletedtrainingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompletedtrainingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompletedtrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
