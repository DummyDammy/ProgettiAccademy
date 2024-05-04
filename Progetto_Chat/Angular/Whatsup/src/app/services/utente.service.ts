import { Injectable } from '@angular/core';
import { Utente } from '../models/utente';
import { Observable } from 'rxjs';
import { Status } from '../models/status';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UtenteService {

  url : string = `https://localhost:7261/api/utente`;

  constructor(private http : HttpClient) { }

  Insert(body : Utente) : Observable<Status>{
    let httpHeader = new HttpHeaders();
    httpHeader.set("Content-Type","application/json")
    return this.http.post<Status>(`${this.url}`, body, {headers: httpHeader});
  }
  
}
