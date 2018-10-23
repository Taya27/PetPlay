import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyToysComponent } from './my-toys.component';

describe('MyToysComponent', () => {
  let component: MyToysComponent;
  let fixture: ComponentFixture<MyToysComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyToysComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyToysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
