(function () {

    var gridDataSource = new kendo.data.DataSource({
        batch: false,
        transport: {
            read: {
                url: "/api/Training",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/Training",
                type: "POST",
                dataType: "json",

            },
            update: {
                url: "/api/Training",
                type: "PUT",
                dataType: "json",

            },
            destroy: {
                url: "/api/Training",
                type: "DELETE",
                dataType: "json",

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
                fields: {
                    Id: { editable: false, nullable: true, type: "number" },
                    //TrainingType: { editable:true, defaultValue: { Id: 1 }, validation: { required: true } },
                    TrainingTypeId: { type: "number", nullable: true },
                    TrainingTypeName: {},
                    RatePerHour: { nullable: false, type: "number" }
                }
            }
        }
    });


    $("#grid").kendoGrid({

        width:500,
        height: 750,
        groupable: true,
        sortable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 100
        },
        detailTemplate: kendo.template($("#template").html()),
        detailInit: detailInit,
        dataBound: function(){
            this.expandRow(this.tbody.find("tr.k-master-row").first());
        },

        dataSource: gridDataSource,

        columns: [{
            field: "TrainingTypeId",
            title: "Training Type",
            editor: categoryDropDownEditor,
            width: 240,
            template: "#= TrainingTypeName #"
        },
         {
             field: "RatePerHour",
             title: "Rate Per Hour",
             editor: function (container, options) {
                 //create input element and add the validation attribute
                 var input = $('<input name="' + options.field + '" required min="1" />');
                 //append the editor
                 input.appendTo(container);
                 //enhance the input into NumericTextBox
                 input.kendoNumericTextBox({
                     format: "c", min: 0, step: 0.0
                 });
             },
             width: 240
         },
         {
             command: [
                 { id: "edit", name: "edit" },
                 { id: "destroy", name: "destroy" },
                 
                 //{text:"Type",click:showTrainingType}
             ]
         }
        ],
        editable: "popup",

        toolbar: [{ name: "create", text: "Create new Training" },"excel","pdf"]
    });

})();

function detailInit(e) {
    var detailRow = e.detailRow;
    detailRow.find(".tabstrip").kendoTabStrip({
        animation: {
            open: { effects: "fadeIn" }
        }
    });
    detailRow.find(".trainingtype").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: "/api/TrainingType",
                    type: "GET",
                    dataType: "json"
                }
            },
            filter: {
                field: "Id",
                operator: "eq",
                value: e.data.get("TrainingTypeId")
            }
        },
        columns: [
            { field: "Name", title: "Name", width: "100px" },
            { field: "Description", title: "Description", width: "150px" },
            { field: "DurationInMinutes", title: "Duration", width: "70px" }

        ]
    });
}



//dropdownlist for training type

//function categoryDropDownEditor(container, options) {
//    $("<input required data-bind='value:TrainingType'/>")
//        .appendTo(container)
//        .kendoDropDownList({
//            name: "TrainingType", autoBind: false, dataTextField: "title",
//            dataValueField: "id", dataSource: gridExample
//        })
//}



//Numeric text box control
//function Numerictextbox(container, options) {
//    $("<input required data-bind='value:RatePerHour'/>")
//        .appendTo(container)
//        .kendoNumericTextBox({
//            format: "c", min: 0, step: 0.0
//        });
//}

function categoryDropDownEditor(container, options) {
    $('<input name="TrainingTypeId" required />')
        .appendTo(container)
        .kendoDropDownList({
            autoBind: false,
            optionLabel: "--     Select    --",
            dataTextField: "Name",
            dataValueField: "Id",
            dataSource: {
                batch: false,
                transport: {
                    read: {
                        url: "/api/Training/GetTrainingType",
                        type: "GET",
                        dataType: "json"
                    }
                },
                schema: {
                    model: {
                        id: "Id"
                    }
                }
            }
        });
}








