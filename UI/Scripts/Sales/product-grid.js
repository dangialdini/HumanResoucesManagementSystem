(function () {
    /////Data Sources
    var gridDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/products",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/products",
                type: "POST",
                dataType: "json",
                contentType: "application/json"
            },
            update: {
                url: "/api/products",
                type: "PUT",
                dataType: "json",
                contentType: "application/json"
            },
            destroy: {
                url: "/api/products",
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
                id: "ProductId",
                fields: {
                    ProductId: {
                        editable: false,
                        nullable: true,
                        type: "number"
                    },
                    Name: {
                        editable: true,
                        type: "string",
                        validation: {
                            required: true
                        }
                    },
                    UnitPrice: {
                        editable: true,
                        type: "number",
                        validation: {
                            min: 1
                        }

                    },
                    Description: {
                        editable: true,
                        type: "string"
                    }
                }
            },
            serverPaging: true,
            serverSorting: true,
            pageSize: 10
        }
    });


    /// Configuration

    var productGridOptions = {
        dataSource: gridDataSource,
        height: 600,
        sortable: true,
        pageable: true,
        groupable: false,
        filterable: {
            extra: false,
        },
        columns: [
            {
                field: "ProductId",
                title: "Product Id"
            },
            {
                field: "Name",
                title: "Name"
            },
            {
                field: "UnitPrice",
                title: "Unit Price"
            },
            {
                field: "Description",
                title: "Description"
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

                        product.navigate("/details/" + data.get("ProductId"));
                        e.preventDefault();
                    }
                },
                {
                    name: "edit", click: function (e) {
                        // e.target is the DOM element representing the button
                        var tr = $(e.target).closest("tr"); // get the current table row (tr)
                        // get the data bound to the current table row
                        var data = this.dataItem(tr);

                        product.navigate("/edit/" + data.get("ProductId"));
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
        setCurrent: function (ProductId) {
            this.set("current", gridDataSource.get(ProductId));
        },
        submitEnabled: true,
        submit: function () {
            if (editValidator.validate()) {
                this.set("submitEnabled", false);
                gridDataSource.sync().then(function () {
                    editViewModel.set("submitEnabled", true);
                    product.navigate("/");
                });
            };
        }
    });

    var detailViewModel = kendo.observable({
        setCurrent: function (ProductId) {
            var data = gridDataSource.get(ProductId)
            this.set("current", data);
            this.set("unitPrice", kendo.format("{0:c}", data.get("UnitPrice")));
        }
    });

    var createViewModel = new kendo.observable({
        init: function () {
            this.set("id", 0);
            this.set("Name", "");
            this.set("UnitPrice", "");
            this.set("Description", "");
        },
        submitEnabled: true,
        submit: function () {
            if (createValidator.validate()) {
                this.set("submitEnabled", false);

                gridDataSource.add({
                    Name: this.get("Name"),
                    UnitPrice: this.get("UnitPrice"),
                    Description: this.get("Description")
                });

                gridDataSource.sync().then(function () {
                    createViewModel.set("submitEnabled", true);
                    product.navigate("/");
                });
            };
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
            var container = $("#create-form");
            createValidator = container.kendoValidator().data("kendoValidator");
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

        },
        hide: function () {
            editValidator.hideMessages();
        }
    });

    var detail = new kendo.View("detail-template", {
        model: detailViewModel
    });

    var index = new kendo.View("index-template", {
        init: function () {
            $("#product-grid").kendoGrid(productGridOptions);
            $("#autocomplete").kendoAutoComplete({
                dataSource: gridDataSource,
                separator: ", ",
                serverFiltering: false,
                dataTextField: "Name",
                ignoreCase: true,
                placeholder: "Search products ...",
                filter: "contains"
            }).data("kendoAutoComplete");
        }
    });


    //// Initialize Router
    var product = new kendo.Router({
        init: function () {
            layout.render("#application");
        }
    });


    //// Routing
    product.route("/", function () {
        layout.showIn("#content", index);
    });

    product.route("/create", function () {
        createViewModel.init();
        layout.showIn("#content", create);
    });

    product.route("/edit/:id", function (ProductId) {
        gridDataSource.fetch(function (e) {
            if (editViewModel.get("current")) {
                layout.showIn("#content", edit);
                editViewModel.setCurrent(ProductId);
            }
            else {
                editViewModel.setCurrent(ProductId);
                layout.showIn("#content", edit);
            }
        });
    });

    product.route("/details/:id", function (ProductId) {
        gridDataSource.fetch(function (e) {
            if (detailViewModel.get("current")) {
                layout.showIn("#content", detail);
                detailViewModel.setCurrent(ProductId);
            }
            else {
                detailViewModel.setCurrent(ProductId);
                layout.showIn("#content", detail);
            }
        });
    });

    

    $(function () {
        product.start();
    });
})();

//$("#product-grid").kendoGrid({
//    dataSource: gridDataSource,
//    height: 600,
//    sortable: true,
//    pageable: true,
//    groupable: false,
//    filterable: {
//        extra: false,
//    },
//    columns: [
//        {
//            field: "ProductId",
//            title: "Product Id"
//        },
//        {
//            field: "Name",
//            title: "Name"
//        },
//        {
//            field: "UnitPrice",
//            title: "Unit Price"
//        },
//        {
//            field: "Description",
//            title: "Description"
//        },
//        { command: ["edit", "destroy"] }
//    ],
//    toolbar: [{ name: "create", text: "New Product" }],
//    editable: 'popup'
//});


