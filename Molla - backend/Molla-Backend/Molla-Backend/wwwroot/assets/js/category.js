$(document).ready(function () {
    $(".nameofcard").click(function () {
        var innerText = $(this).text();
        console.log(innerText);
        var data = { searchText: innerText };
        $.ajax({
            type: 'Get',
            url: shop/gettext',
            data: data,
            success: function (result) {
                console.log("Lannn");
            }
        });
    });
});

