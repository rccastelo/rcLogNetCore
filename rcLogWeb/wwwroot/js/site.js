function paginar(pagina) {
    var form = document.getElementById("form");
    var paginaAtual = document.getElementById("Paginacao_PaginaAtual");

    paginaAtual.value = pagina;
    
    form.submit();
}
