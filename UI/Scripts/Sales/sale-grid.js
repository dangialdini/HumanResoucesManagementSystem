(function () {
    //// Data Sources
    var saleDataSource = new kendo.data.DataSource({
        type: "aspnetmvc-ajax",
        serverPaging: true,
        serverSorting: true,
        pageSize: 10,
        transport: {
            read: {
                url: "/api/sales",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/sales",
                type: "POST",
                dataType: "json"
            },
            update: function(){
                alert("Update");
            },
            //{
            //    url: "/api/sales",
            //    type: "PUT",
            //    dataType: "json",
            //    contentType: "application/json"
            //},
            destroy: {
                url: "/api/sales",
                type: "DELETE"
            },
            parameterMap: function (options, operation) {

                return kendo.stringify(options);
            }
        },
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
                id: "SaleId",
                fields: {
                    SaleId: {
                        editable: false,
                        nullable: true,
                        type: "number"
                    },
                    Date: {
                        editable: true,
                        type: "date"
                    },
                    OrderNumber: {
                        editable: true,
                        type: "number",
                        validation: {
                            min: 1
                        }
                    },
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
                    Finalised: {
                        editable: true,
                        type: "boolean"
                    },
                }
            }
        }
    });


    var productDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Products",
                type: "GET",
                dataType: "json"
            }
        },
        schema: {
            model: {
                id: "ProductId",
                fields: {
                    ProductId: { editable: false, nullable: true },
                    Name: { type: "string" }
                }
            }
        }
    });


    var employeeDataSource = new kendo.data.DataSource({
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


    //// Configuration

    var saleGridOptions = {
        dataSource: saleDataSource,
        height: 600,
        sortable: true,
        pageable: true,
        groupable: false,
        filterable: {
            extra: false
        },
        detailInit: detailInit,
        //dataBound: function () {
        //    this.expandRow(this.tbody.find("tr.k-master-row").first());
        //},
        columns: [
            {
                field: "SaleId",
                title: "Sale Id"
            },
            {
                field: "Date",
                title: "Date",
                template: "#: kendo.toString(kendo.parseDate(Date, 'yyyy-MM-dd'), 'MM/dd/yyyy') #"
            },
            {
                field: "OrderNumber",
                title: "Order Number"
            },
            {
                field: "Customer",
                title: "Customer",
                template: "#: Customer.CustomerName #",
                editor: customerAutoComplete
            },
            {
                field: "Employee",
                title: "Employee",
                template: "#: Employee.EmployeeName #",
                editor: employeeAutoComplete
            },
            {
                field: "Finalised",
                title: "Is Sale Finalised"
            },
            {
                command: [{
                    name: "details",
                    text: "Details",
                    click: function (e) {
                        // e.target is the DOM element representing the button
                        var tr = $(e.target).closest("tr"); // get the current table row (tr)
                        // get the data bound to the current table row
                        var data = this.dataItem(tr);

                        sale.navigate("/details/" + data.get("SaleId"));
                        e.preventDefault();
                    }
                },
                {
                    name: "edit", click: function (e) {
                        // e.target is the DOM element representing the button
                        var tr = $(e.target).closest("tr"); // get the current table row (tr)
                        // get the data bound to the current table row
                        var data = this.dataItem(tr);

                        sale.navigate("/edit/" + data.get("SaleId"));
                        e.preventDefault();
                    }
                },
                { name: "destroy" }], title: "&nbsp;", width: "250px"
            }
        ],
        toolbar: [{ template: kendo.template($("#add-template").html()) }, { name: "excel" }],
        editable: {
            mode: 'popup',
            update: false,
            confirmation: true
        }
    };


    //// View Models
    var editViewModel = kendo.observable({
        customer: null,
        employee: null,
        setCurrent: function (SaleId) {
            this.set("current", saleDataSource.get(SaleId));
        },
        submitEnabled: true,
        submit: function () {
            if (editValidator.validate()) {
                this.set("submitEnabled", false);
                if ($("#check").checked) {
                    this.set("Finalised", true);
                }
                else {
                    this.set("Finalised", false);
                }
                var b = saleDataSource.hasChanges();
                alert(b);
                saleDataSource.sync().then(function () {
                    editViewModel.set("submitEnabled", true);
                    sale.navigate("/");
                });
            };
        },
        setCustomerId: function (customerId) {
            this.get("current").set("CustomerId", customerId);
        },
        setEmployeeId: function (employeeId) {
            this.get("current").set("EmployeeId", employeeId);
        },
        setFinalised: function(Finalised){
            this.get("current").set("Finalised", Finalised);
        }
    });

    var detailViewModel = kendo.observable({
        setCurrent: function (SaleId) {
            var data = saleDataSource.get(SaleId)
            
            this.set("current", data);
            this.set("Date", kendo.format("{0:D}", data.get("Date")));
            
        }
    });

    var createViewModel = new kendo.observable({
        init: function () {
            this.set("id", 0);
            this.set("Date", new Date());
            this.set("OrderNumber", 0);
            this.set("CustomerId", 0);
            this.set("Customer", null);
            this.set("Employee", null);
            this.set("EmployeeId", 0);
            this.set("Finalised", false);
        },
        submitEnabled: true,
        submit: function () {
            if (createValidator.validate()) {
                this.set("submitEnabled", false);

                saleDataSource.add({
                    Date: this.get("Date"),
                    OrderNumber: this.get("OrderNumber"),
                    CustomerId: this.get("CustomerId"),
                    Customer: {
                        CustomerId: this.get("CustomerId")
                    },
                    EmployeeId: this.get("EmployeeId"),
                    Employee:{
                        EmployeeId: this.get("EmployeeId")
                    },
                    Finalised: this.get("Finalised"),
                });

                saleDataSource.sync().then(function () {
                    createViewModel.set("submitEnabled", true);
                    sale.navigate("/");
                });
            };
        },
        setCustomerId: function (customerId) {
            this.set("CustomerId", customerId);
        },
        setEmployeeId: function (employeeId) {
            this.set("EmployeeId", employeeId);
        }
    });


    //// Validators
    var createValidator;
    var editValidator;


    //// Layouts
    var layout = new kendo.Layout("<section id='content'></section>");


    //// Views
    var create = new kendo.View("create-template", {
        model: createViewModel,
        init: function () {
            var container = this.element.find("#create-form");
            createValidator = container.kendoValidator().data("kendoValidator");

            //container.find("input[name=\"Customer\"]").kendoDropDownList({
            //    dataSource: customerDataSource,
            //    dataTextField: "CustomerName",
            //    dataValueField: "CustomerId",
            //    filter: "contains",
            //    autobind: false,
            //    serverFiltering: false,
            //    ignoreCase: true,
            //    optionLabel: "Select Customer..."
            //});

            container.find("input[name=\"Customer\"]").kendoAutoComplete({
                dataSource: customerDataSource,
                dataTextField: "CustomerName",
                autobind: false,
                serverFiltering: false,
                change: function () {
                    var customer = createViewModel.get("Customer");
                    if (customer === null) {
                        return;
                    }

                    if ($.type(customer) === "string") {
                        createViewModel.set("Customer", null);
                    }
                    else {
                        createViewModel.setCustomerId(customer.get("CustomerId"));
                    }
                }
            });

            container.find("input[name=\"Employee\"]").kendoAutoComplete({
                dataSource: employeeDataSource,
                dataTextField: "EmployeeName",
                autobind: false,
                serverFiltering: false,
                change: function () {
                    var employee = createViewModel.get("Employee");
                    if (employee === null) {
                        return;
                    }

                    if ($.type(employee) === "string") {
                        createViewModel.set("Employee", null);
                    }
                    else {
                        createViewModel.setCustomerId(employee.get("EmployeeId"));
                    }
                }
            });

            //container.find("input[name=\"Employee\"]").kendoDropDownList({
            //    dataSource: employeeDataSource,
            //    dataTextField: "EmployeeName",
            //    dataValueField: "EmployeeId",
            //    filter: "contains",
            //    autobind: false,
            //    serverFiltering: false,
            //    ignoreCase: true,
            //    optionLabel: "Select Employee..."
            //});

            container.find("input[name=\"Date\"]").kendoDatePicker({
            });
        },
        hide: function () {
            createValidator.hideMessages();
        }
    });

    var edit = new kendo.View("edit-template", {
        model: editViewModel,
        init: function () {
            var container = $("#edit-form");
            editValidator = container.kendoValidator().data("kendoValidator");

            container.find("input[name=\"Customer\"]").kendoDropDownList({
                dataSource: customerDataSource,
                dataTextField: "CustomerName",
                dataValueField: "CustomerId",
                filter: "contains",
                autobind: false,
                serverFiltering: false,
                ignoreCase: true,
                optionLabel: "Select Customer..."
            });

            container.find("input[name=\"Employee\"]").kendoDropDownList({
                dataSource: employeeDataSource,
                dataTextField: "EmployeeName",
                dataValueField: "EmployeeId",
                filter: "contains",
                autobind: false,
                serverFiltering: false,
                ignoreCase: true,
                optionLabel: "Select Employee..."
            });

            container.find("input[name=\"Date\"]").kendoDatePicker({
            });

            container.find("input[name=\"Finalised\"]");

        },
        hide: function () {
            editValidator.hideMessages();
        }
    });

    var detail = new kendo.View("detail-template", {
        model: detailViewModel,
        init: function () {
            //e.data.SaleId = detailViewModel.current.SaleId;
            $("#sli-grid").kendoGrid(sliGrid);
        }
    });

    var index = new kendo.View("index-template", {
        init: function () {
            $("#sale-grid").kendoGrid(saleGridOptions);

            $("#autocomplete").kendoAutoComplete({
                dataSource: saleDataSource,
                separator: ", ",
                serverFiltering: false,
                dataTextField: "Customer.CustomerName",
                ignoreCase: true,
                placeholder: "Search Customers ...",
                filter: "contains"
            }).data("kendoAutoComplete");

            $("#autocompleteEmp").kendoAutoComplete({
                dataSource: saleDataSource,
                separator: ", ",
                serverFiltering: false,
                dataTextField: "Employee.EmployeeName",
                ignoreCase: true,
                placeholder: "Search Employees ...",
                filter: "contains"
            }).data("kendoAutoComplete");
        }
    });

    // Initialize Router
    var sale = new kendo.Router({
        init: function () {
            layout.render("#application");
        }
    });

    // Routing
    sale.route("/", function () {
        layout.showIn("#content", index);


    });

    sale.route("/create", function () {
        createViewModel.init();
        layout.showIn("#content", create);
    });

    sale.route("/edit/:id", function (SaleId) {
        saleDataSource.fetch(function (e) {
            if (editViewModel.get("current")) { // existing view, start transition, then update content. This is necessary for the correct view transition clone to be created.
                layout.showIn("#content", edit);
                editViewModel.setCurrent(SaleId);
            } else {
                // update content first
                editViewModel.setCurrent(SaleId);
                layout.showIn("#content", edit);
            }
        });
    });

    sale.route("/details/:id", function (SaleId) {
        saleDataSource.fetch(function (e) {
            if (detailViewModel.get("current")) { // existing view, start transition, then update content. This is necessary for the correct view transition clone to be created.
                layout.showIn("#content", detail);
                detailViewModel.setCurrent(SaleId);
            } else {
                // update content first
                detailViewModel.setCurrent(SaleId);
                layout.showIn("#content", detail);
            }
        });
    });

    $(function () {
        sale.start();
    });


    //$("#sale-grid").kendoGrid({
    //    dataSource: saleDataSource,
    //    height: 600,
    //    sortable: true,
    //    pageable: true,
    //    groupable: false,
    //    filterable: {
    //        extra: false
    //    },
    //    detailInit: detailInit,
    //    //dataBound: function () {
    //    //    this.expandRow(this.tbody.find("tr.k-master-row").first());
    //    //},
    //    columns: [
    //        {
    //            field: "SaleId",
    //            title: "Sale Id"
    //        },
    //        {
    //            field: "Date",
    //            title: "Date",
    //            template: "#: kendo.toString(kendo.parseDate(Date, 'yyyy-MM-dd'), 'MM/dd/yyyy') #"
    //        },
    //        {
    //            field: "OrderNumber",
    //            title: "Order Number"
    //        },
    //        {
    //            field: "Customer",
    //            title: "Customer",
    //            template: "#: Customer.CustomerName #",
    //            editor: customerAutoComplete
    //        },
    //        {
    //            field: "Employee",
    //            title: "Employee",
    //            template: "#: Employee.EmployeeName #",
    //            editor: employeeAutoComplete
    //        },
    //        {
    //            field: "Finalised",
    //            title: "Is Sale Finalised"
    //        },
    //        { command: ["edit", "destroy"] }
    //    ],
    //    toolbar: [{ name: "create", text: "New Sale" }],
    //    editable: 'popup'
    //});

    //var sliGrid = {
    //    dataSource: {
    //        transport: {
    //            read: {
    //                url: "/api/Sales/" + detailViewModel.get("current").SaleId + "/SaleLineItems",
    //                type: "GET",
    //                dataType: "json",
    //                data: detailViewModel.get("current").SaleId
    //            },
    //            create: {
    //                url: "/api/SaleLineItems/" + detailViewModel.get("current").SaleId + "/Sale",
    //                type: "POST",
    //                dataType: "json",
    //                contentType: "application/json",
    //                data: detailViewModel.get("current").SaleId
    //            },
    //            update: {
    //                url: "/api/SaleLineItems",
    //                type: "PUT",
    //                dataType: "json",
    //                contentType: "application/json"
    //            },
    //            destroy: {
    //                url: "/api/SaleLineItems/",
    //                type: "DELETE",
    //                contentType: "application/json"
    //            },
    //            parameterMap: function (options, operation) {
    //                return kendo.stringify(options);
    //            }
    //        },
    //        schema: {
    //            data: function (response) {
    //                if (response.hasOwnProperty('Data')) {
    //                    return response.Data;
    //                }
    //                else {
    //                    return response;
    //                }
    //            },
    //            total: 'Total',
    //            errors: 'Errors',
    //            model: {
    //                id: "SaleLineItemId",
    //                fields: {
    //                    SaleLineItemId: {
    //                        editable: false,
    //                        nullable: true,
    //                        type: "number"
    //                    },
    //                    Product: {
    //                        editable: true,
    //                        defaultValue: { "ProductId": 1, "Name": "Scissors" }
    //                    },
    //                    Qty: {
    //                        editable: true,
    //                        type: "number",
    //                        validation: {
    //                            min: 1
    //                        }
    //                    },
    //                    Amount: {
    //                        editable: true,
    //                        nullable: true,
    //                        type: "number",
    //                        //defaultValue: UnitPrice
    //                    },
    //                    Subtotal: {
    //                        editable: false,
    //                        nullable: true,
    //                        type: "number",
    //                    },
    //                    UnitPrice: {
    //                        editable: false,
    //                        nullable: true,
    //                        type: "number"
    //                    },
    //                    saleId: {
    //                        editable: false,
    //                        nullable: false,
    //                        type: "number",
    //                        defaultValue: "#: SaleId #"
    //                    }
    //                }
    //            }
    //        },
    //        aggregate: [
    //            { field: "Subtotal", aggregate: "sum" }
    //        ],
    //        serverPaging: true,
    //        serverSorting: false,
    //        serverFiltering: true,
    //        pageSize: 10,
    //        filter: { field: "SaleId", operator: "eq", value: e.data.SaleId }
    //    },
    //    scrollable: false,
    //    sortable: true,
    //    pageable: true,
    //    filterable: true,
    //    columns: [
    //    {
    //        field: "SaleLineItemId",
    //        title: "Id"
    //    },
    //    {
    //        field: "Product",
    //        title: "Product",
    //        template: "#: Product.Name #",
    //        editor: productAutoComplete

    //    },
    //    {
    //        field: "Qty",
    //        title: "Quantity"
    //    },
    //    {
    //        field: "Amount",
    //        title: "Amount"
    //    },
    //    {
    //        field: "Subtotal",
    //        title: "Subtotal",
    //        footerTemplate: "Sum: #= sum #"
    //    },
    //    {
    //        command: ["edit", "destroy"
    //            //, {
    //            //text: "Product", click: function (e) {
    //            //    var item = this.dataItem($(e.target).closest("tr"));
    //            //    window.location.href = "/Sales/Product/" + item.ProductId;
    //            //}
    //        //}
    //        ]
    //    }
    //    ],
    //    editable: 'popup',
    //    toolbar: [{ name: "create", text: "New Sale Line Item" }]
    //};


    function detailInit(e) {
        var sid = e.id;
        $("<div/>").appendTo(e.detailCell).kendoGrid({
            dataSource: {
                transport: {
                    read: {
                        url: "/api/Sales/" + e.data.SaleId + "/SaleLineItems",
                        type: "GET",
                        dataType: "json",
                        data: e.data.SaleId
                    },
                    create: {
                        url: "/api/SaleLineItems/" + e.data.SaleId + "/Sale",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json",
                        data: e.data.SaleId
                    },
                    update: {
                        url: "/api/SaleLineItems",
                        type: "PUT",
                        dataType: "json",
                        contentType: "application/json"
                    },
                    destroy: {
                        url: "/api/SaleLineItems/",
                        type: "DELETE",
                        contentType: "application/json"
                    },
                    parameterMap: function (options, operation) {
                        return kendo.stringify(options);
                    }
                },
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
                        id: "SaleLineItemId",
                        fields: {
                            SaleLineItemId: {
                                editable: false,
                                nullable: true,
                                type: "number"
                            },
                            Product: {
                                editable: true,
                                defaultValue: { "ProductId": 1, "Name": "Scissors" }
                            },
                            Qty: {
                                editable: true,
                                type: "number",
                                validation: {
                                    min: 1
                                }
                            },
                            Amount: {
                                editable: true,
                                nullable: true,
                                type: "number",
                                //defaultValue: UnitPrice
                            },
                            Subtotal: {
                                editable: false,
                                nullable: true,
                                type: "number",
                            },
                            UnitPrice: {
                                editable: false,
                                nullable: true,
                                type: "number"
                            },
                            saleId: {
                                editable: false,
                                nullable: false,
                                type: "number",
                                defaultValue: "#: SaleId #"
                            }
                        }
                    }
                },
                aggregate: [
                    { field: "Subtotal", aggregate: "sum" }
                ],
                serverPaging: true,
                serverSorting: false,
                serverFiltering: true,
                pageSize: 10,
                filter: { field: "SaleId", operator: "eq", value: e.data.SaleId }
            },
            scrollable: false,
            sortable: true,
            pageable: true,
            filterable: true,
            columns: [
            {
                field: "SaleLineItemId",
                title: "Id"
            },
            {
                field: "Product",
                title: "Product",
                template: "#: Product.Name #",
                editor: productAutoComplete

            },
            {
                field: "Qty",
                title: "Quantity"
            },
            {
                field: "Amount",
                title: "Amount"
            },
            {
                field: "Subtotal",
                title: "Subtotal",
                footerTemplate: "Sum: #= sum #"
            },
            {
                command: ["edit", "destroy"
                    , {
                        text: "Product", click: function (e) {
                            // e.target is the DOM element representing the button
                            var tr = $(e.target).closest("tr"); // get the current table row (tr)
                            // get the data bound to the current table row
                            var data = this.dataItem(tr);
                            var p = data.get("Product")

                            sale.navigate("/Sales/Product#/details/" + p.ProductId);
                            e.preventDefault();
                        }
                    },
                
                ]
            }
            ],
            editable: 'popup',
            toolbar: [{ name: "create", text: "New Sale Line Item" }]
        });
    }

    //function showProduct(e) {
    //    window.location.href = "/Sales/Product/" + e.data.Product.ProductId;
    //}

    function customerAutoComplete(container, options) {
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
            ignoreCase: true,
            optionLabel: "Select Customer..."
        }).data("kendoDropDownList");
    }


    function employeeAutoComplete(container, options) {
        $('<input required data-text-field="EmployeeName" data-value-field="EmployeeId" data-bind="value: ' + options.field + '" />').appendTo(container).kendoDropDownList({
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


    function productAutoComplete(container, options) {
        $('<input required data-text-field="Name" data-value-field="ProductId" data-bind="value:' + options.field + '"/>').appendTo(container).kendoDropDownList({
            dataSource: {
                transport: {
                    read: {
                        url: "/api/Products",
                        type: "GET",
                        dataType: "json"
                    }
                },
                schema: {
                    model: {
                        id: "ProductId",
                        fields: {
                            ProductId: { editable: false, nullable: true },
                            Name: { type: "string" }
                        }
                    }
                }
            },
            serverFiltering: false,
            filter: "contains",
            ignoreCase: true,
            optionLabel: "Select product..."
        }).data("kendoDropDownList");
    }

    //var searchAutoComplete = $("#autocomplete").kendoAutoComplete({
    //    dataSource: dataSource,
    //    separator: ", ",
    //    serverFiltering: false,
    //    dataTextField: "Customer.CustomerName",
    //    ignoreCase: true,
    //    placeholder: "Search customers ...",
    //    filter: "contains"
    //}).data("kendoAutoComplete");


    //var searchAutoComplete = $("#autocompleteEmp").kendoAutoComplete({
    //    dataSource: dataSource,
    //    separator: ", ",
    //    serverFiltering: false,
    //    dataTextField: "Employee.EmployeeName",
    //    ignoreCase: true,
    //    placeholder: "Search employees ...",
    //    filter: "contains"
    //}).data("kendoAutoComplete");
})();