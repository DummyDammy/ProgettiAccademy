import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Status } from '../models/status';
import { Personaggio } from '../models/personaggio';

@Injectable({
  providedIn: 'root'
})
export class PersonaggioService {

  url : string = `https://localhost:7022`
  endpoint : string = `/personaggio`

  constructor(private http:HttpClient) { }
}
