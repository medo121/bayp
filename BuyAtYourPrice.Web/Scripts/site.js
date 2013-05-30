$(document).ready(function() {
    $("#log-in-drop-down").click(function() {
        $("#log-in-drop-down").toggleClass("selected");
        $("#log-in-drop-down-contents").toggle();
    });
    
    $("#account-drop-down").click(function () {
        $("#account-drop-down-contents").toggle();
    });

});

function facebookLogin() {
    $("#facebookDiv").load("/Account/ExternalLogin",
        {
            provider: $("[name=provider]").val(),
            returnUrl: "Home/Index",
            __RequestVerificationToken: $('input[name=__RequestVerificationToken]').val(),
        },function(responseTxt,statusTxt,xhr){
            if(statusTxt=="success")
                alert("External content loaded successfully!");
            if(statusTxt=="error")
                location.href = xhr.getResponseHeader("Location");
        });

}
