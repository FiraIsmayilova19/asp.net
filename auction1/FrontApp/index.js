const url = "https://localhost:7149/";

const connection = new signalR.HubConnectionBuilder()
    .withUrl(url + "offers")
    .configureLogging(signalR.LogLevel.Information)
    .build();

let lastBidder = null;
let timer = null;

async function start() {
    try {
        await connection.start();

        $.get(url + "api/Offer", function (data, status) {
            const element = document.querySelector("#offerValue");
            element.innerHTML = "Begin price : " + data + "$ ";
        });

        console.log("SignalR Started");
    } catch (err) {
        console.log(err);
        setTimeout(() => {
            start();
        }, 5000);
    }
}

start();

connection.on("ReceiveMessage", (username, offer) => {
    let element = document.querySelector("#responseOfferValue");
    element.innerHTML = username + " bid: " + offer + "$ ";

    clearTimeout(timer);
    lastBidder = username;
    
    timer = setTimeout(() => {
        if (lastBidder === username) {
            disableButton(username);
            element.innerHTML += " (Winner!)";
        }
    }, 10000);
});

connection.on("AuctionEnded", (winner) => {
    let element = document.querySelector("#responseOfferValue");
    element.innerHTML += " (Winner: " + winner + ")";

    if (document.querySelector("#user").value === winner) {
        document.querySelector("#bitBtn").disabled = true;
    }
});

async function IncreaseOffer() {
    let user = document.querySelector("#user");
    $.get(url + "api/Offer/Increase?data=100", function (data, status) {
        $.get(url + "api/Offer", function (data, status) {
            connection.invoke("SendMessage", user.value, data);
        });
    });
}

function disableButton(username) {
    let currentUser = document.querySelector("#user").value;
    if (currentUser === username) {
        document.querySelector("#bitBtn").disabled = true;
    }
}
