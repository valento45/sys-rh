$(document).ready(() => {


});


function importar() { 

    var select = document.getElementById("cmbDepartamentos");

    var opcaoValor = select.options[select.selectedIndex].value;
    $("#txtDepartamentoSelecionado").val(opcaoValor);
            
}