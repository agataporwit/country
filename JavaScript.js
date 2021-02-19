
var azureUrl = "https://ccgrestapi1.azurewebsites.net/midtermsagatajelen/gdp";
var localUrl = "https://localhost:44359/midtermsagatajelen/gdp?country";

    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const page_type = urlParams.get('country');

function buildTable(arr)
{
    for (let i = 0; i < arr.length; i++)
    {
            var row = document.getElementById("first").insertRow(i + 1);
            var cell = row.insertCell(0);
            cell.innerText = arr[i].country;
            cell = row.insertCell(1);
            cell.innerText = arr[i].gdp;
    }
}
function loadTable() {
    var response
    if (page_type === null) {
        response = fetch(azureUrl);
    }
    else {
        response = fetch(azureUrl + "?country=" + page_type);
        response.then((data) => data.json().then((arr) => buildTable(arr)));
    }
}
