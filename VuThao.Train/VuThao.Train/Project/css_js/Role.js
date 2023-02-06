
let personName = sessionStorage.getItem("LoginName");

console.log(personName);
console.log(sessionStorage.getItem("IdUser"));

document.getElementById("LoginText").innerHTML = " " + personName;

$("#logout").hide();
$("#fromAdd").hide();
$("#PageFollow").hide();
$("#datateam").hide();
if (sessionStorage.length == 0 && personName == null) {

    $("#profileUser").hide();
    $("#Admin").hide();
}
if (sessionStorage.length != 0 && personName != null) {
    $("#login").hide
    $("#logout").show();
    $("#PageFollow").show();

}
if (sessionStorage.getItem("IdTeam") > 0) {
    $("#fromAdd").show();
    $("#datateam").show();
}
if (sessionStorage.getItem("Role") === "true") {
    $("#Admin").show();
} else {
    $("#Admin").hide();
}