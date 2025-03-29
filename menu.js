// Connect to WebSocket server
const socket = new WebSocket('localhost:8080');

// When connected
socket.onopen = () => {
    console.log("Connected to WebSocket server.");
};

// When receiving a message
socket.onmessage = (event) => {
    let data = JSON.parse(event.data);
    console.log("Received:", data);
};

// When connection closes
socket.onclose = () => {
    console.log("Disconnected from WebSocket server.");
};

// When an error occurs
socket.onerror = (error) => {
    console.error("WebSocket error:", error);
};

// Function to send a message
function sendMessage(type, id) {
    socket.send(JSON.stringify({ type, id }));
}
