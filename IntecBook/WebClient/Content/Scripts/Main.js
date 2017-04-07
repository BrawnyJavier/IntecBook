$(document).ready(function () {
    // Check if the user is logged in reading the userKey cookie
    var LoggedIn = $.cookie("userKey") ? true : false;
    // If is not, block the textarea used to compose posts
    if (LoggedIn) {
        $("#SignOutBtn").show();
        window.location.href = '/Html/Appmain.html';
    }
    else {
        $("#SignOutBtn").hide();
        $("#AjaxLoad").load("/HTML/Login.html");
    }
    $(document).on("click", "#SignOutBtn", function () {
        $.removeCookie("userKey");
        $("#SignOutBtn").hide();
        $("#AjaxLoad").load("/HTML/Login.html");
    });
    $(document).on("click", "#AccountBtn", function () {
        var IsLoggedIn = $.cookie("userKey") ? true : false;
        if (IsLoggedIn) $("#AjaxLoad").load("/HTML/Profile.html");
        else {
            $("#AjaxLoad").load("/HTML/Login.html");
        }
    });
});