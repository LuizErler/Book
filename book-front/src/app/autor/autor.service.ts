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

  getAutors(): Observable<Autor[]> {
    return this.http.get<Autor[]>(this.apiUrl);
  }

  getAutorById(id: number): Observable<Autor> {
    return this.http.get<Autor>(`${this.apiUrl}/${id}`);
  }

  addAutor(autor: Autor): Observable<number> {
    return this.http.post<number>(this.apiUrl, autor);
  }

  updateAutor(id: number, autor: Autor): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, autor);
  }

  deleteAutor(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
