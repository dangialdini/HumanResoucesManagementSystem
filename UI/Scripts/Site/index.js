// Mini SPA JavaScript
(function () {
    // Data Sources
    var siteDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/sites/",
                dataType: "json",
                type: "GET"
            },
            create: {
                url: "/api/sites/",
                dataType: "json",
                contentType: "application/json",
                type: "POST"
            },
            update: {
                url: "/api/sites/",
                dataType: "json",
                contentType: "application/json",
                type: "PUT"
            },
            destroy: {
                url: "/api/sites/",
                dataType: "json",
                type: "DELETE"
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }

        },
        schema: {
            model: {
                id: "Id",
                fields: {
                    customerId: { from: "CustomerId" },
                    addressId: { from: "AddressId", type: "number" },
                    address: { defaultValue: "" },
                    name: { from: "Name", type: "string", validation: { required: true } },
                    phone: { from: "Phone", validation: { required: true } },
                    email: { from: "Email", validation: { required: true } },
                    franchise: { from: "Franchise", type: "boolean" },
                    headQuarters: { from: "HeadQuarters", type: "boolean" }
                }
            }
        }
    });

    var addressDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/SiteAddresses",
                type: "GET",
                dataType: "json"
            }
        },
        schema: {
            model: {
                id: "Id"
            },
            parse: function (response) {
                var addresses = response;
                for (var i = 0; i < response.length; i++) {
                    var address = addresses[i];
                    address.FullAddress = address.Street1 + " " + address.Suburb + ', ' + address.Postcode;
                }
                //debugger;
                return addresses;
            }
        }
    });

    var customerDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/SiteCustomers",
                type: "GET",
                dataType: "json"
            }
        },
        schema: {
            model: {
                id: "Id"
            }
        }
    });

    // Configuration
    var siteGridOptions = {
        dataSource: siteDataSource,
        height: 550,
        columns: [
            //{ field: "customerId", title: "Customer Id", width: 120 },
            
            { field: "name", title: "Customer Name", width: 120 },
            { field: "address", title: "Address", width: 200 },
            { field: "phone", title: "Phone", width: 140 },
            { field: "email", title: "Email", width: 205 },
            { field: "franchise", title: "Franchise", width: 90 },
            { field: "headQuarters", title: "HeadQuarters", width: 105 },
            {
                command: [{
                    name: "details",
                    text: "Details",
                    click: function (e) {
                        // e.target is the DOM element representing the button
                        var tr = $(e.target).closest("tr"); // get the current table row (tr)
                        // get the data bound to the current table row
                        var data = this.dataItem(tr);

                        site.navigate("/details/" + data.get("Id"));
                        e.preventDefault();
                    }
                },
                {
                    name: "edit", click: function (e) {
                        // e.target is the DOM element representing the button
                        var tr = $(e.target).closest("tr"); // get the current table row (tr)
                        // get the data bound to the current table row
                        var data = this.dataItem(tr);

                        site.navigate("/edit/" + data.get("Id"));
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
        setCurrent: function (siteId) {
            this.set("current", siteDataSource.get(siteId));
        },
        submitEnabled: true,
        submit: function () {
            if (editValidator.validate()) {
                this.set("submitEnabled", false);

                siteDataSource.sync().then(function () {
                    editViewModel.set("submitEnabled", true);
                    site.navigate("/");
                });
            };
        }
    });

    var detailViewModel = kendo.observable({
        setSite: function (siteId) {
            var data = siteDataSource.get(siteId)
            this.set("site", data);

            addressDataSource.fetch(function (e) {
                detailViewModel.setAddress(data.get("addressId"));
            });

            //debugger;

            customerDataSource.fetch(function (e) {
                detailViewModel.setCustomer(data.get("customerId"));
            });
        },
        setAddress: function (addressId) {
            var data = addressDataSource.get(addressId)
            this.set("address", data);
        },
        setCustomer: function (customerId) {
            var data = customerDataSource.get(customerId)
            this.set("customer", data);
        }
    })

    var createViewModel = new kendo.observable({
        init: function () {
            this.set("customerId", "");
            this.set("addressId", "");
            this.set("name", "");
            this.set("phone", "");
            this.set("email", "");
            this.set("franchise", false);
            this.set("headQuarters", false);
        },
        submitEnabled: true,
        submit: function () {
            if (createValidator.validate()) {
                this.set("submitEnabled", false);

                siteDataSource.add({
                    CustomerId: this.get("customerId"),
                    AddressId: this.get("addressId"),
                    Name: this.get("name"),
                    Phone: this.get("phone"),
                    Email: this.get("email"),
                    Franchise: this.get("franchise"),
                    HeadQuarters: this.get("headQuarters"),

                });

                siteDataSource.sync().then(function () {
                    createViewModel.set("submitEnabled", true);
                    site.navigate("/");
                });
            };
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

            ////Map is put here
            //function createMap() {
            //    $("#site-map").kendoMap({
            //        center: [33.868100, 151.207500],
            //        zoom: 3,
            //        layers: [{
            //            type: "tile",
            //            urlTemplate: "http://#= subdomain #.tile.openstreetmap.org/#= zoom #/#= x #/#= y #.png",
            //            subdomains: ["a", "b", "c"],
            //            attribution: "&copy; <a href='http://osm.org/copyright'>OpenStreetMap contributors</a>"
            //        }],
            //        markers: [{
            //            location: [33.868100, 151.207500],
            //            shape: "pinTarget",
            //            tooltip: {
            //                content: "CDB, Sydney"
            //            }
            //        }]
            //    });
            //}
            //$(document).ready(createMap);

            ////end of Map            

            var container = this.element.find("#create-form");
            createValidator = container.kendoValidator().data("kendoValidator");

            container.find("input[name=\"CustomerId\"]").kendoDropDownList({
                dataSource: customerDataSource,
                dataValueField: "Id",
                dataTextField: "Name",
                optionLabel: "Select a Customer..."
            });

            container.find("input[name=\"AddressId\"]").kendoAutoComplete({
                dataSource: addressDataSource,
                dataValueField: "Id",
                dataTextField: "FullAddress",
                placeholder: "Enter Address...",
                width: 300
            });

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
            var container = $("#edit-form");
            editValidator = container.kendoValidator().data("kendoValidator");

            container.find("input[name=\"CustomerId\"]").kendoDropDownList({
                dataSource: customerDataSource,
                dataValueField: "Id",
                dataTextField: "Description",
                optionLabel: "Select a Customer..."
            });

            container.find("input[name=\"ManagerId\"]").kendoAutoComplete({
                dataSource: addressDataSource,
                dataValueField: "Id",
                dataTextField: "Street1",
                template: "#= (data.Street1 && data.Suburb.SuburbName) ? Street1 + ', ' + Street1 : SuburbName #",
                valueTemplate: "#= (data.Street1 && data.Suburb.SuburbName) ? Street1 + ', ' + Street1 : SuburbName #",
                optionLabel: "Select a Address...",
            });

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
        model: detailViewModel,
        //Map init put here
        init: function () {

            //Map is put here

            function createMap() {
                $("#site-map").kendoMap({
                    center: [-33.868100, 151.207500],
                    zoom: 11,
                    layers: [{
                        type: "tile",
                        urlTemplate: "http://#= subdomain #.tile.openstreetmap.org/#= zoom #/#= x #/#= y #.png",
                        subdomains: ["a", "b", "c"],
                        attribution: "&copy; <a href='http://osm.org/copyright'>OpenStreetMap contributors</a>"
                    }],
                    markers: [{
                        location: [-33.868100, 151.207500],
                        shape: "pinTarget",
                        tooltip: {
                            content: "CDB, Sydney"
                        }
                    }]
                });
            }
            $(document).ready(createMap);

            //end of Map
        }
    });

    var index = new kendo.View("index-template", {
        init: function () {
            $("#index-grid").kendoGrid(siteGridOptions);
        }

    });

    // Initialize Router
    var site = new kendo.Router({
        init: function () {
            layout.render("#application");
        }
    });

    // Routing
    site.route("/", function () {
        layout.showIn("#content", index);


    });

    site.route("/create", function () {
        createViewModel.init();
        layout.showIn("#content", create);
    });

    site.route("/edit/:id", function (siteId) {
        siteDataSource.fetch(function (e) {
            if (editViewModel.get("current")) { // existing view, start transition, then update content. This is necessary for the correct view transition clone to be created.
                layout.showIn("#content", edit);
                editViewModel.setCurrent(siteId);
            } else {
                // update content first
                editViewModel.setCurrent(siteId);
                layout.showIn("#content", edit);
            }
        });
    });

    site.route("/details/:id", function (siteId) {
        siteDataSource.fetch(function (e) {
            if (detailViewModel.get("current")) { // existing view, start transition, then update content. This is necessary for the correct view transition clone to be created.
                layout.showIn("#content", detail);
                detailViewModel.setSite(siteId);
            } else {
                // update content first
                detailViewModel.setSite(siteId);
                layout.showIn("#content", detail);
            }
        });
    });

    $(function () {
        site.start();
    });
})();