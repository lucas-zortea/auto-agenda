import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Local } from '../models/Local';

@Injectable()
export class LocalService {
baseURL = `https://localhost:7108/v1/locais`;

constructor(private http: HttpClient) { }

public getLocais(): Observable<Local[]>{
  return this.http.get<Local[]>(this.baseURL);
}

public getLocalById(id: number): Observable<Local>{
  return this.http.get<Local>(`${this.baseURL}/${id}`)
}

}
