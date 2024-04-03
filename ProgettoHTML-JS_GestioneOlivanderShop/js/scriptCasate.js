const salvaCasata = () => {
    let nome = document.getElementById("inserimento_nome").value;
    let descrizione = document.getElementById("inserimento_descrizione").value;
    let urlImmagine = document.getElementById("inserimento_immagine").value;
    let quantita = 0;

    let casata = {
        nome,
        descrizione,
        urlImmagine,
        quantita
    }

    let controllo = true;
    
    let elenco = JSON.parse(localStorage.getItem('lista_casate'));

    for (let item of elenco.entries()){
        if (item.nome == nome)
            controllo = false;
    }

    if (controllo)
    {
    elenco.push(casata);
    localStorage.setItem('lista_casate', JSON.stringify(elenco));

    document.getElementById("inserimento_nome").value = "";
    document.getElementById("inserimento_descrizione").value = "";
    document.getElementById("inserimento_immagine").value = "";

    stampaCasate();

    $("#modaleInserimentoCasata").modal("hide");
    }

    else
        alert(`Nome ${nome} già usato`)
}

const stampaCasate = () => {
    let elenco = JSON.parse(localStorage.getItem('lista_casate'));

    let stringa = '';
    for(let [idx, item] of elenco.entries()){
        stringa += `
        <tr>
            <td>${idx + 1}</td>
            <td>${item.nome}</td>
            <td>${item.descrizione}</td>
            <td><img src="${item.urlImmagine}"></td>
            <td>${item.quantita}</td>
            <td class="text-right">
                <button class="btn btn-danger" onclick="eliminaCasata(${idx})">
                    <i class="fa-solid fa-trash"></i>
                </button>
            </td>
        </tr>`;
    }

    document.getElementById("corpo_tabella_casate").innerHTML = stringa;
}

const eliminaCasata = (indice) => {
    let elenco = JSON.parse( localStorage.getItem('lista_casate') );
    elenco.splice(indice, 1);
    localStorage.setItem('lista_casate', JSON.stringify(elenco));

    stampaCasate();
}

let listaCasate = localStorage.getItem('lista_casate');
if(!listaCasate){
    let elenco = [];
    let grifondoro = {
        nome : `Grifondoro`,
        descrizione : `Grifondoro apprezza il coraggio, l'audacia e la cavalleria. Il suo animale emblematico è il leone e i suoi colori sono scarlatto e oro. Minerva McGranitt è il più recente capo di Grifondoro.`,
        urlImmagine : `/assets/Grifondoro.png`,
        quantita : 0
    };
    elenco.push(grifondoro);

    let tassorosso = {
        nome: `Tassorosso`,
        descrizione: `Tassorosso apprezza il duro lavoro, la dedizione, la pazienza, la lealtà ed il fair play. Il suo animale emblematico è il tasso e giallo e nero sono i suoi colori. Pomona Sprite è stata a capo di Tassorosso nel periodo 1991-1998.`,
        urlImmagine: `/assets/Tassorosso.png`,
        quantita : 0
    };
    elenco.push(tassorosso);

    let corvonero = {
        nome : `Corvonero`,
        descrizione : `Corvonero apprezza l'intelligenza, la conoscenza, la curiosità, la creatività e l'arguzia. Il suo animale emblematico è l'aquila e i suoi colori sono il blu e il bronzo. Il capo della Casa di Corvonero negli anni '90 era Filius Vitious.`,
        urlImmagine : `/assets/Corvonero.png`,
        quantita : 0
    };
    elenco.push(corvonero);

    let serpeverde = {
        nome : `Serpeverde`,
        descrizione : `Serpeverde apprezza l'ambizione, la leadership, l'autoconservazione, l'astuzia e l'intraprendenza ed è stata fondata da Salazar Serpeverde. Il suo animale emblematico è il serpente, e i suoi colori sono il verde smeraldo e l'argento.] Il professor Horace Lumacorno è stato il capo di Serpeverde durante l'anno scolastico 1997-1998.`,
        urlImmagine : `/assets/Serpeverde.png`,
        quantita : 0
    };
    elenco.push(serpeverde);
    localStorage.setItem('lista_casate', JSON.stringify(elenco) );
}
    

setInterval(() => {
    stampaCasate(); 
}, 1000);

stampaCasate();