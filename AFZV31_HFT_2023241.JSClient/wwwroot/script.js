﻿let annuals = [];
let connection = null;
let annualIdToUpdate = -1;
getdata();
setupSignalR();


async function getdata() {
    await fetch('http://localhost:6495/annual')
        .then(x => x.json())
        .then(y => {
            annuals = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    annuals.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.annualId + "</td><td>"
            + t.annualName + "</td><td>" +
            `<button type="button" onclick="remove(${t.annualId})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.annualId})">Update</button>`
            + "</td></tr>";
    });
}
function showupdate(id) {
    document.getElementById('annualnametoupdate').value = annuals.find(t => t['annualId'] == id)['annualName']
    document.getElementById('updateformdiv').style.display = 'flex';
    annualIdToUpdate = id;
}
function remove(id) {
    fetch('http://localhost:6495/annual/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:6495/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AnnualCreated", (user, message) => {
        getdata();
    });

    connection.on("AnnualDeleted", (user, message) => {
        getdata();
    });

    connection.on("AnnualUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

function create() {
    let name = document.getElementById('annualname').value;
    fetch('http://localhost:6495/annual', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { annualName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {

    let name = document.getElementById('annualnametoupdate').value;
    document.getElementById('updateformdiv').style.display = 'none';
    fetch('http://localhost:6495/annual', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { annualName: name, annualId: annualIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}


