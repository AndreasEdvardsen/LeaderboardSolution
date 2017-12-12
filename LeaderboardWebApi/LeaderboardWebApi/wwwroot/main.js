function ClearTable() {
    document.getElementById("HighScoresTable").innerHTML = "";

    var table = document.getElementById("HighScoresTable");
    var row = table.insertRow(-1);
    var cellName = row.insertCell(0);
    var cellScore = row.insertCell(1);
    var cellTimestamp = row.insertCell(2);

    cellName.outerHTML = "<th>Name:</th>";
    cellScore.outerHTML = "<th>Score:</th>";
    cellTimestamp.outerHTML = "<th>TimeStamp:</th>";
}

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

            ClearTable();
            for (var i = 0; i < highscore.length; i++) {
                var row = table.insertRow(-1);
                var cellName = row.insertCell(0);
                var cellScore = row.insertCell(1);
                var cellTimestamp = row.insertCell(2);

                cellName.innerHTML = highscore[i].name;
                cellScore.innerHTML = highscore[i].score;
                cellTimestamp.innerHTML = highscore[i].timeStamp;
            }
            var baseUrl = "http://aeleaderboards.azurewebsites.net/api/";
            document.getElementById("AddHighscoreLink").value =
                baseUrl + "NewHighscore?UniqueId=" + uniqueId + "&Name=SCOREHOLDERSNAME&Score=SCORETOADD";
            document.getElementById("ShowHighscoreLink").value = baseUrl + "ViewHighscores?UniqueId=" + uniqueId;

            var userLogin = document.getElementById("UserLogin");
            var links = document.getElementById("Links");
            var highscores = document.getElementById("HighScores");

            userLogin.style.backgroundColor = "#50776b";
            links.style.backgroundColor = "#50776b";
            highscores.style.backgroundColor = "#50776b";
            userLogin.getElementsByTagName("H2")[0].innerHTML = "You have logged in! ";
            
        }
    };
    xhttp.open("GET", "api/ViewHighscores?id=" + uniqueId, true);
    xhttp.send();
    return false;
}