const WebSocket = require('ws');

const server = new WebSocket.Server({ port: 8080 });
let players = {};

server.on('connection', ws => {
    ws.on('message', message => {
        let data = JSON.parse(message);
        
        if (data.type === 'join') {
            players[data.id] = ws;
            console.log(`Player ${data.id} connected.`);
        }

        if (data.type === 'move') {
            broadcast(data);
        }
    });

    ws.on('close', () => {
        let playerId = Object.keys(players).find(id => players[id] === ws);
        delete players[playerId];
        console.log(`Player ${playerId} disconnected.`);
    });
});

function broadcast(data) {
    Object.values(players).forEach(player => {
        player.send(JSON.stringify(data));
    });
}

console.log("Multiplayer server running on ws://localhost:8080");
