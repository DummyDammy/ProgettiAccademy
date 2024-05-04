import { Component } from '@angular/core';
import { UtenteService } from '../../services/utente.service';
import { Router } from '@angular/router';
import { Utente } from '../../models/utente';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {


  nickname : string | undefined;
  password : string | undefined;
  email : string | undefined;

  constructor(private service : UtenteService, private auth : AuthenticationService, private router : Router){}

  annulla(){
      this.nickname = "";
      this.email = "";
      this.password = "";
  }

  login(){
    let utente : Utente = new Utente();
    utente.post = this.email;
    utente.password = this.password;

    this.auth.login(utente).subscribe((ris) => {
      if (ris.token){
        console.log(ris.token);
        localStorage.setItem(`Token`, ris.token);
        localStorage.setItem(`Nickname`, ris.nickname!); 
        this.router.navigateByUrl(`/profilo/home`);
      }
    })
  }

  register(){
    let utente : Utente = new Utente();
    utente.nick = this.nickname;
    utente.post = this.email;
    utente.password = this.password;
    this.service.Insert(utente).subscribe(ris => {
      if (ris.data == false){
      }
    });
    this.nickname = "";
    this.email = "";
    this.password = "";
  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    
  }
}
