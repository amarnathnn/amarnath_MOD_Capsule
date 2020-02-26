import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MentornotificatonComponent } from './mentornotificaton.component';

describe('MentornotificatonComponent', () => {
  let component: MentornotificatonComponent;
  let fixture: ComponentFixture<MentornotificatonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MentornotificatonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MentornotificatonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
