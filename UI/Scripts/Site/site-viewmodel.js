$(document).ready(function () {
    var siteDataSource = new kendo.data.Source({
        transport: {
            read: {
                url: "/api/sites",
                type: "get",
                dataType: "json"
            },
            create: {
                url: "/api/sites",
                type: "post",
                dataype: "json",
                contentType: "application/json"
            },
            destroy: {
                url: "/api/sites",
                type: "delete",
                contentType: "application/json"
            },

            parameterMap: function (data, type) {
                kendo.stringify(data);
            }
        },

        schema: {
            model: {
                id: "Id",
                fields: {
                    Id: {
                        from: "Id"
                    },
                    customerId: {
                        from: "CustomerId"
                    },

                    addressId: {
                        from: "AddressId"
                    },


                    name: {
                        from: "Name",
                        type: "string"
                    },
                    phone: {
                        from: "Phone"

                    },
                    name: {
                        from: "Name",
                        type: "string"
                    },

                    phone: {
                        from: "Phone",
                        type: "number"
                    },

                    email: {
                        from: "Email"
                    },
                    franchise: {
                        from: "Franchise"

                    },
                    headquarters: {
                        from: "HeadQuarters"

                    }
                }
            }
        }

    });
    $('#site-grid').kendoGrid();

});
