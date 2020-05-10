$(document).ready(function () {
    $("body").append("<div id='baseChatBox' style='position:fixed; right:0.5rem; bottom:0.5rem; z-index:1000;height:0;border:1px solid #6dc139 !important; border-radius:5px !important;'><iframe src='https://chatbox.mcredit.com.vn/WebChat/Index' style='width:100%;height:100%;border:0 !important;'></iframe></div>");
});
window.addEventListener('message', function (message) {
    var lstCmd = message.data.split('|');
    if (lstCmd.length > 1 && lstCmd[0] == "CLOSE") {
        // do colse on customer site
        $('#baseChatBox').height(eval(lstCmd[1]));
    }
    else if (lstCmd.length > 1 && lstCmd[0] == "OPEN") {
        $('#baseChatBox').height(eval(lstCmd[1]));
    }
});