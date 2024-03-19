# Programma di gestione edicola

## Prima di iniziare cambiare i percorsi file nella classe edicola con percorsi personalizzati

Programma che gestisce attraverso documenti di testo un database di pubblicazioni, clienti e vendite.

# Manuale d'uso

Usare i numeri del tastierino numerico per muoversi tra i menu.
Per tutti i menu va bene qualsiasi input che non è un numero per tornare indietro, ma nel menu principale solo lo 0 esce dall'applicazione

## Menu principale
0. Esci
1. [Gestione inventario](#1-gestione-inventario)
2. [Gestione vendite](#2-gestione-vendite)
3. [Ricerca e filtraggio](#3-ricerca-e-filtraggio)
4. [Gestione sottoscrizioni](#4-gestione-sottoscrizioni)

***

### 1. Gestione inventario
Questo menu serve a gestire le pubblicazioni e l'inventario

0. [Torna indietro](#menu-principale)
1. [Aggiungi pubblicazione](#1-aggiungi-pubblicazione)
2. [Rimuovi pubblicazione](#2-rimuovi-pubblicazione)
3. [Aggiorna stock pubblicazione](#3-aggiorna-stock-pubblicazione)
4. [Visualizza inventario](#4-visualizza-inventario)
5. [Svuota inventario](#5-svuota-inventario)

#### 1. Aggiungi pubblicazione
Per aggiungere un giornale o una rivista

0. [Torna indietro](#1-gestione-inventario)
1. Aggiungi pubblicazione
2. Rimuovi pubblicazione

Il programma chiederà in input i dati necessari per inserire la pubblicazione

#### 2. Rimuovi pubblicazione
Per rimuovere una pubblicazione attraverso un __ID__ in input

0. [Torna indietro](#1-gestione-inventario)
1. Rimuovi una pubblicazione()

#### 3. Aggiorna stock pubblicazione
Per aggiornare la quantità in stock di una pubblicazione con l'uso di un __ID__ in input

0. [Torna indietro](#1-gestione-inventario)
1. Aggiorna pubblicazione

#### 4. Visualizza inventario
Stampa su console l'inventario corrente

#### 5. Svuota inventario
Per svuotare il database dell'intero inventario

0. Annulla
1. Procedi

***

### 2. Gestione vendite
Questo menu serve a gestire le vendite di pubblicazioni

0. [Torna indietro](#menu-principale)
1. [Vendita di pubblicazioni](#1-vendita-di-pubblicazioni)
2. [Visualizza storico vendite](#2-visualizza-storico-vendite)

#### 1. Vendita di pubblicazioni
Per vendere una pubblicazione con l'uso di un __ID__ in input

0. [Torna indietro](#2-gestione-vendite)
1. Vendi una pubblicazione

#### 2. Visualizza storico vendite
Stampa su console uno storico delle vendite effettuate

***

### 3. Ricerca e filtraggio
Questo menu serve a utlizzare le funzioni di ricerca e per filtrare in ordine di stockaggio

0. [Torna indietro](#menu-principale)
1. [Cerca per termine specifico](#1-cerca-per-termine-specifico)
2. [Cerca per termine generale](#2-cerca-per-termine-generale)
3. [Visualizza elenco ordinato per stock](#3-visualizza-elenco-ordinato-per-stock)

#### 1. Cerca per termine specifico
Per cercare una pubblicazione attraverso titolo, categoria o redazione (solo per i giornali)

0. [Torna indietro](#3-ricerca-e-filtraggio)
1. Per titolo
2. Per categoria
3. Per redazione

#### 2. Cerca per termine generale
Chiede in input un qualsiasi termine e stampa su console tuttle le pubblicazioni a cui corrsiponde quel termine nel __titolo__ o __categoria__

#### 3. Visualizza elenco ordinato per stock
Stampa su console un elenco ordinato in modo decrescente di pubblicazioni disponibili per stock

***

### 4. Gestione sottoscrizioni
Questo menu serve a gestire i clienti e le loro sottoscrizioni

0. [Torna indietro](#menu-principale)
1. [Aggiungi sottoscrizione](#1-aggiungi-sottoscrizione)
2. [Rimuovi sottoscrizione](#2-rimuovi-sottoscrizione)
3. [Visualizza programma sottoscrizioni](#3-visualizza-programma-sottoscrizoni)

#### 1. Aggiungi sottoscrizione
Per aggiungere una sottoscrizione di un nuovo o vecchio cliente. La sottoscrizione viene aggiunta con un __ID__ in input di una pubblicazione __già presente nel database__

0. [Torna indietro](#4-gestione-sottoscrizioni)
1. Inserisci nuovo cliente
2. Aggiungi sottoscrizione a cliente esistente

#### 2. Rimuovi sottoscrizione
Per rimuovere una sottoscrizione con l'uso di un __ID__ in input __sia che per il cliente che per la pubblicazione__

Inserire un id errato annullererà l'operazione

#### 3. Visualizza programma sottoscrizoni
Stampa su console un elenco dei clienti e di quante sottoscrizioni hanno attive
