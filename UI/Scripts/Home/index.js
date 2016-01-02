$(function () {

    $("#save").click(function () {

        var Street = $("#street").val();
        var Suburb = $("#suburb").val();
        
        $.ajax({
            url: 'api/address',
            type: 'POST',
            data: {
                "Street1": Street, "SuburbId": Suburb
            },
            success:function(data)
            {
                debugger;
            },
            error:function(data)
            {
                debugger;
            },
        });

    });

})