card_drag_id = -1;

function card_drag(id) {
    event.preventDefault();
    card_drag_remove();

    card_drag_id = id;

    var card = document.getElementById(id);
    var drag = document.createElement('div');
    drag.id = "cardDrag";

    const cardStyle = getComputedStyle(card);
    Array.from(cardStyle).forEach(key => drag.style.setProperty(key, cardStyle.getPropertyValue(key), cardStyle.getPropertyPriority(key)))
    drag.className = card.className;

    $(card).children().appendTo(drag);

    /* Set misc style options */
    drag.style.zIndex = "500";
    drag.style.position = "absolute";
    card.style.opacity = "0.5";

    /* Set drag to mouse position */
    drag.style.left = mouse.x + "px";
    drag.style.top = mouse.y + "px";

    document.getElementsByTagName('body')[0].appendChild(drag);

    document.addEventListener('mouseup', function () {
        //card_drag_remove();
        document.getElementById(card_drag_id).style.opacity = "1";
    }, true);
    document.addEventListener('mousemove', function (event) {
        var d = document.getElementById('cardDrag');
        if (d !== null) {
            d.style.left = mouse.x + 'px';
            d.style.top = mouse.y + 'px';
        }
    }, true);
}

function card_drop(card_id, column, boardId, column_id) {
    if (card_drag_id >= 0) {
        var ajaxReq = ajaxSupport();

        ajaxReq.open("GET", '/UserStories/MoveUserStory/' + card_id + '/' + boardId + '/' + column_id, true);
        ajaxReq.send(null);

        ajaxReq.onreadystatechange = function () {
            if (ajaxReq.readyState == 4 && ajaxReq.status == 200) {
                column.appendChild(document.getElementById(card_id));
                location.reload();
            }
        };

        card_drag_id = -1;
    }
}

function card_drag_remove() {
    var drag = document.getElementById('cardDrag');
    if (drag !== null) {
        drag.parentNode.removeChild(drag);
    }
}