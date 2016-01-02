//Sale Lead Index - Team C

$(function () {

    var datasource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/SaleLeads",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/SaleLeads",
                type: "POST",
                contentType: "application/json",
                dataType: "json"
            },
            update: {
                url: "/api/SaleLeads",
                type: "PUT",
                contentType: "application/json",
                dataType: "json"
            },
            destroy: {
                url: "/api/SaleLeads",
                type: "DELETE",
                contentType: "application/json"
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        },
        pageSize: 10,
        schema: {
            model: {
                id: "Id",
                fields: {
                    Id: { editable: false },
                    SaleLeadState: { defaultValue: { Id: 0, Name: "" } },
                    //CustomerId: { editable: false },
                    Customer: { editable: true, defaultValue: { Id: 0, Name: "" } },
                    SaleId: { type: "number" },
                    Timestamp: { type: "date", validation: { required: true } }
                }

            }

        }
    });



    $("#leads-table").kendoGrid({
        dataSource: datasource,
        pageable: true,
        sortable: true,
        height: 550,
        toolbar: ["create"],
        columns: [
            { field: "Id", title: "Lead", width: "100px" },
            { field: "SaleLeadState", title: "State", width: "120px", editor: stateDropDownEditor, template: "#= SaleLeadState.Name #" },
            { field: "Customer", title: "Customer Name", width: "120px", editor: customerDropDownEditor, template: "#= Customer.Name #" },
            { field: "SaleId", title: "Sale", width: "100px" },
            { field: "Timestamp", title: "Timestamp", format: "{0:MMMM dd, yyyy}", width: "140px" },
            { command: ["edit", "destroy"], title: "Commands", width: "250px" }],
        editable: {
            mode: "popup"
            //template: kendo.template($("#popup_editor").html())

        }

    });

    function stateDropDownEditor(container, options) {
        $('<input required data-text-field="Name" data-value-field="Id" data-bind="value: ' + options.field + '" />')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                optionLabel: "Select ",
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/saleLeadStates",
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

    function customerDropDownEditor(container, options) {
        $('<input required data-text-field="Name" data-value-field="Id" data-bind="value: ' + options.field + '" />')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                optionLabel: "Select ",
                filter: "contains",
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/saleLeadCustomers",
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

    //function saleDropDownEditor(container, options) {
    //    $('<input required data-text-field="Id" data-value-field="Id" data-bind="value: ' + options.field + '" />')
    //        .appendTo(container)
    //        .kendoDropDownList({
    //            autoBind: false,
    //            dataSource: {
    //                transport: {
    //                    read: {
    //                        url: "/api/saleLeadCustomers",
    //                        type: "GET",
    //                        dataType: "json"
    //                    }
    //                },
    //                schema: {
    //                    model: {
    //                        id: "Id"
    //                    }
    //                }
    //            }
    //        });
    //}






});