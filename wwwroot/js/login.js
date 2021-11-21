function Sucesso(data) {
    Swal.fire({
        icon: data.icon,
        title: data.msg,
        showConfirmButton: false,
        timer: 1600
    });

    console.log(window.location.origin + data.url);
    setTimeout(function () { location.href = (window.location.origin + data.url) }, 1600);
}

function Falha() {
    Swal.fire(
        'Falha',
        'Ocorreu um erro inesperado!',
        'error'
    );
}
