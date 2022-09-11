$(document).ready(function () {
    $('#table').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.12.1/i18n/pt-BR.json"
        }
    });


    $(".visu_prod").on("click", function () {
        var id = $(this).attr("data-id");
        var root = window.location.href;

        
        $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            url: root + 'Produtos/Visualizar/' + id,
            success: (e) => {
                $("#Prod_Nome").html(e.nome);
                $("#Prod_Descricao").html(e.descricao);
                $("#Prod_Categoria").html(e.categoria);
                $("#Prod_Qntd").html(e.qntd);


                $("#page1").hide(500);
                $("#page2").show(1000);
            },
            error: (e) => {
                console.log('error')
            }
        });
    });

    $("#voltar").on("click", function () {
        $("#page2").hide(500);
        $("#page1").show(1000);
    });

});