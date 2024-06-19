function mudaValorCheck(id) {
    let input = $("#" + id);

    if (input.val() === 'true') {
        input.val('false');
    } else {
        input.val('true');
    }
}

function ativaInputMask(){
    // Input Mask
    if(jQuery().mask) {
    $('[data-toggle="input-mask"]').each(function (idx, obj) {
        var maskFormat = $(obj).data("maskFormat");
        var reverse = $(obj).data("reverse");
        if (reverse != null)
            $(obj).mask(maskFormat, { 'reverse': reverse });
        else
            $(obj).mask(maskFormat);
        });
    }
}