$(function () {

    // Main Grid DataSource
    var GridDataSource = new kendo.data.DataSource({       
        transport: {
            read: {
                url: "/api/employees",
                type: "GET",
                dataType: "json"
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        },
        pageSize: 10,
        schema: {
            model: {
                id: "EmployeeId",
                fields: {
                    EmployeeId: { editable: false, defaultValue: "Undefined" },
                    Company: { defaultValue: { Id: 1, Name: "RedCat" }, validation: { required: true } },
                    Firstname: { validation: { required: true } },
                    Lastname: { validation: { required: true } },
                    DateOfBirth: { type: "date", validation: { required: true } },
                    Phone: { validation: { required: true } },
                    Email: { validation: { required: true } }
                    }
                }
            }
        });

    // Employee Records Grid
        var grid = $("#grid").kendoGrid({
        dataSource: GridDataSource,
        pageable: true,
        sortable: true,
        editable: "popup",
        height: 550,
        columns: [
            { field: "EmployeeId", title: "Employee No.", width: "100px", attributes: { style: "text-align: center;" }},
            { field: "Company", title: "Company", hidden: true, width: "120px", attributes: { style: "text-align: center;" }, editor: CompanyDropDownEditor, template: "#=Company.Name#" },
            { field: "Firstname", title: "First Name", width: "120px", attributes: { style: "text-align: center;" } },
            { field: "Lastname", title: "Last Name", width: "120px", attributes: { style: "text-align: center;" } },          
            { field: "DateOfBirth", title: "D/O/B", hidden: true, format: "{0:MMMM dd, yyyy}", width: "120px", attributes: { style: "text-align: center;" } },
            { field: "Phone", title: "Phone", width: "120px", attributes: { style: "text-align: center;" } },
            { field: "Email", title: "Email", width: "120px", hidden: true, attributes: { style: "text-align: center;" } },
        ]});











    // DropDownList For Companies
        function CompanyDropDownEditor(container, options) {
            $('<input required data-text-field="Name" data-value-field="Id" data-bind="value:' + options.field + '"/>')
                .appendTo(container)
                .kendoDropDownList({
                    autoBind: false,
                    dataSource: {
                        transport: {
                            read: "/api/Companies/",
                            type: "GET",
                            dataType: "json"
                        }
                    }
                });
        };


    // Search Filter For Companies
        var dropDown = grid.find("#companies").kendoDropDownList({
        dataTextField: "Name",
        dataValueField: "Id",
        autoBind: false,
        optionLabel: "All",
        dataSource: {
            serverFiltering: true,
            transport: {
                read: "/api/Companies/",
                type: "GET",
                dataType: "json"
            }
        },
        change: function () {
            var value = this.value();
            if (value) {
                grid.data("kendoGrid").dataSource.filter({ field: "Company.Id", operator: "eq", value: parseInt(value) });
            } else {
                grid.data("kendoGrid").dataSource.filter({});
            }
        }
        });


    // Search Filter For Employees
        $("#employees").kendoAutoComplete({
            dataSource: GridDataSource,
            template: "#= Firstname # #= Lastname #",
            filter: "startswith", 
            dataTextField: "Firstname",
            placeholder: "Search Employee",
        }).data("AutoComplete");
});