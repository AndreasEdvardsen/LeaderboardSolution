function newUser() {
    var xhttp = new XMLHttpRequest();
    var Username = document.getElementById('Username').value;
    var SecurityCode = document.getElementById('SecurityCode').value;

    if (Username !== "" && SecurityCode !== "") {
        xhttp.onreadystatechange = function() {
            if (this.readyState === 4 && this.status === 200) {
                var ressult = xhttp.responseText;
                document.getElementById("responseFromServer").innerHTML = xhttp.response;
            }
        };
        xhttp.open("GET",
            "api/NewUser?Username=" + Username + "&SecurityCode=" + SecurityCode,
            true);
        xhttp.send();
    }
}