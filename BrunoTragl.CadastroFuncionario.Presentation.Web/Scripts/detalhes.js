$(document).ready(function () {
    buscarHabilidadesUnicas();
});

function removerHabilidade(id) {
    mostrarLoading();
    $.ajax({
        url: _urlRemoverHabilidadeFuncionario,
        data: { id: id },
        type: 'post',
        success: function (data) {
            $('#habilidades').find('#' + id)[0].remove();
            esconderLoading();
            swal({
                icon: "success",
                text: "Habilidade removida com sucesso!"
            });
            validarRemocaoDeHabilidades();
        },
        error: function (err) {
            esconderLoading();
            alert('Ocorreu um erro ao tentar remover habilidade:\n\n' + err.responseText);
        }
    })
}


function buscarHabilidadesUnicas() {
    $.ajax({
        url: _urlBuscarHabilidadesUnicas,
        type: 'get',
        success: function (habilidades) {
            $('#habilidadesUnicas').append('<option value""></option>');
            if (habilidades != null && habilidades != undefined) {
                habilidades.forEach(function (h) {
                    let html = '<option value"'+h.Nome+'">'+h.Nome+'</option>';
                    $('#habilidadesUnicas').append(html);
                });
            }
        },
        error: function (err) {
            alert('Ocorreu o seguinte erro ao tentar buscar as habilidades únicas:\n\n' + err.responseText);
        }
    })
}

function adicionarNovaHabilidade() {
    let habilidadeSelecionada = $('#habilidadesUnicas').val();
    let funcionarioId = $('#funcionarioId').val();
    if (habilidadeSelecionada == null
        || habilidadeSelecionada == undefined
        || habilidadeSelecionada === '') {
        swal("Selecione uma habilidade!");
        return;
    }

    $.ajax({
        url: _urlAdicionarHabilidadeFuncionario,
        data: { Nome: habilidadeSelecionada, FuncionarioId: funcionarioId },
        type: 'post',
        success: function (novaHabilidade) {
            if (novaHabilidade != null
                || novaHabilidade != undefined
                || novaHabilidade !== '') {
                adicionarNovaHabilidadeNoPanel(novaHabilidade);
                validarRemocaoDeHabilidades();
                swal({ icon: "success", text: 'Habilidade ' + novaHabilidade.Nome + ' adicionada com sucesso!' });
            } else {
                swal('Ocorreu um erro ao adicionar a nova habilidade.');
            }
        },
        error: function (err) {
            swal('Ocorreu um erro ao adicionar a nova habilidade:\n\n' + err.responseText);
        }
    })
}

function adicionarNovaHabilidadeNoPanel(novaHabilidade) {
    let habilidades = $('#habilidades');
    let html = '<div class="quadroHabilidade habilidade" id="' + novaHabilidade.Id + '">';
    html += novaHabilidade.Nome;
    html += '<div class="removerHabilidade" onclick="removerHabilidade(' + novaHabilidade.Id + ')">x</div></div>';
    habilidades.append(html);
}

function validarRemocaoDeHabilidades() {
    let habilidades = $('#habilidades div');
    if (habilidades.length == 2) {
        let divRemoverHabilidade = $($('#habilidades div')[0]).find('div');
        if (divRemoverHabilidade.length == 1) {
            divRemoverHabilidade.remove();
        }
    }
    else {
        let divRemoverHabilidade = $($('#habilidades div')[0]).find('div');
        if (divRemoverHabilidade.length == 0) {
            let id = $('#habilidades div')[0].id;
            $($('#habilidades div')[0]).append('<div class="removerHabilidade" onclick="removerHabilidade(' + id + ')">x</div>')
        }
    }
}