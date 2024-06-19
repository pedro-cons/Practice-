let htmlNovoBtn = `<div id="divBotoes"></div>`;
let qtdBtn = 0;
let removidoBtn = [];

function AdicionaBotao(tipoBotao) {
    let numeroBtn = 0;
    if (qtdBtn < 4) {
        qtdBtn = qtdBtn + 1;

        if (removidoBtn.length > 0) {
            numeroBtn = removidoBtn[0];
            removidoBtn.shift();
        } else {
            numeroBtn = qtdBtn;
        }

        switch (tipoBotao) {
            case 1:
                let htmlBotaoUm = `<div class="card card-ord" id="card-remove${numeroBtn}">
                            <div class="row card-body cursor-move cartão mb-0 mt-3">
                                <input type="hidden" asp-for="Botao[${numeroBtn}].BTN_INT_TIPO" name="Botao[${numeroBtn}].BTN_INT_TIPO" value="1"/>
                                <input type="hidden" asp-for="Botao[${numeroBtn}].BTN_INT_ORDEM" name="Botao[${numeroBtn}].BTN_INT_ORDEM" id="Botao[${numeroBtn}].BTN_INT_ORDEM" ordem="${numeroBtn}" class="ordem-botoes" value="${numeroBtn}" />
                                <div class="col-md-3 text-center">
                                    <label class="form-label" for="Botao[${numeroBtn}].BTN_STR_NOME">Nome</label>
                                    <input type="text" value="Link Externo" name="Botao[${numeroBtn}].BTN_STR_NOME" id="Botao[${numeroBtn}].BTN_STR_NOME" class="form-control" placeholder="Digite o nome do botão." data-val="true" data-val-maxlength="A quantidade máxima de caracteres permitida é 255." data-val-maxlength-max="255" data-val-required="O campo &quot;Nome&quot; é obrigatório." maxlength="255" value="">
                                    <span class="text-danger field-validation-valid" data-valmsg-for="Botao[${numeroBtn}].BTN_STR_NOME" data-valmsg-replace="true"></span>
                                </div>
                                <div class="col-md-1 text-center">
                                    <label class="form-label" for="Botao[${numeroBtn}].BTN_STR_COR">Cor</label>
                                    <input class="form-control" id="example-color" type="color" name="Botao[${numeroBtn}].BTN_STR_COR" value="#10c469">
                                </div>
                                <div class="col-md-4 text-center">
                                    <label class="form-label" for="Botao[${numeroBtn}].BTN_STR_LINK">Link</label>
                                    <input type="text" value="https://portal-practice.com" name="Botao[${numeroBtn}].BTN_STR_LINK" id="Botao[${numeroBtn}].BTN_STR_LINK" class="form-control" placeholder="Digite o link do botão." data-val="true" data-val-maxlength="A quantidade máxima de caracteres permitida é 255." data-val-maxlength-max="255" data-val-required="O campo &quot;Link&quot; é obrigatório." maxlength="255" value="">
                                    <span class="text-danger field-validation-valid" data-valmsg-for="Botao[${numeroBtn}].BTN_STR_LINK" data-valmsg-replace="true"></span>
                                </div>
                                <div class="col-md-2 text-center">
                                    <label class="mb-2">Habilitado</label><br>
                                    <input type="checkbox" for="Botao[${numeroBtn}].BTN_BIT_ATIVO" name="Botao[${numeroBtn}].BTN_BIT_ATIVO" id="${numeroBtn}BTN_BIT_ATIVO" value="true" onclick="mudaValorCheck('${numeroBtn}BTN_BIT_ATIVO')" checked data-switch="success"/>
                                    <label for="${numeroBtn}BTN_BIT_ATIVO" data-on-label="Sim" data-off-label="Não"></label>
                                </div>
                                <div class="mt-3 col-md-2 text-center">
                                   <button type="button" onclick="removeBotao('card-remove${numeroBtn}',${numeroBtn})" class="btn btn-outline-danger rounded-pill"><i class="mdi mdi-delete"></i> Remover</button>
                                </div>
                            </div>
                        </div>`;

                $("#divBotoes").replaceWith(htmlBotaoUm + htmlNovoBtn);
                break;
            case 2:
                let htmlBotaoDois = `<div class="card card-ord" id="card-remove${numeroBtn}">
                            <div class="row card-body cursor-move cartão mb-0 mt-3">
                                <input type="hidden" asp-for="Botao[${numeroBtn}].BTN_INT_TIPO" name="Botao[${numeroBtn}].BTN_INT_TIPO" value="2"/>
                                <input type="hidden" asp-for="Botao[${numeroBtn}].BTN_INT_ORDEM" name="Botao[${numeroBtn}].BTN_INT_ORDEM" id="Botao[${numeroBtn}].BTN_INT_ORDEM" ordem="${numeroBtn}" class="ordem-botoes" value="${numeroBtn}" />
                                <div class="col-md-3 text-center">
                                    <label class="form-label" for="Botao[${numeroBtn}].BTN_STR_NOME">Nome</label>
                                    <input type="text" value="Wi-fi" name="Botao[${numeroBtn}].BTN_STR_NOME" id="Botao[${numeroBtn}].BTN_STR_NOME" class="form-control" placeholder="Digite o nome do botão." data-val="true" data-val-maxlength="A quantidade máxima de caracteres permitida é 255." data-val-maxlength-max="255" data-val-required="O campo &quot;Nome&quot; é obrigatório." maxlength="255" value="">
                                    <span class="text-danger field-validation-valid" data-valmsg-for="Botao[${numeroBtn}].BTN_STR_NOME" data-valmsg-replace="true"></span>
                                </div>
                                <div class="col-md-1 text-center">
                                    <label class="form-label" for="Botao[${numeroBtn}].BTN_STR_COR">Cor</label>
                                    <input class="form-control" id="example-color" type="color" name="Botao[${numeroBtn}].BTN_STR_COR" value="#10c469">
                                </div>
                                <div class="col-md-2 text-center">
                                    <label class="form-label" for="Botao[${numeroBtn}].BTN_STR_REDE">Wi-fi</label>
                                    <input type="text" name="Botao[${numeroBtn}].BTN_STR_REDE" id="Botao[${numeroBtn}].BTN_STR_REDE" class="form-control" placeholder="Digite nome da rede Wi-fi." value="">
                                    <span class="text-danger field-validation-valid" data-valmsg-for="Botao[${numeroBtn}].BTN_STR_REDE" data-valmsg-replace="true"></span>
                                </div>
                                <div class="col-md-2 text-center">
                                    <label class="form-label" for="Botao[${numeroBtn}].BTN_STR_SENHA">Senha</label>
                                    <input type="text" name="Botao[${numeroBtn}].BTN_STR_SENHA" id="Botao[${numeroBtn}].BTN_STR_SENHA" class="form-control" placeholder="Digite a senha da rede Wi-fi." value="">
                                    <span class="text-danger field-validation-valid" data-valmsg-for="Botao[${numeroBtn}].BTN_STR_SENHA" data-valmsg-replace="true"></span>
                                </div>
                                <div class="col-md-2 text-center">
                                    <label class="mb-2">Habilitado</label><br>
                                    <input type="checkbox" for="Botao[${numeroBtn}].BTN_BIT_ATIVO" name="Botao[${numeroBtn}].BTN_BIT_ATIVO" id="${numeroBtn}BTN_BIT_ATIVO" value="true" onclick="mudaValorCheck('${numeroBtn}BTN_BIT_ATIVO')" checked data-switch="success"/>
                                    <label for="${numeroBtn}BTN_BIT_ATIVO" data-on-label="Sim" data-off-label="Não"></label>
                                </div>
                                <div class="mt-3 col-md-2 text-center">
                                   <button type="button" onclick="removeBotao('card-remove${numeroBtn}',${numeroBtn})" class="btn btn-outline-danger rounded-pill"><i class="mdi mdi-delete"></i> Remover</button>
                                </div>
                            </div>
                        </div>`;

                $("#divBotoes").replaceWith(htmlBotaoDois + htmlNovoBtn);
                break;
            case 3:
                let htmlBotaoTres = `<div class="card card-ord" id="card-remove${numeroBtn}">
                            <div class="row card-body cursor-move cartão mb-0 mt-3">
                                <input type="hidden" asp-for="Botao[${numeroBtn}].BTN_INT_TIPO" name="Botao[${numeroBtn}].BTN_INT_TIPO" value="3"/>
                                <input type="hidden" asp-for="Botao[${numeroBtn}].BTN_INT_ORDEM" name="Botao[${numeroBtn}].BTN_INT_ORDEM" id="Botao[${numeroBtn}].BTN_INT_ORDEM" ordem="${numeroBtn}" class="ordem-botoes" value="${numeroBtn}" />
                                <div class="col-md-3 text-center">
                                    <label class="form-label" for="Botao[${numeroBtn}].BTN_STR_NOME">Nome</label>
                                    <input type="text" value="Whatsapp" name="Botao[${numeroBtn}].BTN_STR_NOME" id="Botao[${numeroBtn}].BTN_STR_NOME" class="form-control" placeholder="Digite o nome do botão." data-val="true" data-val-maxlength="A quantidade máxima de caracteres permitida é 255." data-val-maxlength-max="255" data-val-required="O campo &quot;Nome&quot; é obrigatório." maxlength="255" value="">
                                    <span class="text-danger field-validation-valid" data-valmsg-for="Botao[${numeroBtn}].BTN_STR_NOME" data-valmsg-replace="true"></span>
                                </div>
                                <div class="col-md-1 text-center">
                                    <label class="form-label" for="Botao[${numeroBtn}].BTN_STR_COR">Cor</label>
                                    <input class="form-control" id="example-color" type="color" name="Botao[${numeroBtn}].BTN_STR_COR" value="#10c469">
                                </div>
                                <div class="col-md-4 text-center">
                                    <label for="Botao[${numeroBtn}].BTN_STR_WHATSAPP" class="form-label">Whatsapp</label>
                                    <input type="text" data-toggle="input-mask" data-mask-format="(00) 00000-0000" class="form-control" name="Botao[${numeroBtn}].BTN_STR_WHATSAPP" id="Botao[${numeroBtn}].BTN_STR_WHATSAPP" placeholder="Digite o whatsapp da loja." data-val="true" data-val-maxlength="A quantidade máxima de caracteres permitida é 30." data-val-maxlength-max="30" data-val-required="O Campo &quot;Whatsapp&quot; é obrigatório." maxlength="15" value="">
                                    <span asp-validation-for="Botao[${numeroBtn}].BTN_STR_WHATSAPP" class="text-danger field-validation-valid" data-valmsg-replace="true"></span>
                                </div>
                                <div class="col-md-2 text-center">
                                    <label class="mb-2">Habilitado</label><br>
                                    <input type="checkbox" for="Botao[${numeroBtn}].BTN_BIT_ATIVO" name="Botao[${numeroBtn}].BTN_BIT_ATIVO" id="${numeroBtn}BTN_BIT_ATIVO" value="true" onclick="mudaValorCheck('${numeroBtn}BTN_BIT_ATIVO')" checked data-switch="success"/>
                                    <label for="${numeroBtn}BTN_BIT_ATIVO" data-on-label="Sim" data-off-label="Não"></label>
                                </div>
                                <div class="mt-3 col-md-2 text-center">
                                   <button type="button" onclick="removeBotao('card-remove${numeroBtn}',${numeroBtn})" class="btn btn-outline-danger rounded-pill"><i class="mdi mdi-delete"></i> Remover</button>
                                </div>
                            </div>
                        </div>`;

                $("#divBotoes").replaceWith(htmlBotaoTres + htmlNovoBtn);
                ativaInputMask();
                break;
            default:
                break;
        }
    } else {
        alertaErro("Quantidade máxima de botões é 5.");
    }
}

function alterarOrdem() {
    let contador = 0;

    $(".ordem-botoes").each(function () {
        let valor = $(this).val();

        $("[ordem=" + valor + "]").val(contador);

        contador++;
    });
}


function removeBotao(id, numero) {
    $("." + id).replaceWith("");

    qtdBtn = qtdBtn - 1;

    removidoBtn.push(numero);
}