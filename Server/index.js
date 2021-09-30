const WebSocket = require('ws')

const wss = new WebSocket.Server({ port: 8080 }, () => {

    console.log('server started')

})

wss.on('connection', function connection(ws) {

        console.log("test");


    ws.on('message', (data) => {


        // console.log(buffer.toString('utf8')('data received \n %o', data));
        const buf = Buffer.from(data, 'utf8');
        buf.toString()
        console.log(buf.toString());


        
        ws.send(buf.toString());
    })

})

wss.on('listening', () =>
{
    console.log('listening on 8080')
})