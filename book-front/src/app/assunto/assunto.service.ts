import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Assunto } from '../models/assunto.model';

@Injectable({
  providedIn: 'root'
})
export class AssuntoService {
  private apiUrl = `${environment.apiBaseUrl}/assunto`;

  constructor(private http: HttpClient) {}

  // Obtém todos os assuntos
  getAssuntos(): Observable<Assunto[]> {
    return this.http.get<Assunto[]>(this.apiUrl);
  }

  // Obtém um assunto pelo ID
  getAssuntoById(id: number): Observable<Assunto> {
    return this.http.get<Assunto>(`${this.apiUrl}/${id}`);
  }

  // Adiciona um novo assunto
  addAssunto(assunto: Assunto): Observable<number> {
    return this.http.post<number>(this.apiUrl, assunto);
  }

  // Atualiza um assunto existente
  updateAssunto(id: number, assunto: Assunto): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, assunto);
  }

  // Exclui um assunto pelo ID
  deleteAssunto(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
