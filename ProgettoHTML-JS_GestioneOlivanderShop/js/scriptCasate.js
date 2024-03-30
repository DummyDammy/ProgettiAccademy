const salvaCasata = () => {
    let nome = document.getElementById("inserimento_nome").value;
    let descrizione = document.getElementById("inserimento_descrizione").value;
    let urlImmagine = document.getElementById("inserimento_immagine").value;

    let casata = {
        nome,
        descrizione,
        urlImmagine
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

    stampa();

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
            <td class="text-right">
                <button class="btn btn-warning" onclick="modificaCasata(${idx})">
                    <i class="fa-solid fa-pencil"></i>
                </button>
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

const modificaCasata = (idx) => {

    let elenco = JSON.parse(localStorage.getItem('lista_casate'));

    document.getElementById("update_nome").value = elenco[idx].nome;
    document.getElementById("update_descrizione").value = elenco[idx].descrizione;
    document.getElementById("update_immagine").value = elenco[idx].urlImmagine;

    $("#modaleAggiornamentoCasata").data("identificativo", idx)

    $("#modaleAggiornamentoCasata").modal("show");
}

const updateCasata = () => {
    let nome = document.getElementById("update_nome").value;
    let descrizione = document.getElementById("update_descrizione").value;
    let urlImmagine = document.getElementById("update_immagine").value;

    let casata = {
        nome,
        descrizione,
        urlImmagine
    }

    let indice = $("#modaleAggiornamentoCasata").data("identificativo")

    let elenco = JSON.parse( localStorage.getItem('lista_casate') );
    elenco[indice] = casata;
    localStorage.setItem('lista_casate', JSON.stringify(elenco));

    $("#modaleAggiornamentoCasata").modal("hide");
}

let listaCasate = localStorage.getItem('lista_casate');
if(!listaCasate)
    localStorage.setItem('lista_casate', JSON.stringify([]) );

setInterval(() => {
    stampaCasate(); 
}, 1000);

stampaCasate();