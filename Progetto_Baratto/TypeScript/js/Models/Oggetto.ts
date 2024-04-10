export class Oggetto{
    private nome: string;
    private descrizione : string | undefined;
    private codice : string;

    constructor(nome: string, codice: string, descrizione?: string){
        this.nome = nome;
        this.descrizione = descrizione;
        this.codice = codice;
    }

    stampa() : string{
        return `${this.codice}: ${this.nome} | ${this.descrizione}`;
    }
}