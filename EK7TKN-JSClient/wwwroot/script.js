// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let results = [];
let users = [];
let connection = null;

setupSignalR();
getdata();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:12307/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("UserCreated", (user, message) => {
        getdata();
    });

    connection.on("UserDeleted", (user, message) => {
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
    await fetch('http://localhost:5000/user')
        .then(x => x.json())
        .then(y => {
            users = y;
            console.log(users);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    users.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.userID + "</td><td>" +
        t.full_Name + "</td><td>" +
        t.age + "</td><td>" +
            t.weight + "</td><td>" +
            t.height + "</td><td>" +
            t.email + "</td><td>" +
            `<button type="button" onclick="remove(${t.userID})">Delete</button>` + "</td><td>";
    });
}

function remove(id) {
    fetch('http://localhost:5000/user/delete/' + id, {
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
    let name = document.getElementById('username').value;
    let age = document.getElementById('agenumber').value;
    let weight = document.getElementById('weightnumber').value;
    let height = document.getElementById('heightnumber').value;
    let email = document.getElementById('emailinput').value;
    let premium = document.getElementById('premiumcheck').value;
    fetch('http://localhost:5000/user', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                full_Name: name, Age: age, Weight: weight,
                Height: height, Email: email, Premium: premium
                
            })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}