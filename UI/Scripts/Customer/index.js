
// Customer Mini SPA JavaScript
(function () {

    // Chart DataSource

    var ChartDataSource = new kendo.data.DataSource({
        title: { text: "Customers Per Sydney Area" },
        legend: { visible: false },
        series: [{
            type: "radarColumn",
            name: "Customers Per Sydney Area",
            data: [
                5, 1, 3, 5, 3, 1,
                1, 2, 4, 2, 3, 0,
                2, 4, 1, 0, 3, 1,
                1, 1, 0, 1, 1
            ]
        }],
        categoryAxis: {
            categories: ["Nortern Beaches", "Lower North Shore", "Upper North Shore", "North West",
                "Parramatta", "Outer West", "South West", "Canterburry-Bankstown",
                "St George", "Sutherland Shire", "Inner West", "Central Sydney",
                "Eastern Suburbs", "South Sydney"
            ]
        },
        valueAxis: {
            visible: true
        }
    });


    // Data Sources
    var customerDataSource = new kendo.data.DataSource({
        transport: {
            read: { url: "/api/customers/", dataType: "json", type: "GET" },
            create: { url: "/api/customers/", dataType: "json", contentType: "application/json", type: "POST" },
            update: { url: "/api/customers/", dataType: "json", contentType: "application/json", type: "PUT" },
            destroy: { url: "/api/customers/", dataType: "json", type: "DELETE" },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }

        },
        schema: {
            model: {
                id: "customerId",
                fields: {
                    customerId: { from: "Id" },
                    companyId: { from: "CompanyId", type: "number", editable: false, defaultValue: 1 },
                    name: { from: "Name", type: "string", validation: { required: true } },
                    abn: { from: "Abn", type: "number", validation: { required: true, maxlength: 10 } },
                    franchise: { from: "Franchise", type: "boolean" },
                    phone: { from: "Phone", validation: { required: true } },
                    email: { from: "Email", validation: { required: true } }
                }
            }
        }
    });

    var companyDataSource = new kendo.data.DataSource({
        transport: {
            read: { url: "/api/Companies", type: "GET", dataType: "json" },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        }
    });


    // Configuration
    var customerGridOptions = {
        dataSource: customerDataSource,
        height: 550,
        columns: [
            //{ field: "Id", title: "Customer Id", width: 120},
            //{ field: "companyId", title: "Company Id", width: 120},
            { field: "name", title: "Name", width: 200 },
            { field: "abn", title: "Abn", width: 120 },
            { field: "franchise", title: "Franchise", width: 100 },
            { field: "phone", title: "Phone", width: 200 },
            { field: "email", title: "Email", width: 240 },
            {
                command: [{
                    name: "details",
                    text: "Details",
                    click: function (e) {
                        // e.target is the DOM element representing the button
                        var tr = $(e.target).closest("tr"); // get the current table row (tr)
                        // get the data bound to the current table row
                        var data = this.dataItem(tr);

                        customer.navigate("/details/" + data.get("id"));
                        e.preventDefault();
                    }
                },
                {
                    name: "edit", click: function (e) {
                        // e.target is the DOM element representing the button
                        var tr = $(e.target).closest("tr"); // get the current table row (tr)
                        // get the data bound to the current table row
                        var data = this.dataItem(tr);

                        customer.navigate("/edit/" + data.get("id"));
                        e.preventDefault();
                    }
                },
                { name: "destroy" }], title: "&nbsp;", width: "250px"
            }
        ],
        toolbar: [{ template: kendo.template($("#add-template").html()) }, { name: "excel" }],
        editable: {
            mode: "popup",
            update: false,
            confirmation: true
        }
    };

    // View Models
    var editViewModel = kendo.observable({
        setCurrent: function (id) {
            this.set("current", customerDataSource.get(id));
        },
        submitEnabled: true,
        submit: function () {
            if (editValidator.validate()) {
                this.set("submitEnabled", false);

                customerDataSource.sync().then(function () {
                    editViewModel.set("submitEnabled", true);
                    customer.navigate("/");
                });
            }
        }
    });

    var detailViewModel = kendo.observable({
        setCustomer: function (id) {
            var data = customerDataSource.get(id)
            this.set("customer", data);
        }
    });

    var createViewModel = new kendo.observable({
        init: function () {
            //this.set("id", 0);
            this.set("companyId", "");
            this.set("name", "");
            this.set("abn", "");
            this.set("franchise", false);
            this.set("phone", "");
            this.set("email", "");
        },
        submitEnabled: true,
        submit: function () {
            if (createValidator.validate()) {
                this.set("submitEnabled", false);

                customerDataSource.add({
                    //Id: this.get("id"),
                    CompanyId: this.get("companyId"),
                    Name: this.get("name"),
                    Abn: this.get("abn"),
                    Franchise: this.get("franchise"),
                    Phone: this.get("phone"),
                    Email: this.get("email")
                });

                customerDataSource.sync().then(function () {
                    createViewModel.set("submitEnabled", true);
                    customer.navigate("/");
                });
            }
        }
    });

    // Validators
    var createValidator;
    var editValidator;

    // Layouts
    var layout = new kendo.Layout("<section id='content'></section>");

    // Views
    var create = new kendo.View("create-template", {
        model: createViewModel,
        init: function () {
            var container = this.element.find("#create-form");
            createValidator = container.kendoValidator().data("kendoValidator");

            container.find("input[name=\"CompanyId\"]").kendoDropDownList({
                dataSource: companyDataSource,
                dataValueField: "Id",
                dataTextField: "Name",
                optionLabel: "Select a Company..."
            });

            //container.find("input[name=\"ManagerId\"]").kendoDropDownList({
            //    dataSource: managerDataSource,
            //    dataValueField: "Id",
            //    dataTextField: "LastName",
            //    template: "#= (data.LastName && data.FirstName) ? LastName + ', ' + FirstName : LastName #",
            //    valueTemplate: "#= (data.LastName && data.FirstName) ? LastName + ', ' + FirstName : LastName #",
            //    optionLabel: "Select a Project Manager...",
            //});

            //container.find("input[name=\"Start\"]").kendoDatePicker({
            //});

            //container.find("input[name=\"Finish\"]").kendoDatePicker({
            //});
        },
        hide: function () {
            createValidator.hideMessages();
        }
    });

    var edit = new kendo.View("edit-template", {
        model: editViewModel,
        init: function () {
            var container = this.element.find("#edit-form");
            editValidator = container.kendoValidator().data("kendoValidator");

            container.find("input[name=\"CompanyId\"]").kendoDropDownList({
                dataSource: companyDataSource,
                dataValueField: "Id",
                dataTextField: "Name",
                optionLabel: "Select a Company..."
            });

            //container.find("input[name=\"ManagerId\"]").kendoDropDownList({
            //    dataSource: managerDataSource,
            //    dataValueField: "Id",
            //    dataTextField: "LastName",
            //    template: "#= (data.LastName && data.FirstName) ? LastName + ', ' + FirstName : LastName #",
            //    valueTemplate: "#= (data.LastName && data.FirstName) ? LastName + ', ' + FirstName : LastName #",
            //    optionLabel: "Select a Project Manager..."
            //});

            //container.find("input[name=\"Start\"]").kendoDatePicker({
            //});

            //container.find("input[name=\"Finish\"]").kendoDatePicker({
            //});
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
            var container = this.element;
            container.find("#index-grid").kendoGrid(customerGridOptions);
            container.find("#customer-chart").kendoChart;
        }

    });

    // Initialize Router
    var customer = new kendo.Router({
        init: function () {
            layout.render("#application");
        }
    });

    // Routing
    customer.route("/", function () {
        layout.showIn("#content", index);


    });

    customer.route("/create", function () {
        createViewModel.init();
        layout.showIn("#content", create);
    });

    customer.route("/edit/:id", function (Id) {
        customerDataSource.fetch(function (e) {
            if (editViewModel.get("current")) { // existing view, start transition, then update content. This is necessary for the correct view transition clone to be created.
                layout.showIn("#content", edit);
                editViewModel.setCurrent(Id);
            } else {
                // update content first
                editViewModel.setCurrent(Id);
                layout.showIn("#content", edit);
            }
        });
    });

    customer.route("/details/:id", function (customerId) {
        customerDataSource.fetch(function (e) {
            if (detailViewModel.get("current")) { // existing view, start transition, then update content. This is necessary for the correct view transition clone to be created.
                layout.showIn("#content", detail);
                detailViewModel.setCustomer(customerId);
            } else {
                // update content first
                detailViewModel.setCustomer(customerId);
                layout.showIn("#content", detail);
            }
        });
    });

    $(function () {
        customer.start();
    });
})();