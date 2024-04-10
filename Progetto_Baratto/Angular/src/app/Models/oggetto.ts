export class Oggetto {
    private nome: string | undefined;
    private descrizione : string | undefined;
    private codice : string;

    constructor(nome?: string, descrizione?: string){
        this.nome = nome;
        this.descrizione = descrizione;
        this.codice = Math.random().toString(36).substring(2,10).toUpperCase();
    }

    stampa() : string{
        return `${this.codice}: ${this.nome} | ${this.descrizione}`;
    }
}
