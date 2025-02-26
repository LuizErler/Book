import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output, ViewChild } from '@angular/core';
import { LivroTabelaComponent } from './livro-tabela/livro-tabela.component';
import { LivroService } from './livro.service';
import { Livro } from '../models/livro.model';
import { Autor } from '../models/autor.model';
import { Assunto } from '../models/assunto.model';
import { AutorService } from '../autor/autor.service';
import { AssuntoService } from '../assunto/assunto.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-livro',
  standalone: true, // ✅ Confirma que é standalone
  imports: [CommonModule,LivroTabelaComponent,FormsModule],
   providers: [LivroService,AutorService,AssuntoService,LivroTabelaComponent],
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.css'],
})
export class LivroComponent {

  livro: Livro = { codl: 0, titulo: '', valor: 0, autorId: 0, assuntoId: 0 };
  autores: Autor[] = [];
  assuntos: Assunto[] = [];

  @ViewChild(LivroTabelaComponent) livroTabelaComponent!: LivroTabelaComponent;

  constructor(
    private livroService: LivroService,
    private autorService: AutorService,
    private assuntoService: AssuntoService
  ) {}
  ngOnInit(): void {
    this.autorService.getAutors().subscribe((data) => {
      this.autores = data;
    });

    this.assuntoService.getAssuntos().subscribe((data) => {
      this.assuntos = data;
    });
  }

  onSubmit(form: any): void {
    if (form.valid) {
      this.livroService.addLivro(this.livro).subscribe(() => {
        console.log('Livro cadastrado com sucesso!');
        this.livroTabelaComponent.refresh(); // Emitir evento após o cadastro
        form.reset();
      });
    }
  }
}

