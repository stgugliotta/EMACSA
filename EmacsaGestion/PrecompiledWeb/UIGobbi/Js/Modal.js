// JScript File
var ventanaPopup = null;
var ValorDeRetorno;

function showPopWin(url, title, width, height, returnFunc) {
    var args = "dialogWidth:" + width + "px;dialogHeight:" + height + "px";
    ValorDeRetorno = window.showModalDialog(url, "_blank", args);
}




function controlPopup() {
    if (ventanaPopup == null) {
        return;
    } else if (!ventanaPopup.closed) {
        ventanaPopup.focus();
    }
}
window.onfocus = controlPopup;
