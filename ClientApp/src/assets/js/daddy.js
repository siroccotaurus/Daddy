﻿function initAs(page) {
    switch (page) {
        case "login":
            document.getElementById("login_btn").innerHTML = "Log in";
            document.getElementById("login_password").style.display = "none";
            document.getElementById("login_op1").style.display = "block";
            document.getElementById("login_op2").style.display = "none";
            break;
        case "register":
            document.getElementById("login_btn").innerHTML = "Register";
            document.getElementById("login_password").style.display = "block";
            document.getElementById("login_op1").style.display = "none";
            document.getElementById("login_op2").style.display = "block";
            break;
        default:
            break;
    }
}
