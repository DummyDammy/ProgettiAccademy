import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Status } from '../models/status';
import { Giocatore } from '../models/giocatore';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GiocatoreService {

  url : string = `https://localhost:7022/giocatore`;

  constructor(private http: HttpClient) { }

  GetAll() : Observable<Status>{
    return this.http.get<Status>(`${this.url}`);
  }

  DeleteByColor(colore : string) : Observable<Status>{
    return this.http.delete<Status>(`${this.url}/${colore}`);
  }

  Insert(body : Giocatore) : Observable<Status>{
    let httpHeader = new HttpHeaders();
    httpHeader.set("Content-Type","application/json")
    return this.http.post<Status>(`${this.url}`, body, {headers: httpHeader});
  }
}
