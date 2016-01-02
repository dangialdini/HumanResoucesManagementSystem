$(function () {
    var startDefault = new Date();
    var endDefault = new Date();
    var gridDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/LeadActions",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/LeadActions",
                type: "POST",
                dataType: "json",
                contentType: "application/json"
            },
            update: {
                url: "/api/LeadActions",
                type: "PUT",
                dataType: "json",
                contentType: "application/json"
            },
            destroy: {
                url: "/api/LeadActions",
                type: "DELETE",
                dataType: "json",
                contentType: "application/json"
            },
            parameterMap: function (options, operation) {
                return kendo.stringify(options);
            }
        },
        pageSize: 20,
        serverPaging: true,
        schema: {
            data: function (response) {
                if (response.hasOwnProperty('Data')) {
                    return response.Data;
                }
                else {
                    return response;
                }
            },
            total: 'Total',
            errors: 'Errors',
            model: {
                id: "ActionId",
                fields: {
                    ActionId: { editable: false, nullable: true },
                    NextContactDate: { editable: true, nullable: true, type: "date", defaultValue: startDefault },
                    EndContact: { editable: true, nullable: true, type: "date", defaultValue: endDefault },
                    Title: { editable: true, nullable: true },
                    IsAllDay: { editable: true, nullable: true, type: "boolean" },
                    Timestamp: { editable: false, nullable: true, type: "date" },
                    Customer: {
                        editable: true,
                        defaultValue: {
                            CustomerId: 0,
                            CustomerName: ""
                        }
                    },
                    Employee: {
                        editable: true,
                        defaultValue: {
                            EmployeeId: 0,
                            EmployeeName: ""
                        }
                    },
                    Sale: {
                        editable: true,
                        defaultValue: {
                            SaleId: 0,
                            OrderNumber: 0
                        }
                    },
                    SaleOrderNo: { editable: true, nullable: true, type: "number" }
                }
            }
        }
    });


    $("#grid").kendoGrid({
        dataSource: gridDataSource,
        height: 600,
        pageable: true,
        groupable: false,
        sortable: true,
        editable: {
            mode: 'popup',
            template: kendo.template($("#edit-template").html())
        },
        edit: function (e) {

            var employeeInputElement = e.container.find("input[name=\"Employee\"]");
            employeeInputElement.kendoDropDownList({
                dataSource: employeeDS,
                filter: "contains",
                dataTextField: "EmployeeName",
                dataValueField: "EmployeeId",
                autobind: false,
                serverFiltering: false,
                optionLabel: "Select Employee...",
                ignoreCase: true
            });

            var customerInputElement = e.container.find("input[name=\"Customer\"]");
            customerInputElement.kendoDropDownList({
                dataSource: customerDataSource,
                filter: "contains",
                dataTextField: "CustomerName",
                dataValueField: "CustomerId",
                autobind: false,
                serverFiltering: false,
                //change: function (e) {
                //    var customer = event.get("Customer");
                //    debugger;
                //},
                optionLabel: "Select Customer...",
                ignoreCase: true
            });

            var saleInputElement = e.container.find("input[name=\"Sale\"]");
            saleInputElement.kendoDropDownList({
                dataSource: saleDS,
                template: '#= OrderNumber #',
                filter: "contains",
                dataTextField: "OrderNumber",
                dataValueField: "SaleId",
                autobind: false,
                serverFiltering: false,
                //change: function (e) {
                //    var sale = event.get("Sale");
                //    debugger;
                //},
                optionLabel: "Select Sale...",
                ignoreCase: true
            });
        },
        columns: [{
            field: "ActionId",
            title: "Id"
        },
        {
            field: "Timestamp",
            title: "Timestamp",
            format: "{0: dd/MM/yyyy, hh:mm}"
        },
        {
            field: "NextContactDate",
            title: "Next Contact Date",
            format: "{0: dd/MM/yyyy, hh:mm}",
            editor: datePickerStart
        },
        {
            field: "EndContact",
            title: "End Contact",
            format: "{0: dd/MM/yyyy, hh:mm}",
            editor: datePickerEnd
        },
        //{
        //    field: "IsAllDay",
        //    title: "Is All Day",
        //},
        {
            field: "Title",
            title: "Notes",
        },
        {
            field: "Customer",
            title: "Customer",
            template: "#= Customer.CustomerName #",
            editor: customerDropDownList
        },
        {
            field: "Employee",
            title: "Employee",
            template: "#= Employee.EmployeeName #",
            editor: employeeAutoComplete
        },
        {
            field: "Sale",
            title: "Order Number",
            template: "#= Sale.OrderNumber #",
            editor: saleDropDownList
        },
        {
            command: ["edit", "destroy"], title: "&nbsp;"
        }],
        toolbar: [{ name: "create", text: "New Action" }, { name: "excel" }]
    });



    var customerDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Sales/SaleCustomers",
                type: "GET",
                dataType: "json"
            }
        },
        schema:
        {
            model: {
                id: "CustomerId",
                fields: {
                    CustomerId: { editable: false, nullable: true },
                    CustomerName: { type: "string" }
                }
            }
        }
    });

    function customerDropDownList(container, options) {
        $('<input required data-text-field="CustomerName" data-value-field="CustomerId" data-bind="value: ' + options.field + '" />').appendTo(container).kendoDropDownList({
            dataSource: {
                transport: {
                    read: {
                        url: "/api/Sales/SaleCustomers",
                        type: "GET",
                        dataType: "json"
                    }
                },
                schema:
                {
                    model: {
                        id: "CustomerId",
                        fields: {
                            CustomerId: { editable: false, nullable: true },
                            CustomerName: { type: "string" }
                        }
                    }
                }
            },
            filter: "contains",
            autobind: false,
            serverFiltering: false,
            //change: onSelect,
            optionLabel: "Select Customer...",
            ignoreCase: true
        }).data("kendoDropDownList");
    }

    //var customerSelected = 0;
    //function onSelect(e) {
    //    saleDS.read();
    //}

    var saleDS = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Sales",
                type: "GET",
                dataType: "json"
            }
        },
        schema: {
            model: {
                id: "SaleId",
                fields: {
                    SaleId: { editable: false, nullable: true },
                    OrderNumber: { type: "number" },
                    Customer: {
                        CustomerId: { editable: false, nullable: true },
                        CustomerName: { type: "string" }
                    }
                }
            }
        }
    });

    var employeeDS = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Sales/SaleEmployees",
                type: "GET",
                dataType: "json"
            }
        },
        schema:
        {
            model: {
                id: "EmployeeId",
                fields: {
                    EmployeeId: { editable: false, nullable: true },
                    EmployeeName: { type: "string" }
                }
            }
        }
    });

    function saleDropDownList(container, options) {
        $('<input required data-text-field="OrderNumber" data-value-field="OrderNumber" data-bind="value: ' + options.field + '"/>')
            .appendTo(container).kendoDropDownList({
                dataSource: saleDS,
                autobind: false,
                serverFiltering: false,
                optionLabel: "Select Sale Order Number..."
            }).data("kendoDropDownList");
    }

    function employeeAutoComplete(container, options) {
        $('<input required data-text-field="EmployeeName" data-value-field="EmployeeId" data-bind="value: ' + options.field + '" />')
            .appendTo(container).kendoDropDownList({
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/Sales/SaleEmployees",
                            type: "GET",
                            dataType: "json"
                        }
                    },
                    schema:
                    {
                        model: {
                            id: "EmployeeId",
                            fields: {
                                EmployeeId: { editable: false, nullable: true },
                                EmployeeName: { type: "string" }
                            }
                        }
                    }
                },
                filter: "contains",
                autobind: false,
                serverFiltering: false,
                ignoreCase: true,
                optionLabel: "Select Employee..."
            }).data("kendoDropDownList");
    }

    function dateTimePicker(container, options) {
        $("#datetimepicker").kendoDateTimePicker({
            value: new Date()
        });
    }

    var searchAutoComplete = $("#autocomplete").kendoAutoComplete({
        dataSource: gridDataSource,
        separator: ", ",
        serverFiltering: false,
        dataTextField: "Customer.CustomerName",
        ignoreCase: true,
        placeholder: "Search customers ...",
        filter: "contains"
    }).data("kendoAutoComplete");

    var searchAutoComplete = $("#autocompleteEmp").kendoAutoComplete({
        dataSource: gridDataSource,
        separator: ", ",
        serverFiltering: false,
        dataTextField: "Employee.EmployeeName",
        ignoreCase: true,
        placeholder: "Search employees ...",
        filter: "contains",
    }).data("kendoAutoComplete");

    $("#cusCheckbox").change(function () {
        var multiselect = $("#scheautocomplete").data("kendoMultiSelect");
        if (document.getElementById("cusCheckbox").checked) {
            multiselect.enable(true);
        } else {

            multiselect.value(0);
            schedule.dataSource.filter([]);
            multiselect.enable(false);
        }
    });

    var searchAutoComplete = $("#scheautocomplete").kendoMultiSelect({
        dataSource: customerDataSource,
        dataTextField: "CustomerName",
        dataValueField: "CustomerId",
        ignoreCase: true,
        placeholder: "Search customers ...",
        filter: "contains",
        autoClose: false,
        value: [0],
        change: function (e) {
            var value = this.value();
            if (value.length > 0) {
                schedule.dataSource.filter({
                    operator: function (task) {
                        return $.inArray(task.Customer.CustomerId, value) >= 0;
                    }
                })
            }
            else if (value.length == 0) {
                schedule.dataSource.filter([]);
            }
        },
        enable: false
    }).data("kendoMultiSelect");

    $("#empCheckbox").change(function () {
        var multiselect = $("#scheautocompleteEmp").data("kendoMultiSelect");
        if (document.getElementById("empCheckbox").checked) {
            multiselect.enable(true);
        } else {

            multiselect.value(0);
            schedule.dataSource.filter([]);
            multiselect.enable(false);
        }
    });

    var searchAutoComplete = $("#scheautocompleteEmp").kendoMultiSelect({
        dataSource: employeeDS,
        dataTextField: "EmployeeName",
        dataValueField: "EmployeeId",
        ignoreCase: true,
        placeholder: "Search employees ...",
        filter: "contains",
        autoClose: true,
        value: [0],
        change: function (e) {
            var value = this.value();
            if (value.length > 0) {
                schedule.dataSource.filter({
                    operator: function (task) {
                        return $.inArray(task.Employee.EmployeeId, value) >= 0;
                    }
                })
            }
            else if (value.length == 0) {
                schedule.dataSource.filter([]);
            }
        },
        enable: false
    }).data("kendoMultiSelect");

    var customers = $("#customerDropDown").kendoDropDownList({
        placeholder: "Select customers...",
        dataTextField: "CustomerName",
        dataValueField: "CustomerId",
        autoBind: false,
        optionLabel: "Select Customer...",
        dataSource: {
            transport: {
                read: {
                    url: "/api/Sales/SaleCustomers",
                    type: "GET",
                    dataType: "json"
                }
            }
        }
    }).data("kendoDropDownList");







    var schedulerDataSource = new kendo.data.SchedulerDataSource({
        transport: {
            read: {
                url: "/api/LeadActions",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/LeadActions",
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                complete: function (e) {
                    $("#schedulerSection").data("kendoScheduler").dataSource.read();
                }
            },
            update: {
                url: "/api/LeadActions",
                type: "PUT",
                dataType: "json",
                contentType: "application/json"
            },
            destroy: {
                url: "/api/LeadActions",
                type: "DELETE",
                contentType: "application/json"
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        },
        timezone: "Australia/Sydney",
        allDaySlot: false,
        schema: {
            errors: 'Errors',
            total: 'Total',
            model: {
                id: "ActionId",
                fields: {
                    ActionId: { from: "ActionId", type: "number" },
                    Timestamp: { from: "Timestamp", nullable: true, type: "date" },
                    title: { from: "Title", validation: { required: false } },
                    start: { type: "date", from: "NextContactDate", defaultValue: "" },
                    end: { type: "date", from: "EndContact", defaultValue: "" },
                    NextContactDate: { type: "date", from: "NextContactDate" },
                    EndContact: { type: "date", from: "EndContact" },
                    startTimezone: { from: "StartTimezone" },
                    endTimezone: { from: "EndTimezone" },
                    IsAllDay: { type: "boolean", from: "IsAllDay" },
                    recurrenceId: { from: "RecurrenceID" },
                    recurrenceRule: { from: "RecurrenceRule" },
                    recurrenceException: { from: "RecurrenceException" },
                    Customer: {
                        from: "Customer",
                        editable: true,
                        defaultValue: {
                            CustomerId: 0,
                            CustomerName: ""
                        }
                    },
                    Sale: {
                        from: "Sale",
                        editable: true,
                        defaultValue: {
                            SaleId: 0,
                            OrderNumber: 0
                        }
                    },
                    Employee: {
                        from: "Employee",
                        editable: true,
                        defaultValue: {
                            EmployeeId: 0,
                            EmployeeName: 0
                        }
                    }
                }
            }
        }
    });

    var date = new Date();
    date.setHours(7);
    date.setMinutes(0);

    var schedulerOptions = {
        date: date,
        startTime: date,
        height: 600,
        views: [
            "day",
            { type: "workWeek", selected: true },
            "week",
            "month"
            //"agenda",
            //{ type: "timeline", eventHeight: 50 }
        ],
        dataSource: schedulerDataSource,
        allDaySlot: false,
        selectable: true,
        editable: {
            mode: 'popup',
            template: kendo.template($("#edit-template").html())
        },
        eventTemplate: $("#scheduler-event-template").html(),
        edit: function (e) {
            var event = e.event;
            var id = event.get("ActionId");
            if (id == 0) {
                event.set("NextContactDate", event.get("start"));
                event.set("EndContact", event.get("end"));
            }

            var employeeInputElement = e.container.find("input[name=\"Employee\"]");
            employeeInputElement.kendoDropDownList({
                dataSource: employeeDS,
                dataTextField: "EmployeeName",
                dataValueField: "EmployeeId",
                filter: "contains",
                autobind: false,
                serverFiltering: false,
                optionLabel: "Select Employee...",
                ignoreCase: true
            });

            var customerInputElement = e.container.find("input[name=\"Customer\"]");
            customerInputElement.kendoDropDownList({
                dataSource: customerDataSource,
                dataTextField: "CustomerName",
                dataValueField: "CustomerId",
                filter: "contains",
                autobind: false,
                serverFiltering: false,
                //change: function (e) {
                //    var customer = event.get("Customer");
                //    debugger;
                //},
                optionLabel: "Select Customer...",
                ignoreCase: true
            });
            //customerInputElement.setDataSource(customerDataSource);

            var saleInputElement = e.container.find("input[name=\"Sale\"]");
            saleInputElement.kendoDropDownList({
                dataSource: saleDS,
                filter: "contains",
                dataTextField: "OrderNumber",
                dataValueField: "SaleId",
                autobind: false,
                serverFiltering: false,
                //change: function (e) {
                //    var sale = event.get("Sale");
                //    debugger;
                //},
                optionLabel: "Select Sale...",
                ignoreCase: true
            });
            //var sIE = saleInputElement.data("dropDownList");
            //sIE.setDataSource(saleDS);
        }
    };

    var schedule = $("#schedulerSection").kendoScheduler(schedulerOptions).data("kendoScheduler");

    function datePickerStart(container, options) {
        $('<input required data-text-field="NextContactDate" data-value-field="NextContactDate" data-bind="value: ' + options.field + '" />').appendTo(container).kendoDateTimePicker({

        }).data("kendoDateTimePicker");
    }

    function datePickerEnd(container, options) {
        $('<input required data-text-field="EndContact" data-value-field="EndContact" data-bind="value: ' + options.field + '" />').appendTo(container).kendoDateTimePicker({

        }).data("kendoDateTimePicker");
    }


    $(function () {
        $("#schedulerSection").show();
        $("#addAction").show();
        $("#grid").hide();
        $("#gridControls").hide();
        $("#schedulerControls").show();
    });

});