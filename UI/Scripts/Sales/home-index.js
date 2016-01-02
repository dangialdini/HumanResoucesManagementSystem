$(function () {
    $("#GrossSalesComparisonChart").kendoChart({
        dataSource: {
            transport: {
                read: {
                    url: "/api/Sales/Home/GrossSaleComp",
                    type: "GET",
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },
        title: {
            text: "Comparison of Total Sales and Gross Profit"
        },
        legend: {
            position: "right"
        },
        series: [{
            field: "GrossProfit",
            name: "Gross Profit"
        },
        {
            field: "TotalSales",
            name: "Total Sales"
        }],
        categoryAxis: {
            field: "Employee.EmployeeName",
            labels: {
                rotation: -90
            },
            majorGridLines: {
                visible: false
            }
        },
        valueAxis: {
            labels: {
                format: "NO"
            },
            majorUnit: 100,
            line: {
                visible: false
            }
        },
        tooltip: {
            visible: true,
            format: "NO"
        }
    });



    $("#LeadAndSaleComparisonChart").kendoChart({
        dataSource: {
            transport: {
                read: {
                    url: "/api/Sales/Home/GrossSaleComp",
                    type: "GET",
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },
        title: {
            text: "Comparison of Finalised Sales and Non-Finalised Sales"
        },
        legend: {
            position: "right"
        },
        series: [{
            field: "TotalLeads",
            name: "Non-Finalised Sales"
        },
        {
            field: "TotalSales",
            name: "Finalised Sales"
        }],
        categoryAxis: {
            field: "Employee.EmployeeName",
            labels: {
                rotation: -90
            },
            majorGridLines: {
                visible: false
            }
        },
        valueAxis: {
            labels: {
                format: "NO"
            },
            majorUnit: 100,
            line: {
                visible: false
            }
        },
        tooltip: {
            visible: true,
            format: "NO"
        }
    });




    var selectedYear = 2014;

    

    $("#NoOfSales").kendoChart({
        dataSource: {
            transport: {
                read: {
                    url: "/api/Sales/Home/GrossSaleComp",
                    type: "GET",
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },
        title: {
            text: "Total Sales Made By Employee"
        },
        legend: {
            position: "right"
        },
        series: [{
            field: "TotalSales",
            name: "Total Sales"
        }],
        categoryAxis: {
            field: "Employee.EmployeeName",
            labels: {
                rotation: -90
            },
            majorGridLines: {
                visible: true
            }
        },
        valueAxis: {
            labels: {
                format: "NO"
            },
            majorUnit: 100,
            line: {
                visible: true
            }
        },
        tooltip: {
            visible: true,
            format: "NO"
        }
    });

    $("#GrossTotal").kendoChart({
        dataSource: {
            transport: {
                read: {
                    url: "/api/Sales/Home/GrossSaleComp",
                    type: "GET",
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },
        title: {
            text: "Gross Profit Made By Employee"
        },
        legend: {
            position: "right"
        },
        series: [{
            field: "GrossProfit",
            name: "Gross Profit"
        }],
        categoryAxis: {
            field: "Employee.EmployeeName",
            labels: {
                rotation: -90
            },
            majorGridLines: {
                visible: true
            }
        },
        valueAxis: {
            labels: {
                format: "NO"
            },
            majorUnit: 100,
            line: {
                visible: true
            }
        },
        tooltip: {
            visible: true,
            format: "NO"
        }
    });


    ////////////////////////////////////////////// Customer Charts /////////////////////////////////////////////////////////



    $("#CusGrossSalesComparisonChart").kendoChart({
        dataSource: {
            transport: {
                read: {
                    url: "/api/Sales/Home/CusSaleComp",
                    type: "GET",
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },
        title: {
            text: "Comparison of Customers Total Sales and Gross Profit"
        },
        legend: {
            position: "right"
        },
        series: [{
            field: "GrossProfit",
            name: "Gross Profit"
        },
        {
            field: "TotalSales",
            name: "Total Sales"
        }],
        categoryAxis: {
            field: "Customer.CustomerName",
            labels: {
                rotation: -90
            },
            majorGridLines: {
                visible: false
            }
        },
        valueAxis: {
            labels: {
                format: "NO"
            },
            majorUnit: 100,
            line: {
                visible: false
            }
        },
        tooltip: {
            visible: true,
            format: "NO"
        }
    });



    $("#CusLeadAndSaleComparisonChart").kendoChart({
        dataSource: {
            transport: {
                read: {
                    url: "/api/Sales/Home/CusSaleComp",
                    type: "GET",
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },
        title: {
            text: "Comparison of Customers Finalised Sales and Non-Finalised Sales"
        },
        legend: {
            position: "right"
        },
        series: [{
            field: "TotalLeads",
            name: "Non-Finalised Sales"
        },
        {
            field: "TotalSales",
            name: "Finalised Sales"
        }],
        categoryAxis: {
            field: "Customer.CustomerName",
            labels: {
                rotation: -90
            },
            majorGridLines: {
                visible: false
            }
        },
        valueAxis: {
            labels: {
                format: "NO"
            },
            majorUnit: 100,
            line: {
                visible: false
            }
        },
        tooltip: {
            visible: true,
            format: "NO"
        }
    });




    var selectedYear = 2014;



    $("#CusNoOfSales").kendoChart({
        dataSource: {
            transport: {
                read: {
                    url: "/api/Sales/Home/CusSaleComp",
                    type: "GET",
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },
        title: {
            text: "Total Sales Had By Customers"
        },
        legend: {
            position: "right"
        },
        series: [{
            field: "TotalSales",
            name: "Total Sales"
        }],
        categoryAxis: {
            field: "Customer.CustomerName",
            labels: {
                rotation: -90
            },
            majorGridLines: {
                visible: true
            }
        },
        valueAxis: {
            labels: {
                format: "NO"
            },
            majorUnit: 100,
            line: {
                visible: true
            }
        },
        tooltip: {
            visible: true,
            format: "NO"
        }
    });

    $("#CusGrossTotal").kendoChart({
        dataSource: {
            transport: {
                read: {
                    url: "/api/Sales/Home/CusSaleComp",
                    type: "GET",
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },
        title: {
            text: "Gross Profit Had By Customer"
        },
        legend: {
            position: "right"
        },
        series: [{
            field: "GrossProfit",
            name: "Gross Profit"
        }],
        categoryAxis: {
            field: "Customer.CustomerName",
            labels: {
                rotation: -90
            },
            majorGridLines: {
                visible: true
            }
        },
        valueAxis: {
            labels: {
                format: "NO"
            },
            majorUnit: 100,
            line: {
                visible: true
            }
        },
        tooltip: {
            visible: true,
            format: "NO"
        }
    });


    ////////////////////////////////////////////////   Experiment ////////////////////////////////////////////////


    $("#TotalByDate").kendoChart({
        dataSource: {
            transport: {
                read: {
                    url: "/api/Sales/Home/GrossByDate",
                    type: "GET",
                    dataType: "json"
                }
            },
            sort: {
                field: "year",
                dir: "asc"
            }
        },
        title: {
            text: "Gross Profit Made By Employee By Date"
        },
        legend: {
            position: "right"
        },
        series: [{
            field: "Employee.EmployeeName",
            name: "Employee"
        }],
        categoryAxis: {
            field: "Date",
            labels: {
                rotation: -90
            },
            majorGridLines: {
                visible: true
            }
        },
        valueAxis: {
            field: "GrossProfit",
            labels: {
                format: "NO"
            },
            majorUnit: 100000,
            line: {
                visible: true
            }
        },
        tooltip: {
            visible: true,
            format: "NO"
        }
    });


});



//var salesDataSource = new kendo.data.DataSource({
//    transport: {
//        read: {
//            url: "/api/sales",
//            type: "GET",
//            dataType: "json"
//        },
//    },
//    sort: {
//        field: "Date",
//        dir: "asc"
//    },
//    model: {
//        id: "SaleId",
//        fields: {
//            SaleId: {
//                editable: false,
//                nullable: true,
//                type: "number"
//            },
//            Date: {
//                editable: true,
//                type: "date"
//            },
//            OrderNumber: {
//                editable: true,
//                type: "number",
//                validation: {
//                    min: 1
//                }
//            },
//            Customer: {
//                editable: true,
//                defaultValue: {
//                    CustomerId: 0,
//                    CustomerName: ""
//                }
//            },
//            Employee: {
//                editable: true,
//                defaultValue: {
//                    EmployeeId: 0,
//                    EmployeeName: ""
//                }
//            },
//            Finalised: {
//                editable: true,
//                type: "boolean"
//            },
//        }
//    }

//});