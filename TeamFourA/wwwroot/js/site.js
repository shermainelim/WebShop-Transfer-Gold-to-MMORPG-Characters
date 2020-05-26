// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#loginBtn").click(function () {
        var uname = $("#uname").val();
        var pwd = $("#pwd").val();
        if (uname.length === 0 || pwd.length === 0)
        {
            setErrorMsg("errmsg", "all_fields_required");
            return;              
        }
        
        $("#hashPwd").val(CryptoJS.SHA256(pwd).toString());
        $("#pwd").val("");

        $("#loginForm").submit();
    });

    $("#registerBtn").click(function () {
        var uname = $("#uname").val();
        var pwd = $("#pwd").val();
        var pwd_again = $("#pwd_again").val();

        if (uname.length === 0 || pwd.length === 0 || pwd_again.length === 0) {
            setErrorMsg("errmsg", "all_fields_required");
            return;
        }

        if (pwd !== pwd_again) {
            setErrorMsg("errmsg", "unmatch_passwords");
            return;
        }

        $("#hashPwd").val(CryptoJS.SHA256(pwd).toString());
        $("#pwd").val("");
        $("#pwd_again").val("");

        $("#registerForm").submit();
    });

    $(".locale").click(function (event) {
        var target = event.target;
        var locale = target.getAttribute("data-locale");
        if (window.location.href.indexOf("Login") !== -1)
            window.location = "/Login/Index?locale=" + locale;
        else
            window.location = "/Register/Index?locale=" + locale;
    });

    $("input").focus(function () {
        $("#errmsg").html("");
    });          
});

function setErrorMsg(targetId, stringId) {
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Locale/GetStringById",
        data: JSON.stringify({ stringId: stringId }),
        success: function (response) {
            if (response) {
                response = JSON.parse(response);
                $("#" + targetId).html(response.msg)
            }
        }
    });
}