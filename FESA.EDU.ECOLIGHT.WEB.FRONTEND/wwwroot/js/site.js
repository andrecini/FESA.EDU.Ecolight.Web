$(document).ready(function () {
    var activeItem = locaStorage.getItem("activeItem");

    if (activeItem) {
        $(".menu-item").eq(activeItem).addClass("active");
    }
    else {
        $("#dashboard").eq(activeItem).addClass("active");
    }

    $(".menu-item").click(function () {
        $(".menu-item").removeClass("active");

        $(this).addClass("active");

        var index = $(".menu-item").index(this);
        localStorage.setItem('activeItem', index);
    });
});