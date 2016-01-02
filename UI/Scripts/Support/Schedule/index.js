$(function () {

    /* ------------------------------ MAIN DATASOURCE ------------------------------ */
    var rosterDataSource = new kendo.data.SchedulerDataSource({
        transport: {
            read: {
                url: '/api/SupportStaffShifts/',
                dataType: 'json',
                type: 'GET'
            },
            create: {
                url: '/api/SupportStaffShifts/',
                dataType: 'json',
                type: 'POST',
                contentType: 'application/json'
            },
            update: {
                url: '/api/SupportStaffShifts/',
                dataType: 'json',
                type: 'PUT',
                contentType: 'application/json'
            },
            destroy: {
                url: '/api/SupportStaffShifts/',
                type: 'DELETE',
                contentType: 'application/json'
            },
            parameterMap: function (data, operation) {
                if (operation == "read") {
                    var scheduler = $("#scheduler").data("kendoScheduler");
                }
                return kendo.stringify(data);
            }
        },
        schema: {
            timezone: "Australia/Sydney",
            model: {
                id: 'Id',
                fields: {
                    Id: { from: "Id", type: "number" },
                    start: { from: "Start", type: "date" },
                    end: { from: "End", type: "date" },
                    description: { from: "Description" },
                    title: { from: "Title" },                   
                    employeeId: { from: "EmployeeId" },
                    color: { from: "Color", defaultValue: "#ffffff" },
                    startTimezone: { from: "StartTimezone" },
                    endTimezone: { from: "EndTimezone" },
                    recurrenceRule: { from: "RecurrenceRule" },
                    recurrenceException: { from: "RecurrenceException" },
                    isAllDay: { from: "IsAllDay", type: "boolean" },
                    frequency: { from: "Frequency" },                   
                }
            },
        },
    });  /* ------------------------------ END MAIN DATASOURCE ------------------------------ */



    /* ------------------------------ EMPLOYEE DATASOURCE ------------------------------ */
    var employeeDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: '/api/SupportStaffShifts/GetEmployees/',
                dataType: 'json',
                type: 'GET'
            },
        },
    });/* ------------------------------ END EMPLOYEE DATASOURCE ------------------------------ */



    /* ------------------------------ SCHEDULER OPTIONS ------------------------------ */
    var scheduler = $("#scheduler").kendoScheduler({
        dataSource: rosterDataSource,
        date: new Date(),
        startTime: new Date("2010/1/1 08:00 AM"),
        dateHeaderTemplate: kendo.template("<strong>#=kendo.toString(date, 'dddd')#</strong>"),
        allDaySlot: false,
        views: [{ type: "day" }, { type: "week", selected: true }, { type: "month" }],
        showWorkHours: true,
        workDayStart: new Date("2010/1/1 08:00 AM"),
        workDayEnd: new Date("2010/1/1 10:00 PM"),
        majorTimeHeaderTemplate: kendo.template("<strong>#=kendo.toString(date, 'h')#</strong><sup>00</sup>"),
        mobile: true,
        selectable: false,
        footer: true,
        eventTemplate: 
            ' <div style="background-color:#= color #; border-color:#= color #; height:100%; width:100%"> '
            + '<p>#: title #</p> '
            + '</div>',
        editable: {
            confirmation: "Are you sure you want to delete this shift?",
            template: $("#customshiftpopup").html(),
            window: {
                title: "Schedule Shift",
                minWidth: "90px",
                actions: ["Minimize", "Close"],
            },
        },
        edit: function (e) {
            $("#employeeId").kendoDropDownList({ dataValueField: "employeeId", dataTextField: "employeeName" });
            var employeeDropDown = $("#employeeId").data("kendoDropDownList");
            employeeDropDown.setDataSource(employeeDataSource); // Need this to rebind the dropdown widget every time the popup window is opened, otherwise "undefined" is displayed  
        },
        messages: {
            deleteWindowTitle: "Delete Shift",
            time: "Time of the day",
            today: "Current",
            views: {
                day: "Today",
            }
        },
    }).data("kendoScheduler"); /* ------------------------------ END SCHEDULER  ------------------------------ */


    $("#allemployees").change(function () {
        var multiselect = $("#multiselect").data("kendoMultiSelect");
        if (document.getElementById("allemployees").checked) {
            $("#toggle").show();
        } else {
            $("#toggle").hide();
            multiselect.value(0);
            scheduler.dataSource.filter([]);
        }
    });

    var multiselect = $("#multiselect").kendoMultiSelect({
        dataSource: employeeDataSource,
        dataTextField: "EmployeeName",
        dataValueField: "EmployeeId",
        autoClose: false,
        enable: true,
        placeholder: "Click here to filter employees",
        value: [0],
        change: function (e) {
            var value = this.value();
            if (value.length > 0) {
                scheduler.dataSource.filter({
                    operator: function (task) {
                        return $.inArray(task.employeeId, value) >= 0;
                    }
                })
            }
            else if (value.length == 0) {
                scheduler.dataSource.filter([]);
            }
        },
        
    });

    $("#printpage").click(function (e) {
        var schedulerElement = $("#scheduler")
        schedulerElement.width(900);
        schedulerElement.data("kendoScheduler").resize();
        window.print();
        schedulerElement.width("");
        schedulerElement.data("kendoScheduler").resize();
    });

    function fitWidget() {
        var widget = $("#scheduler").data("kendoScheduler");
        var height = $(window).outerHeight();

        widget.element.height(height);
        widget.resize(true);
    }
    $(window).resize(function () {
        clearTimeout(window._resizeId);

        window._resizeId = setTimeout(function () {
            console.log("resize");
            fitWidget();
        }, 500);
    });
    fitWidget();

})