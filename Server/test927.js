const Serialport = require('serialport');
const Readline = Serialport.parsers.Readline;

const port = new Serialport('COM3',{
    baudRate:9600
});

const parser = port.pipe(new Readline({delimiter:'\r\n'}));

parser.on('open',function(){
    console.log('connection is opened');
});

parser.on('data',function(data){
    let temp = parseInt(data , 10) + " ℃"
    console.log(temp);
});

parser.on('error',function(err){
    console.log(err);
});