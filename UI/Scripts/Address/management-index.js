//Management - SITE - Index

(function () {
    //alert("hello from Management-site-index");
    var addressDataSource = new kendo.data.DataSource({

        transport: {

            read: { url: "/api/addresses/Get", type: "get", dataType: "json" },
            create: { url: "/api/addresses/Post", type: "post", dataType: "json", contentType: "application/json" },
            update: { url: "/api/addresses/Update", type: "put", dataType: "json", contentType: "application/json" },

            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        },

        pageSize: 20,
        schema: {
            model: {
                id: "addressId",
                fields: {
                    addressId: { from: "Id", type: "number", validation: { min: 1 } },
                    //We also need to update the model to receive this new template Value
                    street1: { from: "Street1", type: "string", validation: { required: true } },
                    street2: { from: "Street1", type: "string", validation: { required: true } },
                    suburbId: { from: "SuburbId", type: "number", validation: { min: 1 } },
                    suburbName: { from: "SuburbName" },
                }
            }
        }
    });

    var app = angular.module("addressApp", ["kendo.directives"]);

    app.controller("AddressController", ["$scope", function ($scope) {
        $scope.gridOptions = {
            dataSource: addressDataSource,
            height: 600,
            filterable: { mode: "row" },
            //groupable: true,
            //sortable: true,
            pageable: true,
            toolbar: [{ name: "create", text: "Register New Address" }],
            columns: [

             //{ field: "addressId", title: "Address Id", width: 120 },
             //we declare a suburb special  template for
             { field: "street1", title: "Street1", width: 250 },
             { field: "street2", title: "Street2", width: 250 },
             { field: "suburbName", title: "Suburb", width: 200 },

             { command: ["edit"], title: "&nbsp;" }
            ],
            //we pass the template to the editor
            editable: {
                mode: "popup",
                template: kendo.template($("#address-popup-editor").html()), window: { draggable: true }
            },

            edit: function (e) {

                var model = e.model;

                var customerInput = e.container.find("input[name=\"suburbId\"]");

                customerInput.kendoDropDownList({
                    autoBind: false,
                    dataSource: {
                        transport: {
                            read: { url: "/api/AddressSuburbs/", dataType: "json", type: "get" }
                        }
                    },
                    //We don't need to explicitely overwrite this field before passing the form
                    //change: function (e) {
                    //	model.set("suburbId", 1);
                    //}
                });
            }
        };


    }]);
})();




