function newUser() {
    var xhttp = new XMLHttpRequest();
    var Username = document.getElementById('Username').value;
    var SecurityCode = document.getElementById('SecurityCode').value;

    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("responseFromServer").innerHTML = JSON.parse(xhttp.responseText);
        }
    };    
    xhttp.open("GET", "http://aeleaderboards.azurewebsites.net/api/NewUser?Username=" + Username + "&SecurityCode=" + SecurityCode, true);
    xhttp.setRequestHeader('Access-Control-Allow-Origin', '*');
    xhttp.send();
}