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

  getAssuntos(): Observable<Assunto[]> {
    return this.http.get<Assunto[]>(this.apiUrl);
  }

  getAssuntoById(id: number): Observable<Assunto> {
    return this.http.get<Assunto>(`${this.apiUrl}/${id}`);
  }

  addAssunto(assunto: Assunto): Observable<number> {
    return this.http.post<number>(this.apiUrl, assunto);
  }

  updateAssunto(id: number, assunto: Assunto): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, assunto);
  }

  deleteAssunto(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
