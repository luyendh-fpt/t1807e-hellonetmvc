$(document).ready(function () {
    $("input[value='Search']").click(function (e) {
        var keyword = $("input[name='keyword']").val();
        var age = $("input[name='age']").val();

        $.ajax({
            type: "POST",
            url: `/Customers/GetListAjax?keyword=${keyword}&age=${age}`,
            success: function (response) {
                $("table").html(response);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });

        e.preventDefault();
        return false;
    });

});