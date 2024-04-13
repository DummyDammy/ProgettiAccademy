import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GiocatoreService {

  url : string = `https://localhost:7022`
  endpoint : string = `/giocatore`

  constructor(private http: HttpClient) { }
}
