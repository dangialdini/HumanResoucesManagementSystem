(function () {


    var DataSource = new kendo.data.DataSource({
        batch: false,
        transport: {
            read: {
                url: "/api/TrainingType",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/TrainingType",
                type: "POST",
                dataType: "json"
                
            },
            update: {
                url: "/api/TrainingType",
                type: "PUT",
                dataType: "json"
                
            },
            destroy: {
                url: "/api/TrainingType",
                type: "DELETE"
                
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        },
        type: 'aspnetmvc-ajax', pageSize: 5,

        schema: {
            data: function (response) {
                if (response.hasOwnProperty('Data')) {
                    return response.Data;
                } else {
                    return response;
                }
            },
            total: 'Total', errors: 'Errors',
            model: {
                id: "Id",
                field: {
                    Id: { editable: false },
                    Name: { editable: true, nullable: false, validation: { required: true }},
                    Description: { editable: true, nullable: false, validation: { required: true } },
                    DurationInMinutes:{ nullable:false,type:"number"}
                    
                }
            }
        }
    });


    $("#traininggrid").kendoGrid({
        width: 500,
        batch: false,
        height: 750,
        groupable: true,
        sortable: true,
        filterable: {row:true},
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 100
        },

        dataSource: DataSource,

        columns: [
            {
                field: "Name",
                title: "Name",
                width: "200px",
                editor: function (container, options) {
                    //create input element and add the validation attribute
                    var input = $('<input name="' + options.field + '" class="k-input k-textbox" required />');
                    //append the editor
                    input.appendTo(container);
                }
            },
            {
                field: "Description",
                title: "Description",
                
                width: "500px",
                editor: function (container, options) {
                    //create input element and add the validation attribute
                    var input = $('<input name="' + options.field + '" class="k-input k-textbox" required />');
                    //append the editor
                    input.appendTo(container);
                }

            },
            {
                 field: "DurationInMinutes",
                 title: "Duration",
                 editor: Numerictextbox,
                 width: "200px"
            },

            {
                 command: [
                     { id: "edit", name: "edit" },
                     { id: "destroy", name: "destroy" },
                     {text:"View Details",click:showDetails}
                 ]
            }
        ],
        editable: "inline",
        toolbar: [{ name: "create", text: "Create Training Type" }, "excel", "pdf"]
    });

})();






//Numeric text box control
function Numerictextbox(container, options) {
    $("<input required data-bind='value:DurationInMinutes'/>")
        .appendTo(container)
        .kendoNumericTextBox({
            format: "# minutes", min: 1, max: 10000, step: 1
        });
}

//ShowDetails.
var wnd = $("#details").kendoWindow({
    title: "Training Type Details",
    modal: true,
    visible: false,
    resizable: false,
    width: 400
}).data("kendoWindow");

var detailsTemplate = kendo.template($("#template").html());

function showDetails(e) {
    e.preventDefault();

    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();
}


