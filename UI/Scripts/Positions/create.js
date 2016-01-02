$(function () {
    $("#save").click(function () {

        var Position = $("#name").val();
        var Description = $("#description").val();

        $.ajax({
            url: '/api/positions',            
            type: 'POST',
            datatype: 'json',
            data: {
                "Name": Position, "Description": Description
            },
            success: function (data) {
                debugger;
            },
            error: function (data) {
                debugger;
            },
        });
    });
});