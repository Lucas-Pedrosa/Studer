
function formatoSimulado() {

    if (document.getElementById("vestibular").checked) {
        document.getElementById("disciplinas").style.display = "none";

        document.getElementById("vestibulares").style.display = "block";
    }
    else if (document.getElementById("disciplina").checked) {
        document.getElementById("vestibulares").style.display = "none";

        document.getElementById("disciplinas").style.display = "block";
    }
}