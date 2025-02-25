import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuCadastrosComponent } from './menu-cadastros.component';

describe('MenuCadastrosComponent', () => {
  let component: MenuCadastrosComponent;
  let fixture: ComponentFixture<MenuCadastrosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MenuCadastrosComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MenuCadastrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
