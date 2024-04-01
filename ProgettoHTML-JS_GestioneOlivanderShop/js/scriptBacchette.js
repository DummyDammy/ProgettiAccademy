const salva = () => {
    let codice = document.getElementById("input_codice").value;
    let materiale = document.getElementById("select_materiale").value;
    let nucleo = document.getElementById("select_nucleo").value;
    let lunghezza = document.getElementById("input_lunghezza").value;
    let resistenza = document.getElementById("select_resistenza").value;
    let casata = document.getElementById("select_casata").value;
    let nomeMago = document.getElementById("input_nome").value;

    let bacchetta = {
        codice,
        materiale,
        nucleo,
        lunghezza,
        resistenza,
        casata,
        nomeMago
    };

    let controllo = true;
    
    let elenco = JSON.parse(localStorage.getItem('lista_bacchette'));

    for (let item of elenco.entries()){
        if (item.codice == codice)
            controllo = false;
    }

    if (controllo)
    {
    elenco.push(bacchetta);
    localStorage.setItem('lista_bacchette', JSON.stringify(elenco));

    document.getElementById("input_codice").value = "";
    document.getElementById("select_materiale").value = "";
    document.getElementById("select_nucleo").value = "";
    document.getElementById("input_lunghezza").value = "";
    document.getElementById("select_resistenza").value = "";
    document.getElementById("select_casata").value = "";
    document.getElementById("input_nome").value = "";

    stampa();

    $("#modaleInserimento").modal("hide");
    }

    else
        alert(`Codice ${codice} già usato`)
}

const stampa = () => {
    let elenco = JSON.parse(localStorage.getItem('lista_bacchette'));

    let stringa = '';
    for(let [idx, item] of elenco.entries()){
        stringa += `
            <tr>
                <td>${idx + 1}</td>
                <td>${item.codice}</td>
                <td>${item.materiale}</td>
                <td>${item.nucleo}</td>
                <td>${item.lunghezza}</td>
                <td>${item.resistenza}</td>
                <td>${item.casata}</td>
                <td>${item.nomeMago}</td>
                <td><img src="https://picsum.photos/30/30"></td>
                <td class="text-right">
                    <button class="btn btn-warning" onclick="modifica(${idx})">
                        <i class="fa-solid fa-pencil"></i>
                    </button>
                    <button class="btn btn-danger" onclick="elimina(${idx})">
                        <i class="fa-solid fa-trash"></i>
                    </button>
                </td>
            </tr>`;
    }

    document.getElementById("corpo_tabella_bacchetta").innerHTML = stringa;
}


const elimina = (indice) => {
    let elenco = JSON.parse( localStorage.getItem('lista_bacchette') );
    elenco.splice(indice, 1);
    localStorage.setItem('lista_bacchette', JSON.stringify(elenco));

    stampa();
}

const modifica = (indice) => {

    let elenco = JSON.parse( localStorage.getItem('lista_bacchette') );

    document.getElementById("update_codice").value = elenco[indice].codice;
    document.getElementById("update_select_materiale").value = elenco[indice].materiale;
    document.getElementById("update_select_nucleo").value = elenco[indice].nucleo;
    document.getElementById("update_lunghezza").value = elenco[indice].lunghezza;
    document.getElementById("update_select_resistenza").value = elenco[indice].resistenza;
    document.getElementById("update_select_casata").value = elenco[indice].casata;
    document.getElementById("update_nome").value = elenco[indice].nomeMago;

    $("#modaleAggiornamento").data("identificativo", indice)

    $("#modaleAggiornamento").modal("show");
}

const update = () => {
    let codice = document.getElementById("update_codice").value;
    let materiale = document.getElementById("update_select_materiale").value;
    let nucleo = document.getElementById("update_select_nucleo").value;
    let lunghezza = document.getElementById("update_lunghezza").value;
    let resistenza = document.getElementById("update_select_resistenza").value;
    let casata = document.getElementById("update_select_casata").value;
    let nomeMago = document.getElementById("update_nome").value;

    let bacchetta = {
        codice,
        materiale,
        nucleo,
        lunghezza,
        resistenza,
        casata,
        nomeMago
    };

    let indice = $("#modaleAggiornamento").data("identificativo")

    let elenco = JSON.parse( localStorage.getItem('lista_bacchette') );
    elenco[indice] = bacchetta;
    localStorage.setItem('lista_bacchette', JSON.stringify(elenco));
    
    stampa();

    $("#modaleAggiornamento").modal("hide");
}

let listaBacchette = localStorage.getItem('lista_bacchette');
if(!listaBacchette)
    localStorage.setItem('lista_bacchette', JSON.stringify([]) );

setInterval(() => {
    stampa(); 
}, 1000);

stampa();