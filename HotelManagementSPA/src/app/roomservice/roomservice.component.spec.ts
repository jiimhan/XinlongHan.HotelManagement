import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoomserviceComponent } from './roomservice.component';

describe('RoomserviceComponent', () => {
  let component: RoomserviceComponent;
  let fixture: ComponentFixture<RoomserviceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoomserviceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoomserviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
