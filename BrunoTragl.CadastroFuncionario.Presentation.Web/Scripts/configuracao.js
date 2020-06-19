function removerHabilidade(id) {
    mostrarLoading();
    $.ajax({
        url: _urlRemoverHabilidade,
        data: { id: id },
        type: 'post',
        success: function (data) {
            $('#habilidades').find('#' + id)[0].remove();
            esconderLoading();
            swal({
                icon: "success",
                text: "Habilidade removida com sucesso!"
            });
        },
        error: function (err) {
            esconderLoading();
            swal({
                icon: "error",
                text: "Ocorreu um erro ao tentar remover habilidade:\n\n" + err.responseText
            });
        }
    })
}