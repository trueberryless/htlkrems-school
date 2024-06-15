import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FindingsComponent } from './findings.component';

describe('FindingsComponent', () => {
  let component: FindingsComponent;
  let fixture: ComponentFixture<FindingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FindingsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FindingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
