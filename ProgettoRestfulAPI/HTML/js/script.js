const stampa = () => {
    $.ajax({
        url: "https://localhost:7139/api/prodotti",
        type: "GET",
        success: function(prodotti){
            let stringa = "";

            for(let [idx, item] of prodotti.entries()){
                stringa += `
                    <tr>
                        <td>${item.nome}</td>
                        <td>${item.descrizione}</td>
                        <td>${item.categoria}</td>
                        <td>${item.prezzo}</td>
                        <td>${item.quantita}</td>
                        <td>
                        <button type="button" class="btn btn-outline-info text-right" onclick="minus('${item.codice}')"><i class="fa-solid fa-minus"></i></button>
                        <button type="button" class="btn btn-outline-info text-left" onclick="plus('${item.codice}')"><i class="fa-solid fa-plus"></i></button>
                        <button class="btn btn-warning" data-toggle="modal" data-target="#modaleAggiornamento" onclick="modifica('${item.codice}')"><i class="fa-solid fa-pencil"></i></button>
                        <button class="btn btn-danger" onclick="elimina('${item.codice}')"><i class="fa-solid fa-trash"></i></button>
                        </td>
                    </tr>
                `;
            }

            document.getElementById("corpo_tabella").innerHTML = stringa;
        }, 
        error:function(){
            alert("Errore");
        }
    })
}

const aggiungi = () => {
    
    $.ajax(
        {
            url: "https://localhost:7139/api/prodotti",
            type: "POST",
            data: JSON.stringify({
                nome : $("#input_nome").val(),
                descrizione : $("#input_descrizione").val(),
                categoria : $("#input_categoria").val(),
                prezzo : $("#input_prezzo").val(),
                quantita: $("#input_quantita").val()
            }),
            contentType: "application/json",
            dataType: "json",
            success: function(){
                stampa();
            },
            error: function(){
                stampa();
            }
        }
    )

    $("#modaleInserimento").modal("hide");
}

const elimina = (codice) => {
    $.ajax(
        {
            url: "https://localhost:7139/api/prodotti/" + codice,
            type: "DELETE",
            success: function(){
                stampa();
            },
            error: function(){
                stampa();
            }
        }
    )
}

const modifica = (codice) => {

    $.ajax(
        {
            url: "https://localhost:7139/api/prodotti/" + codice,
            type: "GET",
            success: function(prodotto){
                $("#update_nome").val(prodotto.nome);
                $("#update_descrizione").val(prodotto.descrizione);
                $("#update_categoria").val(prodotto.categoria);
                $("#update_prezzo").val(prodotto.prezzo);
                $("#update_quantita").val(prodotto.quantita);
                $("#modaleAggiornamento").data("codice", codice);
            },
            error: function(){
                stampa();
            }
        }
    )
}

const update = () => {

    $.ajax(
        {
            url: "https://localhost:7139/api/prodotti",
            type: "PATCH",
            data: JSON.stringify({
                codice: $("#modaleAggiornamento").data("codice"),
                nome : $("#update_nome").val(),
                descrizione : $("#update_descrizione").val(),
                categoria : $("#update_categoria").val(),
                prezzo : $("#update_prezzo").val(),
                quantita: $("#update_quantita").val()
            }),
            contentType: "application/json",
            dataType: "json",
            success: function(){

                stampa();
            },
            error: function(){
                stampa();
            }
        }
    )

    $("#modaleAggiornamento").modal("hide");
}

const minus = (codice) => {
    
    $.ajax(
        {
            url: "https://localhost:7139/api/prodotti/" + codice,
            type: "GET",
            success: function(prodotto){
                $("#update_nome").val(prodotto.nome);
                $("#update_descrizione").val(prodotto.descrizione);
                $("#update_categoria").val(prodotto.categoria);
                $("#update_prezzo").val(prodotto.prezzo);
                $("#update_quantita").val(prodotto.quantita - 1);
                $("#modaleAggiornamento").data("codice", codice);
                update();
            },
            error: function(){
                stampa();
            }
        }
    )
}

const plus = (codice) => {
    
    $.ajax(
        {
            url: "https://localhost:7139/api/prodotti/" + codice,
            type: "GET",
            success: function(prodotto){
                $("#update_nome").val(prodotto.nome);
                $("#update_descrizione").val(prodotto.descrizione);
                $("#update_categoria").val(prodotto.categoria);
                $("#update_prezzo").val(prodotto.prezzo);
                $("#update_quantita").val(prodotto.quantita + 1);
                $("#modaleAggiornamento").data("codice", codice);
                update();
            },
            error: function(){
                stampa();
            }
        }
    )
}

$(document).ready(
    function(){

        stampa();

        $(".aggiungi").on("click", () => {
            aggiungi();
        })

        $(".update").on("click", () => {
            update();
        })

    }
);