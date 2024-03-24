# Programma di gestione eventi

## Prima di iniziare cambiare i percorsi file nella classe Sottomenu con percorsi personalizzati

__Il prgramma salva 3 file CSV sui percorsi specificati (Eventi.txt, Partecipanti.txt, Risorse.txt), ma non c'è ancora modo di leggerli__

***
Programma che gestisce attraverso database informazioni relative ad eventi.

# Manuale d'uso

Usare i numeri del tastierino numerico per muoversi tra i menu.
Per tutti i menu va bene qualsiasi input che non è un numero per tornare indietro, ma nel menu principale solo lo 0 esce dall'applicazione

## Menu principale
0. Esci
1. [Gestione eventi](#1-gestione-eventi)
2. [Gestione partecipanti](#2-gestione-partecipanti)
3. [Gestione risorse](#3-ricerca-e-filtraggio)

***

### 1. Gestione eventi
Questo menu serve a gestire gli eventi nel database

0. [Torna indietro](#menu-principale)
1. [Aggiungi evento](#1-aggiungi-evento)
2. [Rimuovi evento](#2-rimuovi-evento)
3. [Aggiorna evento](#3-aggiorna-evento)
4. [Mostra eventi](#4-mostra-eventi)
5. [Mostra gli eventi e i suoi partecipanti](#5-mostra-gli-eventi-e-i-suoi-partecipanti)
6. [Mostra gli eventi e le risorse](#6-mostra-gli-eventi-e-le-risorse)

#### 1. Aggiungi evento
Per aggiungere un evento nel database

0. [Torna indietro](#1-gestione-eventi)
1. Aggiungi evento

Il programma chiederà in input i dati necessari per inserire la pubblicazione

#### 2. Rimuovi evento
Per rimuovere un evento dal database

0. [Torna indietro](#1-gestione-eventi)
1. Rimuovi evento

#### 3. Aggiorna evento
Per aggiornare i dati di un evento presente nel database utlizzando il suo __ID__

0. [Torna indietro](#1-gestione-eventi)
1. Modifica evento

#### 4. Mostra eventi
Stampa su console la lista degli eventi presenti nel database

#### 5. Mostra gli eventi e i suoi partecipanti
Mostra i partecipanti degli eventi filtrati per nome evento

#### 6. Mostra gli eventi e le risorse
Mostra le risorse utilizzate negli eventi ordinate per nome evento

***

### 2. Gestione partecipanti
Questo menu serve a gestire i partecipanti dei vari eventi

0. [Torna indietro](#menu-principale)
1. [Aggiungi partecipante](#1-aggiungi-partecipante)
2. [Rimuovi partecipante](#2-rimuovi-partecipante)
3. [Assegna partecipante ad evento](#3-assegna-partecipante-ad-evento)
4. [Rimuovi partecipante da evento](#4-rimuovi-partecipante-da-evento)
5. [Mostra lista di tutti i partecipanti per tutti gli eventi](#5-mostra-lista-di-tutti-i-partecipanti-per-tutti-gli-eventi)
6. [Mostra gli eventi e i suoi partecipanti](#6-mostra-gli-eventi-e-i-suoi-partecipanti)
7. [Modifica partecipante per ID](#7-modifica-partecipante-per-id)

#### 1. Aggiungi partecipante
Per aggiungere un partecipante nel database

0. [Torna indietro](#2-gestione-partecipanti)
1. Aggiungi partecipante

#### 2. Rimuovi partecipante
Per rimuovere un partecipante dal database con l'utilizzo del suo __ID__

0. [Torna indietro](#2-gestione-partecipanti)
1. Rimuovi partecipante

#### 3. Assegna partecipante ad evento
Per assegnare un partecipante presente in database ad un evento presente in database

0. [Torna indietro](#2-gestione-partecipanti)
1. Assegna partecipante

#### 4. Rimuovi partecipante da evento
Per rimuovere un partecipante dalla lista dei partecipanti di un evento in database con l'utilizzo del suo __ID__

0. [Torna indietro](#2-gestione-partecipanti)
1. Rimuovi partecipante da evento

#### 5. Mostra lista di tutti i partecipanti per tutti gli eventi
Stampa su console tutti i partecipanti presenti nel database

#### 6. Mostra gli eventi e i suoi partecipanti
Stampa su console tutti i partecipanti e gli eventi a cui partecipano filtrato per nome e cognome del partecipante

#### 7. Modifica partecipante per ID
Per modificare i dati di un partecipante utilizzando il suo __ID__

0. [Torna indietro](#2-gestione-partecipanti)
1. Modifica dati partecipante

***

### 3. Gestione risorse
Questo menu serve a gestire le risorse per i vari eventi

0. [Torna indietro](#menu-principale)
1. [Aggiungi risorsa](#1-aggiungi-risorsa)
2. [Rimuovi risorsa](#2-rimuovi-risorsa)
3. [Modifica risorsa per id](#3-modifica-risorsa-per-id)
4. [Assegna risorsa ad evento](#4-assegna-risorsa-ad-evento)
5. [Mostra tutte le risorse](#5-mostra-tutte-le-risorse)
6. [Mostra gli eventi e le risorse](#6-mostra-gli-eventi-e-le-risorse-1)
7. [Rimuovi risorsa da evento]()

#### 1. Aggiungi risorsa
Per aggiungere una risorsa nel database

0. [Torna indietro](#3-gestione-risorse)
1. Aggiungi risorsa

#### 2. Rimuovi risorsa
Per rimuovere una risorsa dal database con l'utilizzo del suo __ID__

0. [Torna indietro](#3-gestione-risorse)
1. Rimuovi risorsa

#### 3. Modifica risorsa per id
Per modificare i dati di una risorsa presente nel database con l'utilizzo del suo __ID__

0. [Torna indietro](#3-gestione-risorse)
1. Modifica dati risorsa

#### 4. Assegna risorsa ad evento
Per assegnare una risorsa presente nel database ad un evento presente nel database

0. [Torna indietro](#3-gestione-risorse)
1. Assegna risorsa

#### 5. Mostra tutte le risorse
Stampa su console tutte le risorse presenti nel database

#### 6. Mostra gli eventi e le risorse
Stampa su console tutte le risorse e gli eventi in cui vengono utilizzate filtrato per tipo e nome della risorsa

#### 7. Rimuovi risorsa da evento
Per rimuovere l'assegnazione di una risorsa da un evento

0. [Torna indietro](#3-gestione-risorse)
1. Rimuovi risorsa da evento