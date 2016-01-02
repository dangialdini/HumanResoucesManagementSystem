$(function () {


    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/EnhancementRequest", 
                dataType: "json"
            }
        }
    }); 

        $("#autocomplete").kendoAutoComplete({
            dataSource: dataSource, 
            dataTextField: "Project"
        }); 


});
