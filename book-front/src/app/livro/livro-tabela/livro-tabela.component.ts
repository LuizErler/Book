import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon'; // Importando o MatPaginator
import { HttpClientModule } from '@angular/common/http'; // Importando o HttpClientModule
import { LivroService } from '../livro.service';
import { Livro } from '../../models/livro.model';

@Component({
  selector: 'app-livro-tabela',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatPaginatorModule, HttpClientModule,MatIconModule ], // Adicionando HttpClientModule aqui
  providers: [LivroService],
  templateUrl: './livro-tabela.component.html',
  styleUrls: ['./livro-tabela.component.css']
})
export class LivroTabelaComponent implements OnInit {
  displayedColumns: string[] = ['codl', 'titulo', 'autor', 'editora', 'edicao', 'anoPublicacao', 'valor', 'deletar'];
  livros: Livro[] = []; // Array de livros

  @ViewChild(MatPaginator) paginator: MatPaginator | undefined; // Referência do paginator

  constructor(private livroService: LivroService) {}

  ngOnInit(): void {
    this.carregarLivros();
  }

  carregarLivros(): void {
    this.livroService.getLivros().subscribe(
      (data) => {
        this.livros = data;
      },
      (error) => {
        console.error('Erro ao carregar Livros:', error);
      }
    );
  }

 public refresh(): void {
    this.carregarLivros(); // Recarregar a lista de livros
  }

  deleteLivro(codl: number): void {
    // Chama o serviço para deletar o livro com o codl informado
    this.livroService.deleteLivro(codl).subscribe(() => {
      // Recarrega a lista após a exclusão
      this.carregarLivros();
    });
  }

  // Método para obter os dados para a tabela com base na paginação
  getPaginatorData() {
    return this.livros.slice(
      (this.paginator?.pageIndex || 0) * (this.paginator?.pageSize || 5),
      (this.paginator?.pageIndex || 0) * (this.paginator?.pageSize || 5) + (this.paginator?.pageSize || 5)
    );
  }
}
