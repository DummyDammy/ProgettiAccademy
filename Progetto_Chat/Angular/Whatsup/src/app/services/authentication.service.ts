import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Utente } from '../models/utente';
import { Risposta } from '../models/risposta';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  url : string = `https://localhost:7261/api/utente`;

  constructor(private http : HttpClient) { }

  login(body : Utente): Observable<Risposta>{
    let httpHeader = new HttpHeaders();
    httpHeader.set("Content-Type","application/json");
    return this.http.post<Risposta>(`${this.url}/login`, body, {headers: httpHeader,});
  }
}
