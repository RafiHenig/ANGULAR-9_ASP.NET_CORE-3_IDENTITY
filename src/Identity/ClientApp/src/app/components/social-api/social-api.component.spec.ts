import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SocialApiComponent } from './social-api.component';

describe('SocialApiComponent', () => {
  let component: SocialApiComponent;
  let fixture: ComponentFixture<SocialApiComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SocialApiComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SocialApiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
