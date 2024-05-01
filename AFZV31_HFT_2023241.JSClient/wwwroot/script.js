let annuals = [];
let areas = [];
let orders = [];
let connection = null;
let annualIdToUpdate = -1;
let areaIdToUpdate = -1;
let orderIdToUpdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:6495/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    //ANNUAL
    connection.on("AnnualCreated", (user, message) => {
        getdata();
    });

    connection.on("AnnualDeleted", (user, message) => {
        getdata();
    });

    connection.on("AnnualUpdated", (user, message) => {
        getdata();
    });
    //AREA
    connection.on("AreaCreated", (user, message) => {
        getdata();
    });

    connection.on("AreaDeleted", (user, message) => {
        getdata();
    });

    connection.on("AreaUpdated", (user, message) => {
        getdata();
    });
    //ORDER
    connection.on("OrderCreated", (user, message) => {
        getdata();
    });

    connection.on("OrderDeleted", (user, message) => {
        getdata();
    });

    connection.on("OrderUpdated", (user, message) => {
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
    await fetch('http://localhost:6495/annual') 
        .then(x => x.json())
        .then(y => {
            annuals = y;
            display();
        });

    await fetch('http://localhost:6495/area')
        .then(x => x.json())
        .then(y => {
            areas = y;
            display();
        });

    await fetch('http://localhost:6495/order')
        .then(x => x.json())
        .then(y => {
            orders = y;
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
            `<button type="button" onclick="showupdateAnnual(${t.annualId})">Update</button>`
             "</td></tr>";
    })

    document.getElementById('resultarea2').innerHTML = "";
    areas.forEach(t => {
            document.getElementById('resultarea2').innerHTML +=
                "<tr><td>" + t.areaId + "</td><td>"
                + t.areaSize + "</td><td>" +
                `<button type="button" onclick="removeArea(${t.areaId})">Delete</button>` +
                `<button type="button" onclick="showupdateArea(${t.areaId})">Update</button>`
            "</td></tr>";
    })

    document.getElementById('resultarea3').innerHTML = "";
    orders.forEach(t => {
        document.getElementById('resultarea3').innerHTML +=
            "<tr><td>" + t.orderId + "</td><td>"
        + t.orderCompany + "</td><td>" +
            `<button type="button" onclick="removeOrder(${t.orderId})">Delete</button>` +
            `<button type="button" onclick="showupdateOrder(${t.orderId})">Update</button>`
        "</td></tr>";
    })
        ;
}
function showupdateAnnual(id)
{
    document.getElementById('annualnametoupdate').value = annuals.find(t => t['annualId'] == id)['annualName']
    document.getElementById('updateformdiv').style.display = 'flex';
    annualIdToUpdate = id;
}

function showupdateArea(id)
{
        document.getElementById('areasizetoupdate').value = areas.find(t => t['areaId'] == id)['areaSize']
        document.getElementById('updateformdiv2').style.display = 'flex';
        areaIdToUpdate = id;
}

function showupdateOrder(id)
{
    document.getElementById('ordernametoupdate').value = orders.find(t => t['orderId'] == id)['orderCompany']
        document.getElementById('updateformdiv3').style.display = 'flex';
         orderIdToUpdate = id;
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

function removeArea(id) {

    fetch('http://localhost:6495/area/' + id, {
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

function removeOrder(id) {

    fetch('http://localhost:6495/order/' + id, {
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

function createArea() {
    let name = document.getElementById('areasize').value;
    fetch('http://localhost:6495/area', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { areaSize: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function createOrder() {
    let name = document.getElementById('ordername').value;
    fetch('http://localhost:6495/order', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { orderCompany: name })
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
    document.getElementById('updateformdiv').style.display = 'flex';
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

function updateArea() {

    let size = document.getElementById('areasizetoupdate').value;
    document.getElementById('updateformdiv2').style.display = 'flex';
    fetch('http://localhost:6495/area/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { areaSize: size, areaId: areaIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function updateOrder() {

    let name = document.getElementById('ordernametoupdate').value;
    document.getElementById('updateformdiv3').style.display = 'flex';
    fetch('http://localhost:6495/order', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { orderCompany: name, orderId: orderIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}


