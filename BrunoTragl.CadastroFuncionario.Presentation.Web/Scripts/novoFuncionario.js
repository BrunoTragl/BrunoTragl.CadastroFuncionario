function selecionar(div) {
    div = $(div);
    let checkbox = div.find('input:checkbox');
    if (checkbox[0].checked) {
        $(div).removeClass('selecionado');
        $(div).addClass('naoSelecionado');
        checkbox[0].checked = false;
    } else {
        $(div).removeClass('naoSelecionado');
        $(div).addClass('selecionado');
        checkbox[0].checked = true;
    }
}