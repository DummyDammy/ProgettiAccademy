const stampa = () => {
    $.ajax({
        url: "https://localhost:7042/api/sistema",
        type: "GET",
        success: function(sistemi){
            let stringa = "";

            for(let [, item] of sistemi.data.entries()){
                stringa += `
                    <tr data-codice="${item.code}">
                        <td>${item.code}</td>
                        <td>${item.name}</td>
                        <td>${item.type}</td>
                        <td class = "text-right" >
                            <button type="button" class="btn btn-outline-info text-right"><i class="fa-solid fa-plus"></i></button>
                            <button class="btn btn-info" data-toggle="modal" data-target="#modaleAggiornamento" onclick="modifica(this)"><i class="fa-solid fa-pencil"></i></button>
                            <button class="btn btn-danger"><i class="fa-solid fa-trash"></i></button>
                        </td>
                    </tr>
                `;
            }

            document.getElementById("corpo_tabella_sistemi").innerHTML = stringa;
        }, 
        error:function(){
            alert("Errore");
        }
    })
}

const aggiungi = () => {
    
    $.ajax(
        {
            url: "https://localhost:7042/api/sistema",
            type: "POST",
            data: JSON.stringify({
                code : $("#input_codice").val(),
                name : $("#input_nome").val(),
                type : $("#input_tipo").val(),
            }),
            contentType: "application/json",
            success: function(){
                stampa();
            },
            error: function(){
                alert("errore");
            }
        }
    )

    $("#modaleInserimento").modal("hide");
}

const modifica = (elemento) => {
    let codice = $(elemento).closest("tr").data("codice");  
    $.ajax(
        {
            url: "https://localhost:7042/api/sistema/" + codice,
            type: "GET",
            success: function(sistema){
                $("#update_codice").val(sistema.data.code);
                $("#update_nome").val(sistema.data.name);
                $("#update_tipo").val(sistema.data.type);
            },
            error: function(){
                alert("errore");
            }
        }
    )
}

const update = () => {

    $.ajax(
        {
            url: "https://localhost:7042/api/sistema",
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

$(document).ready(
    function(){

        stampa();

        $(".aggiungi").on("click", () => {
            aggiungi();
        })

    }
);