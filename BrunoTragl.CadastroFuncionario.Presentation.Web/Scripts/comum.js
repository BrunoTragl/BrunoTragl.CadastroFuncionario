function linhaComum(valor, click) {
    return '<td ' + click + '>' + valor + '</td>';
}

function linhaCheckBox(valor) {
    let linha = '<td><input type="checkbox" ';
    if (valor) {
        linha += 'checked ';
    }
    linha += '/></td>';
    return linha;
}

function preencherPaginacao(paginacao, paginaAtual) {
    $('.itensDaPagina').html('');
    $('.totalItensPagina').html('');
    $('.totalItensCadastrados').html('');
    $('.totalPaginas').html('');

    let htmlTotalItensPagina = '<p>Funcionários nesta página: ' + paginacao.QuantidadeItens + '</p>';
    $('.totalItensPagina').append(htmlTotalItensPagina);

    let htmlTotalItensCadastrados = '<p>Total cadastrados: ' + paginacao.QuantidadeTotalItens + '</p>';
    $('.totalItensCadastrados').append(htmlTotalItensCadastrados);

    let htmlTotalPaginas = '<p>Total de páginas: ' + paginacao.QuantidadePaginas + '</p>';
    $('.totalPaginas').append(htmlTotalPaginas);

    if (paginacao.QuantidadeItens == 0) {
        $('.itensDaPagina').append('<p class="font-roboto-weight-400-tam-14">Nenhum funcionário listado</p>');
    } else if (paginacao.QuantidadeItens == 1) {
        $('.itensDaPagina').append('<p class="font-roboto-weight-400-tam-14">' + paginacao.QuantidadeItens + ' funcionário listado</p>');
    } else {
        $('.itensDaPagina').append('<p class="font-roboto-weight-400-tam-14">' + paginacao.QuantidadeItens + ' funcionários listados</p>');
    }
    

    var pagina = $('#paginacao');
    pagina.html('');

    let btns = [];
    let paginaAnterior = null;
    let paginaProxima = null;
    let paginaUltima = null;

    if (paginaAtual > 1) {
        paginaAnterior = paginaAtual - 1;
    }
    if (paginacao.QuantidadePaginas > paginaAtual) {
        paginaProxima = paginaAtual + 1;
    }
    if (paginacao.QuantidadePaginas > paginaAtual + 1) {
        paginaUltima = paginacao.QuantidadePaginas;
    }

    if (paginaAnterior) {
        btns.push(btnPaginacaoClicavel(paginaAnterior, false));
        btns.push(btnPaginaAtual(paginaAtual));
        if (paginaProxima) {
            btns.push(btnPaginacaoClicavel(paginaProxima, false));
            if (paginaUltima) {
                if (paginaUltima > paginaAtual + 2) {
                    btns.push(btnPaginacaoClicavel(paginaUltima, true));
                } else {
                    btns.push(btnPaginacaoClicavel(paginaUltima, false));
                }
            }
        }
    }
    else {
        btns.push(btnPaginaAtual(paginaAtual));
        if (paginaProxima) {
            btns.push(btnPaginacaoClicavel(paginaProxima, false));
            if (paginaUltima) {
                if (paginaUltima > paginaAtual + 2) {
                    btns.push(btnPaginacaoClicavel(paginaUltima, true));
                } else {
                    btns.push(btnPaginacaoClicavel(paginaUltima, false));
                }
            }
        }
    }

    btns.forEach(function (b) {
        pagina.append(b);
    });
}

function btnPaginacaoClicavel(pagina, ultimaPaginaComRescencias) {
    let btn = '';
    if (ultimaPaginaComRescencias) {
        btn += '<span class="btnPaginacaoRetecencias">...</span>';
    }
    btn += '<button class="btn btn-default btnPaginacao" onclick="paginaOnClick(' + pagina + ')">' + pagina + '</button>';
    return btn;
}

function btnPaginaAtual(pagina) {
    return '<button class="btn btn-primary btnPaginacao" disabled>' + pagina + '</button>';
}

function getQueryStringValueByName(name) {
    let url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function mostrarLoading() {
    $('.loading').show()
}

function esconderLoading() {
    $('.loading').hide()
}

function fecharAlert() {
    $('.alert').hide();
}