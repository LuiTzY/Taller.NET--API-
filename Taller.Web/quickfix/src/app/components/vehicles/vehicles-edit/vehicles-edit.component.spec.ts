import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiclesEditComponent } from './vehicles-edit.component';

describe('VehiclesEditComponent', () => {
  let component: VehiclesEditComponent;
  let fixture: ComponentFixture<VehiclesEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VehiclesEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VehiclesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
