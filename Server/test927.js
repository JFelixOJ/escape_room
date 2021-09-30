const Serialport = require('serialport');
const Readline = Serialport.parsers.Readline;
const WebSocket = require('ws')

const port = new Serialport('COM3',{
    baudRate:9600
});

  const wss = new WebSocket.Server({ port: 8080 })

  wss.on('connection', ws => {
    ws.on('message', message => {
      console.log(`Received message => ${message}`)
    })

const parser = port.pipe(new Readline({delimiter:'\r\n'}));

parser.on('open',function(){
    console.log('connection is opened');
});

parser.on('data',function(data){
    let temp = parseInt(data , 10) + " ℃"
    console.log(temp);
    ws.send(temp);
});

parser.on('error',function(err){
    console.log(err);
    ws.send(err);
});




wss.on('listening', () =>
{
    console.log('listening on 8080')
})

  })