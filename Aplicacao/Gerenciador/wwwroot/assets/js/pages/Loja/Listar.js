function abreModal(idf) {
    $("#botaoExcluir").attr("onclick", `Excluir(${idf})`);
    $("#danger-alert-modal").modal('show');
}

function Excluir(idf) {
    $.post('/Loja/Excluir', { idf: idf }, function (data) {
        window.location.reload();
    }).fail(function (err) {
        alertaErro(err.responseText);
    });
}