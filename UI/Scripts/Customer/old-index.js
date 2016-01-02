//Management - CUSTOMER - Index

$(document).ready(function () {

    
    var customerDataSource = new kendo.data.DataSource({
        transport: {
            read: { url: "/api/customers/Get", type: "get", dataType: "json" },
            create: { url: "/api/customers/Post", type: "post", dataType: "json", contentType: "application/json" },
            update: { url: "/api/customers/Update", type: "put", dataType: "json", contentType: "application/json" },
            destroy: { url: "/api/customers/Delete", type: "delete", contentType: "application/json" },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        },

        pageSize: 20,
        schema: {
            model: {
                id: "Id",
                fields:
                    {
                        //customerId:     { from: "Id" },
                        companyId: { from: "CompanyId", type: "number", editable: false, defaultValue: 1 },
                        name: { from: "Name", type: "string", validation: { required: true } },
                        ABN: { from: "ABN", type: "number", validation: { required: true , maxlength: 10} },
                        franchise: { from: "Franchise", type: "boolean" },
                        phone: { from: "Phone", validation: { required: true } },
                        email: { from: "Email", validation: { required: true } },
                    }
            }
        }
    });

    $('#customer-grid').kendoGrid({
        dataSource: customerDataSource,
        height: 600,
        pageable: true,
        toolbar: [{ name: "create", text: "Register New Customer" }],
        columns: [
            //{ field: "Id", title: "Customer Id", width: 120},
            //{ field: "companyId", title: "Company Id", width: 120},
            { field: "name", title: "Name", width: 200 },
            { field: "abn", title: "ABN", width: 200 },
            { field: "franchise", title: "Franchise", width: 120 },
            { field: "phone", title: "Phone", width: 200 },
            { field: "email", title: "Email", width: 240 },
            { command: ["edit", "delete"], title: "&nbsp;" }
        ],
        editable: "popup"
    });

});
