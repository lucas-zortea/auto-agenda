import { Disciplinas } from './../models/Disciplinas';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class DisciplinaService {
  baseURL = 'https://localhost:7108/v1/disciplinas';

  constructor(private http: HttpClient) { }

  public getDisciplinas(): Observable<Disciplinas[]> {
    return this.http.get<Disciplinas[]>(this.baseURL);
  }

  public getDisciplinasById(id: number): Observable<Disciplinas> {
    return this.http.get<Disciplinas>(`${this.baseURL}/${id}`);
  }

  public postDisciplinas(Disciplinas: Disciplinas): Observable<Disciplinas> {
    return this.http.post<Disciplinas>(this.baseURL, Disciplinas);
  }

  public putDisciplinas(id: number, Disciplinas: Disciplinas): Observable<Disciplinas> {
    return this.http.put<Disciplinas>(`${this.baseURL}/${id}`, Disciplinas);
  }
}
