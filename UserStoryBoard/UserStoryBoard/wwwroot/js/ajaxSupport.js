function ajaxSupport() {
    var ajaxRequest;

    try {
        // Opera 8.0+, Firefox, Safari
        ajaxRequest = new XMLHttpRequest();
    } catch(e) {
        //IE
        try {
            ajaxRequest = new ActiveXObject("Msxml2.XMLHTTP");
        } catch(e) {
            try {
                ajaxRequest = new ActiveXObject("Microsoft.XMLHTTP");
            } catch(e) {
                alert("Your browser doesn't support Ajax.");
                return false;
            }
        }
    }

    return ajaxRequest;
}