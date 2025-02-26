import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Livro } from '../models/livro.model'; // Importando a classe Livro

@Injectable({
  providedIn: 'root'
})
export class LivroService {
  private apiUrl = `${environment.apiBaseUrl}/livro`;

  constructor(private http: HttpClient) {}

  // Obtém todos os livros
  getLivros(): Observable<Livro[]> {
    return this.http.get<Livro[]>(this.apiUrl);
  }

  // Obtém um livro pelo ID
  getLivroById(id: number): Observable<Livro> {
    return this.http.get<Livro>(`${this.apiUrl}/${id}`);
  }

  // Adiciona um novo livro
  addLivro(livro: Livro): Observable<number> {
    return this.http.post<number>(this.apiUrl, livro);
  }

  // Atualiza um livro existente
  updateLivro(id: number, livro: Livro): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, livro);
  }

  // Exclui um livro pelo ID
  deleteLivro(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
