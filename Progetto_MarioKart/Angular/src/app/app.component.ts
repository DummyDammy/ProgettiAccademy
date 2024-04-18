import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Angular';

  giocatoreComponent : boolean = false;
  personagioComponent : boolean = false;

  onGiocatoreComponent(){
    this.personagioComponent = false;
    this.giocatoreComponent = true;
  }

  onPersonagioComponent(){
    this.giocatoreComponent = false;
    this.personagioComponent = true;
  }
}
