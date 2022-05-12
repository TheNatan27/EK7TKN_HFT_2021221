﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let results = [];
let users = [];
let connection = null;
let readuser = null;

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

function redirect1() {
    window.location.href = ('http://localhost:12307/runpage.html')
}
function redirect2() {
    window.location.href = ('http://localhost:12307/pass.html')
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
            `<button type="button" onclick="remove(${t.userID})">Delete</button>` + "</td><td>"
            +
            `<button type="button" onclick="edit(${t.userID})">Edit</button>` + "</td><td>";
        console.log(t)
    });
}

function displaysingle() {
    document.getElementById('resultarea').innerHTML = 
            "<tr><td>" + readuser.userID + "</td><td>" +
    readuser.full_Name + "</td><td>" +
    readuser.age + "</td><td>" +
    readuser.weight + "</td><td>" +
    readuser.height + "</td><td>" +
    readuser.email + "</td><td>" +
        `<button type="button" onclick="remove(${readuser.userID})">Delete</button>` + "</td><td>" +
    `<button type="button" onclick="edit(${readuser.userID})">Edit</button>` + "</td><td>";
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
    let userID = 0;
    let name = document.getElementById('username').value;
    let age = document.getElementById('agenumber').value;
    let weight = document.getElementById('weightnumber').value
    let height = document.getElementById('heightnumber').value
    let email = document.getElementById('emailinput').value;
    let premium = false;
    let runinfo = Array(0);

    

    let json = JSON.stringify(
        {
            userID: userID,
            full_Name: name, age: age, weight: weight,
            height: height, email: email, premium: premium,
            runInfo: runinfo
        });

    console.log('"' + json + '"');
    fetch('http://localhost:5000/User/post', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: "'"+json+"'"
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function edit(id) {
    let userID = id
    let name = document.getElementById('username').value;
    let age = document.getElementById('agenumber').value;
    let weight = document.getElementById('weightnumber').value
    let height = document.getElementById('heightnumber').value
    let email = document.getElementById('emailinput').value;
    let premium = false;
    let runinfo = Array(0);

    let json = JSON.stringify(
        {
            userID: userID,
            full_Name: name, age: age, weight: weight,
            height: height, email: email, premium: premium,
            runInfo: runinfo
        });

    console.log('"' + json + '"');
    fetch('http://localhost:5000/User/put', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: "'" + json + "'"
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}



function readone() {
    let readid = document.getElementById('readthisnumber').value
    readid = parseInt(readid)
    console.log("readid:" + typeof(readid))
    fetch('http://localhost:5000/user/read/' + readid)
        .then(x => x.json())
        .then(y => {
            readuser = y
            console.log(readuser)
            displaysingle()
        })
}