function Sucesso(data) {
    Swal.fire({
        icon: 'success',
        title: data.msg,
        showConfirmButton: false,
        timer: 1600
    });

    setTimeout(function () { location.href += data.url.toString(); }, 1500);
}

function Falha() {
    Swal.fire(
        'Falha',
        'Ocorreu um erro inesperado!',
        'error'
    );
}
