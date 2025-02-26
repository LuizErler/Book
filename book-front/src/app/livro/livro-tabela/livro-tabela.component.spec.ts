import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LivroTabelaComponent } from './livro-tabela.component';

describe('LivroTabelaComponent', () => {
  let component: LivroTabelaComponent;
  let fixture: ComponentFixture<LivroTabelaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LivroTabelaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LivroTabelaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
