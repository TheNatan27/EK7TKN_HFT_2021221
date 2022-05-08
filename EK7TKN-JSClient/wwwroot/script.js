// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let actors = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62000/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ActorCreated", (user, message) => {
        getdata();
    });

    connection.on("ActorDeleted", (user, message) => {
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

async function getdata() {
    await fetch('http://localhost:53910/actor')
        .then(x => x.json())
        .then(y => {
            actors = y;
            //console.log(actors);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    actors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.actorId + "</td><td>"
            + t.actorName + "</td><td>" +
            `<button type="button" onclick="remove(${t.actorId})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:53910/actor/' + id, {
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

function create() {
    let name = document.getElementById('actorname').value;
    fetch('http://localhost:53910/actor', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { actorName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}