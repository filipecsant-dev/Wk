$(document).ready(function () {
    $('#table').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.12.1/i18n/pt-BR.json",
        },
        "pageLength": 6,
        "bLengthChange": false
    });


    $(".visu").on("click", function () {
        var id = $(this).attr("data-id");
        var root = window.location.href;
        var tipo = $(this).attr("data-tipo");
        var url = '';
        if (tipo == "produtos") url = root + 'Produtos/Visualizar/' + id;
        else url = root + 'Categorias/Visualizar/' + id;

        
        $.ajax({
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            url: url,
            success: (e) => {
                $("#Prod_Nome").html(e.nome);
                $("#Prod_Descricao").html(e.descricao);
                $("#Prod_Categoria").html(e.categoria.nome);
                $("#Prod_Qntd").html(e.qntd);


                $("#page1").hide(500);
                $("#page2").show(1000);
            },
            error: (e) => {
                console.log('error');
            }
        });
    });

    $("#voltar").on("click", function () {
        $("#page2").hide(500);
        $("#page1").show(1000);
    });


    $(".excluir").click(function () {
        var id = $(this).attr("data-id");
        var tipo = $(this).attr("data-tipo");
        var root = window.location.href;
        var url = '';
        var info_tipo = '';
        if (tipo == "produtos") { url = root + 'Produtos/Excluir/' + id; info_tipo = 'produto'; }
        else { url = root + '/Excluir/' + id; info_tipo = 'categoria'; }

        swal({
            title: "Atenção!",
            text: "Tem certeza que deseja excluir esse "+info_tipo+" ?",
            icon: "warning",
            buttons: true,
        }).then(function (result) {
            if (result) {

                $.ajax({
                    type: 'POST',
                    contentType: 'application/json',
                    dataType: 'json',
                    url: url,
                    complete: (e) => {
                        location.reload();
                    }
                });

            } else {
                return;
            }
        });
    });

});