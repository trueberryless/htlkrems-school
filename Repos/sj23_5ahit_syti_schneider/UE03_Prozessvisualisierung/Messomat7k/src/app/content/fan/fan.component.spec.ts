import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FanComponent } from './fan.component';

describe('FanComponent', () => {
  let component: FanComponent;
  let fixture: ComponentFixture<FanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FanComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
