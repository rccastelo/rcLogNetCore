function paginar(pagina) {
    var form = document.getElementById("form");
    var paginaAtual = document.getElementById("Paginacao_PaginaAtual");

    paginaAtual.value = pagina;
    
    form.submit();
}

function consultarPorId(id) {
    var form = document.getElementById("form");
    var sistemaId = document.getElementById("Sistema_Id");

    sistemaId.value = id;
    
    form.submit();
}
