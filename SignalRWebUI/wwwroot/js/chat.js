"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7171/SignalRHub")
    .build();

// Başta butonu kapat
var sendButton = document.getElementById("sendButton");
sendButton.disabled = true;

// Mesaj alma
connection.on("ReceiveMessage", function (user, message) {

    var now = new Date();
    var hour = now.getHours().toString().padStart(2, "0");
    var minute = now.getMinutes().toString().padStart(2, "0");

    var li = document.createElement("li");

    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user;

    li.appendChild(span);
    li.appendChild(
        document.createTextNode(`: ${message} - ${hour}:${minute}`)
    );

    document.getElementById("messageList").appendChild(li);
});

// Bağlantıyı başlat
connection.start()
    .then(function () {
        sendButton.disabled = false;
    })
    .catch(function (err) {
        console.error(err.toString());
    });

// Mesaj gönderme
sendButton.addEventListener("click", function (event) {
    event.preventDefault();

    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    if (user === "" || message === "") return;

    connection.invoke("SendMessage", user, message)
        .catch(function (err) {
            console.error(err.toString());
        });

    document.getElementById("messageInput").value = "";
});
