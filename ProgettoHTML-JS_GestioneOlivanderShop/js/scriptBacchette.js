const tendinaCasate = () => {
    let elenco = JSON.parse( localStorage.getItem('lista_casate') );
    let stringa = `<option selected="selected">Nessuno</option>`;

    for (let [idx,item] of elenco.entries()){
        stringa += `<option value="${item.nome}">${item.nome}</option>`;
    }

    document.getElementById("select_casata").innerHTML = stringa;
}

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
        let elencoCasate = JSON.parse( localStorage.getItem('lista_casate') );

        for (let [idx,] of elencoCasate.entries()){
            if (elencoCasate[idx].nome == bacchetta.casata){
                elencoCasate[idx].quantita += 1;
            }
        }
    
        elenco.push(bacchetta);
        localStorage.setItem('lista_bacchette', JSON.stringify(elenco));
        localStorage.setItem('lista_casate', JSON.stringify(elencoCasate));

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
    let elencoCasate = JSON.parse( localStorage.getItem('lista_casate') );

        for (let [idx,] of elencoCasate.entries()){
            if (elencoCasate[idx].nome == elenco[indice].casata){
                elencoCasate[idx].quantita -= 1;
            }
        }
    elenco.splice(indice, 1);
    localStorage.setItem('lista_bacchette', JSON.stringify(elenco));
    localStorage.setItem('lista_casate', JSON.stringify(elencoCasate));

    stampa();
}

let listaBacchette = localStorage.getItem('lista_bacchette');
if(!listaBacchette)
    localStorage.setItem('lista_bacchette', JSON.stringify([]) );

setInterval(() => {
    stampa(); 
}, 1000);

stampa();

tendinaCasate();