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
  standalone: true, 
  imports: [CommonModule,LivroTabelaComponent,FormsModule],
   providers: [LivroService,AutorService,AssuntoService,LivroTabelaComponent],
  templateUrl: './livro.component.html',
  styleUrls: ['./livro.component.css'],
})
export class LivroComponent {

  livro: Livro = { codl: 0, titulo: '', valor: 0, autorIds: [], anoPublicacao:'', assuntoIds: [] };
  autores: Autor[] = [];
  assuntos: Assunto[] = [];
  anoAtual = new Date().getFullYear();
  showForm: boolean = true;

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

  validarAnoPublicacao(ano: any): void {
    const anoNum = parseInt(ano, 10); 
  
    if (isNaN(anoNum) || anoNum < 1) {
      this.livro.anoPublicacao = '1';
    } else if (anoNum > this.anoAtual) {
      this.livro.anoPublicacao = this.anoAtual.toString();
    } else if (ano.length > 4) {
      this.livro.anoPublicacao = ano.slice(0, 4);
    }
  
    this.livro.anoPublicacao = this.livro.anoPublicacao.padStart(4, '0');
  }

  somenteNumeros(event: any): void {
    let valor = event.target.value;

  if (valor.startsWith('0') && valor.length > 1) {
    valor = valor.substring(1);
  }

  event.target.value = valor.replace(/[^0-9.]/g, '');  
  this.livro.valor = valor; 
}
toggleForm(): void {
  this.showForm = !this.showForm;
}

  
  onSubmit(form: any): void {
    if (form.valid) {
      this.livroService.addLivro(this.livro).subscribe(() => {
        alert('Livro cadastrado com sucesso!');
        this.livroTabelaComponent.refresh(); 
        form.reset();
      },
      (error) => {
        alert('Erro ao cadastrar livro.');
        console.error(error);
      }
    );
  }
}
}
