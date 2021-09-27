
const five = require("johnny-five");
const board = new five.Board();


board.on("ready", function() {

  button = new five.Button({
    pin: 9,
    isPullup: true
  });

  led = new five.Led(9);

  button.on("down", function(value) {
    led.on();
    console.log('on')
  });

  button.on("up", function() {
    led.off();
    console.log('off')
  });

});