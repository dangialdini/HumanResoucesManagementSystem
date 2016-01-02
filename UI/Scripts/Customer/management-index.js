//Management - CUSTOMER - Index
$(document).ready(function () {
    //alert("This Area is For Managers Only");
    //$("#customer-menu").kendoMenu();
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
                        companyId:  { from: "CompanyId", type: "number", editable: false, defaultValue: 1 },
                        name:       { from: "Name", type: "string", validation: { required: true, validationMessage: "Enter a Company Name" } },
                        abn:        { from: "ABN", type: "number", validation: { required: true, validationMessage: "Enter a valid ABN Number" , maxLength : "10" } },
                        franchise:  { from: "Franchise", type: "boolean" },
                        phone:      { from: "Phone", type: "phone", validation: { required: true, validationMessage: "Enter at least ten digits" } },
                        email:      { from: "Email", type: "email", validation: { required: true, validationMessage: "Enter a valid Email Address" } },
                    }
            }
        }
    });

    $('#management-customer-grid').kendoGrid({
        dataSource: customerDataSource,
        height: 600,
        filterable: { mode: "row" },
        //groupable: true,
        //sortable: true,
        pageable: true,
        toolbar: [{ name: "create", text: "Register New Customer" }],
        columns: [
            //{ field: "Id", title: "Customer Id", width: 120},
            //{ field: "companyId", title: "Company Id", width: 120},
            { field: "name", title: "Company Name", width: 200 , filterable: { cell: { operator: "contains"} } },
            { field: "abn", title: "ABN Number", width: 200 , filterable: { cell: { operator: "contains"} } },
            { field: "phone", title: "Contact Phone", width: 200, filterable: { cell: { operator: "contains"} } },
            { field: "franchise", title: "Franchise", width: 150, filterable: false },
            { field: "email", title: "Contact Email", width: 240, filterable: { cell: { operator: "contains" } } },
            { command: ["edit", "delete"], title: "&nbsp;" }
        ],
        editable: "popup"
    });
        
    
    ////Here we pass the DataSource for the Chart
    var ChartDataSource = new kendo.data.DataSource({
        transport: {
            read: { url: "/api/customers/CustomersPerZone", type: "get", dataType: "json" },
            parmeterMap: function (data, type) {
                return kendo.stringify(data);
            }
        }
    })
    //Here we add a chart script
   
        $("#customer-chart").kendoChart({
            title: {
                text: "Customers Per Sydney Area"
            },
            dataSource: ChartDataSource,
            legend: {
                visible: false
            },
            series: [{
                type: "radarColumn",
                name: "Customers Per Sydney Area",
                data: [
                    5, 1, 1, 5, 0, 1,
                    1, 2, 1, 2, 1, 0,
                    0, 2, 1, 0, 3, 1,
                    1, 1, 0, 0, 0
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
    
    }
)
