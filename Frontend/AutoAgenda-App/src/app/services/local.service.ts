import { Evento } from './../models/Evento';
import { Local } from './../models/Local';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class LocalService {
  baseURL = `https://localhost:7108/v1/locais`;

  constructor(private http: HttpClient) {}

  public getLocais(): Observable<Local[]> {
    return this.http.get<Local[]>(this.baseURL);
  }

  public getLocalById(id: number): Observable<Local> {
    return this.http.get<Local>(`${this.baseURL}/${id}`);
  }

  public postLocal(Local: Local): Observable<Local> {
    return this.http.post<Local>(this.baseURL, Local);
  }

  public putLocal(id: number, Local: Local): Observable<Local> {
    return this.http.put<Local>(`${this.baseURL}/${id}`, Local);
  }

  public deleteLocal(id: number): Observable<string> {
    return this.http.delete<string>(`${this.baseURL}/${id}`);
  }
}
