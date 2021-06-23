import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomtypedetailComponent } from './roomtypedetail.component';

describe('RoomtypedetailComponent', () => {
  let component: RoomtypedetailComponent;
  let fixture: ComponentFixture<RoomtypedetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomtypedetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomtypedetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
