$(document).ready(function () {
    $(".nav-button").click(function () {
        $(".nav-button").removeClass("active");
        $(this).addClass("active");
        $(".main-content").hide();
    });
});