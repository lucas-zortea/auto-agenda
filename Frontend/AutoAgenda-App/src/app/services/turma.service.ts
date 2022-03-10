import { Turma } from './../models/Turma';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class LocalService {
  baseURL = `https://localhost:7108/v1/turmas`;

  constructor(private http: HttpClient) {}

  public getLocais(): Observable<Turma[]> {
    return this.http.get<Turma[]>(this.baseURL);
  }

  public getLocalById(id: number): Observable<Turma> {
    return this.http.get<Turma>(`${this.baseURL}/${id}`);
  }

  public postLocal(Turma: Turma): Observable<Turma> {
    return this.http.post<Turma>(this.baseURL, Turma);
  }

  public putLocal(id: number, Turma: Turma): Observable<Turma> {
    return this.http.put<Turma>(`${this.baseURL}/${id}`, Turma);
  }

  public deleteLocal(id: number): Observable<string> {
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }
}
