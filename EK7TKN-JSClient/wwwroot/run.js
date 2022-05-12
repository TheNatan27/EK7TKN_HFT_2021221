
let results = [];
let runs = [];
let connection = null;
let readarun = null;

setupSignalR();
getdata();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:12307/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("RunCreated", (user, message) => {
        getdata();
    });

    connection.on("RunDeleted", (user, message) => {
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
    await fetch('http://localhost:5000/run')
        .then(x => x.json())
        .then(y => {
            runs = y;     
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    runs.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.userID + "</td><td>" +
            t.runID + "</td><td>" +
            t.distance + "</td><td>" +
            t.time + "</td><td>" +
            t.isCompetition + "</td><td>" +
            t.location+ "</td><td>" +
            `<button type="button" onclick="remove(${t.runID})">Delete</button>` + "</td><td>"
        +
        `<button type="button" onclick="edit(${t.runID})">Edit</button>` + "</td><td>";
        
    });
}

function displaysingle() {
    document.getElementById('resultarea').innerHTML =
        "<tr><td>" + readarun.userID + "</td><td>" +
    readarun.runID + "</td><td>" +
    readarun.distance + "</td><td>" +
    readarun.time + "</td><td>" +
    readarun.isCompetition + "</td><td>" +
    readarun.location + "</td><td>" +
        `<button type="button" onclick="remove(${readarun.runID})">Delete</button>` + "</td><td>"
        +
        `<button type="button" onclick="edit(${readarun.runID})">Edit</button>` + "</td><td>";
}

function remove(id) {
    fetch('http://localhost:5000/run/delete/' + id, {
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
    let distance = document.getElementById('distance_number').value;
    let time = document.getElementById('time_t').value;
    let location = document.getElementById('location_text').value
    let _userid = 1
    

    let json = JSON.stringify(
        {
            userInfo: null, runID: 0, userID: _userid,
            distance: distance, time: time, isCompetition: false,
            location: location
        });

    console.log('"' + json + '"');
    fetch('http://localhost:5000/run/post', {
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
    let distance = document.getElementById('distance_number').value;
    let time = document.getElementById('time_t').value;
    let location = document.getElementById('location_text').value
    let userid = 1
    let runid = id


    let json = JSON.stringify(
        {
            userInfo: null, runID: runid, userID: userid,
            distance: distance, time: time, isCompetition: false,
            location: location
        });

    console.log('"' + json + '"');
    fetch('http://localhost:5000/Run/put', {
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
    let readid = document.getElementById('runidnumber').value
    readid = parseInt(readid)
    console.log("readid:" + typeof (readid))
    fetch('http://localhost:5000/run/read/' + readid)
        .then(x => x.json())
        .then(y => {
            readarun = y
            console.log(readarun)
            displaysingle()
        })
}