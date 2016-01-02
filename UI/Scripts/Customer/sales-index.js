//Sale Leads Customer Grid - Team C

$(function () {
    var datasource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Customers",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/Customers",
                type: "POST",
                contentType: "application/json",
                dataType: "json"
            },
            update: {
                url: "/api/Customers",
                type: "PUT",
                contentType: "application/json",
                dataType: "json"
            },
            destroy: {
                url: "/api/Customers",
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
                id: "Id",
                fields: {
                    Id: { editable: false, nullable: true, type: "number" },
                    Name: { editable: true, nullable: true, type: "string" },
                    Franchise: {editable: true, type: "boolean" },
                    Phone: { editable: true, nullable: true, type: "string" },
                    Email: { editable: true, nullable: true, type: "string" }
                }
            }
        },
        serverPaging: true,
        serverSorting: true,
        pageSize: 10

    });

    $("#cust-grid").kendoGrid({
        dataSource: datasource,
        height: 600,
        sortable: true,
        pageable: true,
        groupable: true,
        detailInit: detailInit,
        dataBound: function () {
            this.expandRow(this.tbody.find("tr.k-master-row").first());
        },
        columns: [
            {
                field: "Id",
                title: "Customer Id"
            },
            {
                field: "Name",
                title: "Name"
            },
            {
                field: "Franchise",
                title: "Franchise"
            },
            {
                field: "Phone",
                title: "Phone"
            },
            {
                field: "Email",
                title: "Email"
            },

            { command: ["edit", "destroy"] }
        ],
        toolbar: ["create"],
        editable: 'popup'
    });



    function detailInit(e) {
        var sid = e.id;
        $("<div/>").appendTo(e.detailCell).kendoGrid({
            dataSource: {
                transport: {
                    read: {
                        url: "/api" + e.data.Id + "/SaleLeads",
                        type: "GET",
                        dataType: "json",
                        data: e.data.CustomerId
                    },
                    create: {
                        url: "/api/SaleLeads/" + e.data.Id + "/Customer",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json",
                        data: e.data.CustomerId
                    },
                    parameterMap: function (options, operation) {

                        //options.saleId = e.CustomerId;
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
                        id: "SaleLeadId",

                        fields: {
                            SaleLeadId: { editable: false },
                            StateId: { type: "number" },
                            SaleId: { type: "number" },
                            Timestamp: { type: "date", validation: { required: true } },
                            CustomerId: { editable: false, nullable: false, type: "number", defaultValue: "#: CustomerId #" }
                        }

                    }
                },
                serverPaging: true,
                serverSorting: false,
                serverFiltering: true,
                pageSize: 10,
                filter: { field: "Id", operator: "eq", value: e.data.Id }
            },
            scrollable: false,
            sortable: true,
            pageable: true,
            columns: [

                { field: "SaleLeadId", title: "Lead", width: "100px" },
                { field: "StateId", title: "State", width: "120px", template: "#= StateName #" },
                { field: "SaleId", title: "Sale", width: "120px" },
                { field: "Timestamp", title: "Timestamp", format: "{0:MMMM dd, yyyy}", width: "120px" },

            ],
            editable: 'popup',
            toolbar: ["create"]

        });
    }




});

