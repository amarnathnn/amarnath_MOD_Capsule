import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MentortrainingComponent } from './mentortraining.component';

describe('MentortrainingComponent', () => {
  let component: MentortrainingComponent;
  let fixture: ComponentFixture<MentortrainingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MentortrainingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MentortrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
