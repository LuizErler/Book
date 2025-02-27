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

  getLivros(): Observable<Livro[]> {
    return this.http.get<Livro[]>(this.apiUrl);
  }

  getLivroById(id: number): Observable<Livro> {
    return this.http.get<Livro>(`${this.apiUrl}/${id}`);
  }

  addLivro(livro: Livro): Observable<number> {
    return this.http.post<number>(this.apiUrl, livro);
  }

  updateLivro(id: number, livro: Livro): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, livro);
  }

  deleteLivro(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
