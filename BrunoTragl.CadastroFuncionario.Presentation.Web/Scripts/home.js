let _page = 1;
let _pageSize = 0;
$(document).ready(function () {
    _pageSize = $('#qtdePorPagina').val();
    buscarFuncionarios();
    preencherFiltroHabilidadesUnicas();
});

function buscarFuncionarios() {
    $.ajax({
        url: '/funcionarios/List',
        data: { pageSize: _pageSize, page: _page },
        method: 'get',
        success: function (data) {
            if (data != null 
                || data != undefined) {
                preencherTabela(data.Funcionarios);
                preencherPaginacao(data.Paginacao, _page);
            }
        },
        error: function (err) {
            console.log('Ocorreu um erro ao buscar funcionários:\n\n' + err.responseText);
        }
    });
}

function atualizarPageSize() {
    let qtdeSelecionado = $('#qtdePorPagina').val();
    if (_pageSize !== qtdeSelecionado) {
        _page = 1;
        _pageSize = qtdeSelecionado;
        buscarFuncionarios();
    }
}

function preencherTabela(funcionarios) {
    let tbody = $('#funcionarios');
    tbody.html('');

    funcionarios.forEach(function (f) {
        let linha = '<tr>';
        linha += linhaComum(f.Nome, 'onclick="detalhesFuncionario(' + f.Id + ')"');
        linha += linhaComum(f.Sobrenome, 'onclick="detalhesFuncionario(' + f.Id + ')"');
        linha += linhaComum(f.DataNascimento, 'onclick="detalhesFuncionario(' + f.Id + ')"');
        linha += linhaComum(f.Idade, 'onclick="detalhesFuncionario(' + f.Id + ')"');
        linha += linhaComum(f.Email, 'onclick="detalhesFuncionario(' + f.Id + ')"');
        linha += linhaComum(f.Sexo, 'onclick="detalhesFuncionario(' + f.Id + ')"');
        linha += linhaHabilidades(f.Habilidades);
        linha += linhaCheckBoxAtivacao(f.Id, f.Ativo);
        linha += '<tr>';
        tbody.append(linha);
    });

    //nome e sobrenome, data de nascimento, idade, e - mail, sexo, habilidades e uma opção para ativar ou desativar o funcionário
    //O sistema deve oferecer os seguintes filtros para o relatório de funcionários: nome e sobrenome, idade, sexo e habilidades
}

function linhaHabilidades(habilidades) {
    let linha = '<td>';
    habilidades.forEach(function (h) {
        linha += '<button class="btn btn-primary btnHabilidade">' + h.Nome + '</button>';
    });
    linha += '</td>'
    return linha;
}

function paginaOnClick(page) {
    _page = page;
    buscarFuncionarios();
}

function linhaCheckBoxAtivacao(id, ativacao) {
    let linha = '<td><input type="checkbox" onclick="ativacaoFuncionario(' + id + ', this.checked)"';
    if (ativacao) {
        linha += 'checked ';
    }
    linha += '/></td>';
    return linha;
}

function ativacaoFuncionario(id, ativacao) {
    $.ajax({
        url: '/funcionarios/Ativacao',
        data: { id: id, ativo: ativacao },
        type: 'post',
        dataType: 'json',
        error: function (err) {
            swal('Ocorreu um erro ao efetuar ativação do funcionário!');
            console.log('Ocorreu um erro ao efetuar ativação do funcionário!\n\n' + err.responseText)
        }
    });
}

function detalhesFuncionario(id) {
    location.href = _urlDetalhesFuncinario + '/' + id;
}

function preencherFiltroHabilidadesUnicas() {
    $.ajax({
        url: _urlHabilidadesUnicas,
        type: 'get',
        success: function (data) {
            if (data != null
                && data != undefined
                && data.length > 0) {
                data.forEach(function (h) {
                    incluirHabilidadeUnicaNoFiltro(h.Id, h.Nome);
                })
            }
        },
        error: function (err) {
            console.log('Erro ao buscar habilidades unicas:\n\n' + err.responseText);
        }
    });
}

function incluirHabilidadeUnicaNoFiltro(id, nome) {
    let html = '<button type="button" class="btn btn-default" id="' + id + '">' + nome + '</button>';
    $('.botoesDinamicos').append(html);
}