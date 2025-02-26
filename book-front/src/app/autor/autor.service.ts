import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Autor } from '../models/autor.model';

@Injectable({
  providedIn: 'root'
})
export class AutorService {
  private apiUrl = `${environment.apiBaseUrl}/autor`;

  constructor(private http: HttpClient) {}

  // Obtém todos os autors
  getAutors(): Observable<Autor[]> {
    return this.http.get<Autor[]>(this.apiUrl);
  }

  // Obtém um autor pelo ID
  getAutorById(id: number): Observable<Autor> {
    return this.http.get<Autor>(`${this.apiUrl}/${id}`);
  }

  // Adiciona um novo autor
  addAutor(autor: Autor): Observable<number> {
    return this.http.post<number>(this.apiUrl, autor);
  }

  // Atualiza um autor existente
  updateAutor(id: number, autor: Autor): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, autor);
  }

  // Exclui um autor pelo ID
  deleteAutor(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
