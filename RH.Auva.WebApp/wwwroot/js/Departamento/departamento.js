$(document).ready(() => {

    $("#btIncluir").on('click', onClickIncluir);
    $("#btSalvarDepartamento").on('click', onClickSalvar);
});

var model = {
    Codigo: 0,
    NomeDepartamento: ''
};

function onClickIncluir() {
    window.location.href = '../Departamento/Incluir';
}

function onClickSalvar() {
    clearMensagens();
    model.Codigo = $("#txtCodigo").val();
    model.NomeDepartamento = $("#txtNomeDepartamento").val();

    if (!model.NomeDepartamento) {
        alert("Preencha todos os campos !");
        return;
    }

    util.ajax.post("../Departamento/Incluir", model, salvarSucesso, salvarErro);

}

function salvarSucesso(data) {

    if (data) {

        $("#mensagem-sucesso").removeClass('d-none');
        $("#txtNomeDepartamento").val("");

    }
}
function salvarErro(data) {
    $("#mensagem-erro").removeClass('d-none');
}

function ocultarMensagemSucesso() {
    $("#mensagem-sucesso").addClass('d-none');
}

function ocultarMensagemErro() {
    $("#mensagem-erro").addClass('d-none');
}

function clearMensagens() {
    ocultarMensagemErro();
    ocultarMensagemSucesso();
}

function excluir(codigo) {
    if (codigo > 0) {
        util.ajax.post("../Departamento/Excluir", codigo, excluirSucesso, excluirErro);
    }
}

function excluirSucesso(data) {
    if (data) {
        window.location.href = '../Departamento/Index';
    }
}

function excluirErro(data) {
    alert("Erro ao tentar excluir o departamento!");
}


function editar(id) {
    if (id > 0) {
        window.location.href = "../Departamento/Editar?id=" + id;
    }
}


function buscar() {
    $("#divPartialDepartamentos").empty();


    var filtro = $("#txtFiltro").val();
    util.ajax.get("../Departamento/ListarDepartamentosPartial?filtro=" + filtro, null, buscarSucesso, buscarErro);
}

function buscarSucesso(data) {
    if (data) {

        $("#divPartialDepartamentos").html(data);
    }
}

function buscarErro(data) {
    console.log(data);
}

