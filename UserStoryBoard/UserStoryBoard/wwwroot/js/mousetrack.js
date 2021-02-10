var mouse = {x: 0, y: 0};

$(document).on("mousemove", function (event) {
    mouse = {x: event.pageX, y: event.pageY};
});