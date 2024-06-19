function alertaErro(mensagem) {
    let html = `<div class="alert alert-danger alerta-position alert-dismissible bg-danger text-white border-0 fade show" role="alert">
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
                <i class="ri-close-circle-line me-2"></i>  <strong>Erro - </strong> ${mensagem}
            </div>`;

    $("#alertaErro").html(html);
}

function alertaSucesso(mensagem) {
    let html = `    <div class="alert alert-success alerta-position alert-dismissible bg-success text-white border-0 fade show" role="alert">
        <i class="ri-check-line me-2"></i><button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
        <strong>Sucesso - </strong> ${mensagem}
    </div>`;

    $("#alertaSucesso").html(html);
}