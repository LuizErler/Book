import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon'; 
import { MatSort, MatSortModule } from '@angular/material/sort';  
import { MatTableDataSource } from '@angular/material/table'; 
import { HttpClientModule } from '@angular/common/http'; 
import { LivroService } from '../livro.service';
import { Livro } from '../../models/livro.model';
import { Autor } from '../../models/autor.model';
import { Assunto } from '../../models/assunto.model';
import { AssuntoService } from '../../assunto/assunto.service';
import { AutorService } from '../../autor/autor.service';

@Component({
  selector: 'app-livro-tabela',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatPaginatorModule, HttpClientModule, MatIconModule, MatSortModule], 
  providers: [LivroService,AutorService,AssuntoService],
  templateUrl: './livro-tabela.component.html',
  styleUrls: ['./livro-tabela.component.css']
})
export class LivroTabelaComponent implements OnInit {
  displayedColumns: string[] = ['titulo', 'autor', 'editora', 'edicao', 'anoPublicacao', 'valor', 'deletar'];
  livrosDataSource = new MatTableDataSource<Livro>([]); 
    autores: Autor[] = [];
    assuntos: Assunto[] = [];

  @ViewChild(MatPaginator) paginator: MatPaginator | undefined; 
  @ViewChild(MatSort) sort: MatSort | undefined; 

  constructor(private livroService: LivroService,
              private autorService: AutorService,
              private assuntoService: AssuntoService) {}

  ngOnInit(): void {
    this.autorService.getAutors().subscribe((data) => {
      this.autores = data;
    });

    this.assuntoService.getAssuntos().subscribe((data) => {
      this.assuntos = data;
    });

    this.carregarLivros();
  }
  ngAfterViewInit() {
    if (this.paginator) {
      this.livrosDataSource.paginator = this.paginator;
    }
  }

  carregarLivros(): void {
    this.livroService.getLivros().subscribe(
      (data) => {
        this.livrosDataSource.data = data;
        if (this.sort) {
          this.livrosDataSource.sort = this.sort; 
        }
        if (this.paginator) {
          this.livrosDataSource.paginator = this.paginator;
        }
      },
      (error) => {
        console.error('Erro ao carregar Livros:', error);
      }
    );
  }

  public refresh(): void {
    this.carregarLivros(); 
  }

  deleteLivro(codl: number): void {
    this.livroService.deleteLivro(codl).subscribe(() => {
      this.carregarLivros();
    });
  }

  exibeAutor(idsAutores: string): string {
    if (!idsAutores) return 'Autor não encontrado'; 
  
    const autorIds = idsAutores.split(',').map(id => parseInt(id.trim(), 10));
    
    const autoresEncontrados = this.autores.filter(a => autorIds.includes(a.codAu));
  
    return autoresEncontrados.map(a => a.nome).join(', ') || 'Autor não encontrado';
  }
  
  getPaginatorData() {
    return this.livrosDataSource.filteredData.slice(
      (this.paginator?.pageIndex || 0) * (this.paginator?.pageSize || 5),
      (this.paginator?.pageIndex || 0) * (this.paginator?.pageSize || 5) + (this.paginator?.pageSize || 5)
    );
  }
}
