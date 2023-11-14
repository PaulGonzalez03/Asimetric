let UserName;
let Email;
let Contrasena;
let ContrasenaRepetir;

window.onload = function () {
    formLogin = document.querySelector("#formLogin");
    formLogin.addEventListener("submit", IniciarSesion);
}

function IniciarSesion() {

    UserName = document.querySelector('#UserName').value;
    //Email = document.querySelector('#Email').value;
    //Contrasena = document.querySelector('#Contrasena').value;
    E_Key = document.querySelector('#E-Key').value;
}

