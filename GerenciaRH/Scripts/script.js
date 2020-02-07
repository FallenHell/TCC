$(document).ready(function () {

    $("#btnLimparUm").on('click', function () {
        document.getElementById('txtNomeUsuario').value = "";
        document.getElementById('txtRacf').value = "";
        document.getElementById('txtCpf').value = "";
        document.getElementById('txtPis').value = "";
        document.getElementById('txtRazao').value = "";
        //document.getElementById('txtCargo').value = "Selecione";
        //$("#txtCargo").val('Selecione');
        $('#txtCargo').prop('selectedIndex', 0);

    });

    $("#btnLimparDois").on('click', function () {
        document.getElementById('txtCep').value = "";
        document.getElementById('txtEmail').value = "";
        document.getElementById('txtEndereco').value = "";
        document.getElementById('txtNumeroEndereco').value = "";

    });

    $("#btnPesquisar").click(function () {

        var CEP = $("#txtCep").val();
        $.ajax({
            type: "POST",
            url: "/Cadastro/ConsultaCEP",
            data: { CEP: CEP },
            success: function (data) {
                teste = data;
                if (data != "error") {

                    document.getElementById('txtEndereco').value = teste.Logradouro + ", " + teste.Bairro + ", " + teste.Localidade;
                }
                else {
                    alert('Erro na consulta do CEP');
                }
            },
        });


    });

    $("#btnPesquisarUsuario").keyup(function () {
        var value = $(this).val().toLowerCase();
        $("#tbUsuarios tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });

    $('#modalSucesso').modal();
    $(document).on("input", "#comentarioColaboradorDesligado", function () {
        var limite = 401;
        var informativo = "caracteres restantes.";
        var caracteresDigitados = $(this).val().length;
        var caracteresRestantes = limite - caracteresDigitados;

        if (caracteresRestantes <= 0) {
            var comentario = $("textarea[name=comentario]").val();
            $("textarea[name=comentario]").val(comentario.substr(0, limite));
            $(".caracteres").text("0 " + informativo);
        } else {
            $(".caracteres").text(caracteresRestantes + " " + informativo);
        }
    });

    $(document).on("input", "#comentarioAvaliacao", function () {
        var limite = 1000;
        var informativo = "caracteres restantes.";
        var caracteresDigitados = $(this).val().length;
        var caracteresRestantes = limite - caracteresDigitados;

        if (caracteresRestantes <= 0) {
            var comentario = $("textarea[name=comentario]").val();
            $("textarea[name=comentario]").val(comentario.substr(0, limite));
            $(".caracteres").text("0 " + informativo);
        } else {
            $(".caracteres").text(caracteresRestantes + " " + informativo);
        }
    });
});
