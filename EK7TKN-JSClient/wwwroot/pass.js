// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let results = [];
let passes = [];
let connection = null;
let readapass = null;

setupSignalR();
getdata();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:12307/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PasswordCreated", (user, message) => {
        getdata();
    });

    connection.on("PasswordDeleted", (user, message) => {
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
    await fetch('http://localhost:5000/pass')
        .then(x => x.json())
        .then(y => {
            passes = y;
            console.log(passes);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    passes.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.passId + "</td><td>" +
            t.userId + "</td><td>" +
        t.recoverPhoneNumber + "</td><td>" +
            t.totallySecuredVeryHashedPassword + "</td><td>" +
            `<button type="button" onclick="remove(${t.passId})">Delete</button>` + "</td><td>"
            +
            `<button type="button" onclick="edit(${t.passId})">Edit</button>` + "</td><td>";
        
    });
}

function displaysingle() {
    document.getElementById('resultarea').innerHTML =
        "<tr><td>" + readapass.passId + "</td><td>" +
        readapass.userId + "</td><td>" +
        readapass.recoverPhoneNumber + "</td><td>" +
        readapass.totallySecuredVeryHashedPassword + "</td><td>" +
        `<button type="button" onclick="remove(${readapass.passId})">Delete</button>` + "</td><td>"
        +
        `<button type="button" onclick="edit(${readapass.passId})">Edit</button>` + "</td><td>";
        }

function remove(id) {
    fetch('http://localhost:5000/pass/delete/' + id, {
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
    let userID = 0
    let passID = 1
    let phone = document.getElementById('phone_').value;
    let password = document.getElementById('password_').value
    let userinfo = null;

    let json = JSON.stringify(
        {
            userInformation: null, passId: 0, userId: 1,
            recoverPhoneNumber: phone, totallySecuredVeryHashedPassword: password,
            userInformation: userinfo
        });

    console.log('"' + json + '"');
    fetch('http://localhost:5000/pass/post', {
        method: 'POST',
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

function edit(id) {
    let _userID = 1
    let _passID = parseInt(id)
    let phone = document.getElementById('phone_').value;
    let password = document.getElementById('password_').value

    let json = JSON.stringify(
        {
            userInformation: null, passId: _passID, userId: _userID,
            recoverPhoneNumber: phone, totallySecuredVeryHashedPassword: password,
        });

    console.log('"' + json + '"');
    fetch('http://localhost:5000/pass/put', {
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
    console.log("readid:" + typeof (readid))
    fetch('http://localhost:5000/pass/read/' + readid)
        .then(x => x.json())
        .then(y => {
            readapass = y
            console.log(readapass)
            displaysingle()
        })
}