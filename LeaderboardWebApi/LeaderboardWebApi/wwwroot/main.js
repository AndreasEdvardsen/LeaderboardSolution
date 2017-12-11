document.getElementById("NewUserForm").onsubmit = function newUser() {
    var xhttp = new XMLHttpRequest();
    var Username = document.getElementById('Username').value;
    var SecurityCode = document.getElementById('SecurityCode').value;

    if (Username !== "" && SecurityCode !== "") {
        xhttp.onreadystatechange = function() {
            if (this.readyState === 4 && this.status === 200) {

                var ressult = JSON.parse(xhttp.responseText);
                document.getElementById("responseFromServer").innerHTML = ressult;
            }
        };
        xhttp.open("GET",
            "api/NewUser/isForm?Username=" + Username + "&SecurityCode=" + SecurityCode,
            true);
        xhttp.send();
    }
}

document.getElementById("UserLoginForm").onsubmit = function() {
    var xhttp = new XMLHttpRequest();
    var uniqueId = document.getElementById("UniqueIdField").value;
    var table = document.getElementById("HighScoresTable");

    xhttp.onreadystatechange = function() {
        if (this.readyState === 4 && this.status === 200) {
            var ressults = JSON.parse(this.responseText);
            var highscore = ressults.highscores;

            for (var ressult in highscore) {
                var row = table.insertRow(1);
                var cellName = row.insertCell(0);
                var cellScore = row.insertCell(1);
                var cellTimestamp = row.insertCell(2);
                cellName.innerHTML = ressult.name;
                cellScore.innerHTML = ressult.score;
                cellTimestamp.innerHTML = ressult.timeStamp;
            }

        }
    };
    xhttp.open("GET","api/ViewHighscores?id=" + uniqueId, true);
    xhttp.send();
}