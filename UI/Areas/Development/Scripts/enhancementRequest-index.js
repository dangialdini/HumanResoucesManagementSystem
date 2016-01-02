$(function () {

    var erDataSource = new kendo.data.DataSource({
        //type: 'aspnetmvc-ajax',
        transport: {
            read: {
                url: "/api/EnhancementRequest",
                type: "GET",
                dataType: "JSON"

            },
            create: {
                url: "/api/EnhancementRequest",
                type: "POST",
                dataType: "JSON",
                contentType: "application/json"
            },
            update: {
                url: "/api/EnhancementRequest",
                dataType: "JSON",
                type: "PUT",
                contentType: "application/json"
            },
            destroy: {
                url: "/api/EnhancementRequest",
                dataType: "JSON",
                type: "DELETE",
                contentType: "application/json"
            },

            parameterMap: function (data, type) {
                return kendo.stringify(data);
            },
        },
        schema: {
            model: {
                id: "Id",
                fields: {
                    Id: {
                        editable: false,
                        nullable: true,
                        type: "number"
                    },
                    //CustomerId: {
                    //    editable: true,
                    //    nullable: false,
                    //    validation: { required: true},
                    //    type: "number"
                    //},
                    Customer:
                        {
                            editable: true,
                            defaultValue: {
                                Id: 0,
                                Name: ""
                            }
                        },
                    Description: {
                        editable: true,
                        nullable: false,
                        validation: { required: true },
                        type: "string"
                    },
                    Weight: {
                        editable: true,
                        nullable: false,
                        type: "number"
                    },
                    //OutcomeId: {
                    //    max: 3,
                    //    editable: true, 
                    //    nullable: false,
                    //    type: "number"
                    //},
                    Outcome: {
                        editable: true,
                        //nullable: true,
                        defaultValue: {
                            Id: 1,
                            Result: "Pending"
                        }
                    },
                    Timestamp: {
                        type: "date",
                        validation: { required: true }
                    }
                }
            }
        },
    });

    $("#grid").kendoGrid({
        dataSource: erDataSource,
        height: 600,
        filterable: true,
        sortable: true,
        pageable: true,
        resizable: true,
        groupable: true,
        toolbar: ["create"],
        columns: [
            {
                field: "Customer.Name",
                title: "Customer",
                editor: customerDropDownEditor,
                template: "#=Customer.Name#"
            },
            {
                field: "Description",
                title: "Description"
            },
            {
                field: "Weight",
                title: "Priority"
            },
            {

                field: "Outcome.Result",
                title: "Outcome",
                editor: outcomeDropDownEditor,
                template: "#=Outcome.Result#"
            },
            { 
                field: "Timestamp", 
                title: "Timestamp", 
                format: "{0:yyyy-MM-dd, HH:mm}", 
                width: "120px" 
            },
            {
                command: ["edit", "destroy"]
            },
        ],
        editable: {
            mode: 'popup',
            template: kendo.template($("#popup-editor").html()),
            window: { draggable: true }
        },
        edit: function (e) {
            debugger;
            var outcomeInput = e.container.find("[Name=\"Outcome\"]");
            outcomeInput.kendoDropDownList({
                autoBind: false,
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/enhancementRequestOutcomes/",
                            dataType: "json",
                            type: "GET"
                        }
                    }
                }
            });

            var customerInput = e.container.find("[Name=\"Customer\"]");
            customerInput.kendoDropDownList({
                autoBind: false,
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/enhancementRequestCustomers/",
                            dataType: "json",
                            type: "GET"
                        }
                    }
                }
            });
        }
    });


    function outcomeDropDownEditor(container, options) {
        debugger;
        // By doing this we make the field we bind to when editing/adding Outcome instead of Outcome.Result
        var field = options.field.replace('.Result', '');
        $('<input required data-text-field="Result" data-value-field="Id" data-bind="value:' + field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/enhancementRequestOutcomes/",
                            dataType: "json",
                            type: "GET"
                        }
                    }
                }
            });
    };

    function customerDropDownEditor(container, options) {
        debugger;
        // By doing this we make the field we bind to when editing/adding Customer instead of Customer.Name
        var field = options.field.replace('.Name', '');
        $('<input required data-text-field="Name" data-value-field="Id" data-bind="value:' + field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/enhancementRequestCustomers/",
                            dataType: "json",
                            type: "GET"
                        }
                    }
                }
            });
    };

});