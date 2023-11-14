let UserName;
let Email;
let Contrasena;
let ContrasenaRepetir;

window.onload = function () {
    formRegister = document.querySelector("#formRegister");
    formRegister.addEventListener("submit", Registrarse);
}

function Registrarse() {
    event.preventDefault();

    //UserName = document.querySelector('#UserName').value;
    //Email = document.querySelector('#Email').value;
    Contrasena = document.querySelector('#Contrasena').value;
    ContrasenaRepetir = document.querySelector('#ContrasenaRepetir').value;

    if (Contrasena != ContrasenaRepetir) {
        return alert('Las contraseñas deben coincidir');
    }

    formRegister.submit();

}