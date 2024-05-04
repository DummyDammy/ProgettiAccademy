import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Status } from '../models/status';
import { Stanza } from '../models/stanza';
import { Messaggio } from '../models/messaggio';

@Injectable({
  providedIn: 'root'
})
export class ProfiloService {

  url : string = `https://localhost:7261/api/stanza`;

  constructor(private http : HttpClient) { }

  getStanze(nickname : string) : Observable<Status>{
    return this.http.get<Status>(`${this.url}/${nickname}`);
  }

  createRoom(stanza : Stanza) : Observable <Status>{
    let httpHeader = new HttpHeaders();
    httpHeader.set("Content-Type","application/json")
    return this.http.post<Status>(`${this.url}/create`, stanza, {headers: httpHeader}); 
  }

  getStanzeCreate(nickname : string) : Observable<Status>{
    return this.http.get<Status>(`${this.url}/admin/${nickname}`);
  }

  deleteStanza(titolo : string) : Observable<Status>{
    return this.http.delete<Status>(`${this.url}/${titolo}`);
  }

  getStanzePartecipante(nickname : string) : Observable<Status>{
    return this.http.get<Status>(`${this.url}/partecipante/${nickname}`);
  }

  leaveRoom(stanza : Stanza, nickname : string) : Observable <Status>{
    let httpHeader = new HttpHeaders();
    httpHeader.set("Content-Type","application/json")
    return this.http.post<Status>(`${this.url}/remove/${nickname}`, stanza, {headers: httpHeader}); 
  }

  pushRoom(titolo : string) : Observable <Status>{
    return this.http.get<Status>(`${this.url}/title/${titolo}`);
  }

  sendMessage(messaggio : Messaggio, titolo : string, nickname : string){
    let httpHeader = new HttpHeaders();
    httpHeader.set("Content-Type","application/json")
    return this.http.post<Status>(`https://localhost:7261/api/messaggio/${nickname}/${titolo}`, messaggio, {headers: httpHeader}); 
  }
}
