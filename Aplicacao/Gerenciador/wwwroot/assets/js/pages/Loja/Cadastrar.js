function MostraCnpj() {
    $("#MostraCpf").addClass("d-none");
    $("#MostraCnpj").removeClass("d-none");
    $("#LJA_STR_CPF").val("");
}

function MostraCpf() {
    $("#MostraCnpj").addClass("d-none");
    $("#MostraCpf").removeClass("d-none");
    $("#LJA_STR_CNPJ").val("");
}