//Training/Schedule/index.js
//var currentSiteId = $("#siteId").data("value");
(function () {
    var siteDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/sites",
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

    var employeeDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/employees/training",
                type: "GET",
                dataType: "json"
            }
        },
        schema: {
            model: {
                id: "EmployeeId"
            }
        }
    });

    var trainingDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/training",
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

    var schedulerDataSource = new kendo.data.SchedulerDataSource({
        transport: {
            read: {
                url: "/api/trainingsession",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/trainingsession",
                type: "POST",
                dataType: "json",
                contentType: "application/json"
            },
            update: {
                url: "/api/trainingsession",
                type: "PUT",
                dataType: "json",
                contentType: "application/json"
            },
            destroy: {
                url: "/api/trainingsession",
                type: "DELETE",
                contentType: "application/json"
            },
            parameterMap: function (data, type) {
                //debugger;
                if (type !== "read") {
                    return kendo.stringify(data);
                }
                //return kendo.stringify(data);
            }
        },
        schema: {
            timezone: "Australia/Sydney",
            model: {
                id: "trainingsessionId",
                fields: {
                    trainingsessionId: { from: "Id", type: "number"},
                    siteId: { from: "SiteId", type: "number", validation: { required: true } },
                    trainingId: { from: "TrainingId", type: "number", validation: { required: true } },
                    employeeTrainerId: { from: "EmployeeTrainerId", type: "number", validation: { required: true } },
                    start: { from: "Start", type: "date" },
                    end: { from: "End", type: "date" },
                    durationInMinutes: { from: "DurationInMinutes", type: "number"},
                    delivered: { from: "Delivered", type: "boolean" },
                    
                    startTimezone: { from: "StartTimezone" },
                    endTimezone: { from: "EndTimezone" },
                    recurrenceId: { from: "RecurrenceId", type: "number" },
                    recurrenceRule: { from: "RecurrenceRule" },
                    recurrenceException: { from: "RecurrenceException" },
                    isAllDay: { from: "IsAllDay", type: "boolean" },
                    description: { from: "Description" },
                    title: { from: "Title"}
                }
            }
        }
    });

    var schedulerOptions = {
        dataSource: schedulerDataSource,
        date: new Date("2015/10/13"),
        startTime: new Date("2015/10/13 08:00 AM"),
        height: 600,
        allDaySlot: false,
        showWorkHours: true,
        workDayStart: new Date("2010/1/1 08:00 AM"),
        workDayEnd: new Date("2010/1/1 10:00 PM"),
        mobile: true,
        selectable: true,
        footer: false,
        dateHeaderTemplate: kendo.template("<strong>#=kendo.toString(date, 'dddd')#</strong>"),
        majorTimeHeaderTemplate: kendo.template("<strong>#=kendo.toString(date, 'h')#</strong><sup>00</sup>"),
        views: [
            "day",
            { type: "workWeek", selected: true },
            "week", "month", "agenda",
            { type: "timeline", evenHeight: 50 }
        ],
        editable: {
            confirmation: "Are sure sure u want to delete this schedule?",
            editRecurringMode: "dialog",
            template: $("#custom-shift-popup").html(),
            window: {
                title: "Schedule",
                minWidth: "90px",
                actions: ["Minimize", "Close"] }
        },
        edit: function (e) {
            var model = e.data;

            var siteId = e.container.find("#siteId").data("kendoDropDownList");
            siteId.setDataSource(siteDataSource);
            //var value1 = $("#siteId").val();
            //if ($("#siteId").val() != currentSiteId) {
            //    e.preventDefault();
            //}

            var training = e.container.find("#trainingId").data("kendoDropDownList");
            training.setDataSource(trainingDataSource);
            var employeeId = e.container.find("#employeeTrainerId").data("kendoDropDownList");
            employeeId.setDataSource(employeeDataSource);
        },
        messages: {
            deleteWindowTitle: "Delete Session",
            time: "Time of the day",
            today: "Current",
            editor: {
                description: "Notes",
                end: "End",
                repeat: "Mulitple Session?",
                start: "Start",
            },
            views: {
                day: "Today",
            }
        },
        save: function (e) {
            //debugger;
            console.log("Saving", e.event.title);
        }
    };
    
    $(document).ready(function () {
        $("#session-scheduler").kendoScheduler(schedulerOptions);
    });

    $("#allemployees").change(function () {
        var multiselect = $("#multiselect1").data("kendoMultiSelect");
        if (document.getElementById("allemployees").checked) {
            multiselect.enable(true);
        }
        else {

            multiselect.value(0);
            schedulerDataSource.filter([]);
            multiselect.enable(false);
        }
    });

    var multiselect = $("#multiselect1").kendoMultiSelect({
        dataSource: employeeDataSource,
        dataTextField: "EmployeeName",
        dataValueField: "EmployeeId",
        autoClose: false,
        placeholder: "Click to select employees",
        value: [0],
        change: function (e) {
            var value = this.value();
            if (value.length > 0) {
                schedulerDataSource.filter({
                    operator: function (task) {
                        return $.inArray(task.employeeTrainerId, value) >= 0;
                    }
                })
            }
            else if (value.length == 0) {
                schedulerDataSource.filter([]);
            }
        },
        enable: false,
    });

    $("#allSites").change(function () {
        var multiselect = $("#multiselect2").data("kendoMultiSelect");
        if (document.getElementById("allSites").checked) {
            multiselect.enable(true);
        }
        else {

            multiselect.value(0);
            schedulerDataSource.filter([]);
            multiselect.enable(false);
        }
    });
    var multiselect = $("#multiselect2").kendoMultiSelect({
        dataSource: siteDataSource,
        dataTextField: "Name",
        dataValueField: "Id",
        autoClose: false,
        placeholder: "Click to select sites",
        value: [0],
        change: function (e) {
            var value = this.value();
            if (value.length > 0) {
                schedulerDataSource.filter({
                    operator: function (task) {
                        return $.inArray(task.siteId, value) >= 0;
                    }
                })
            }
            else if (value.length == 0) {
                schedulerDataSource.filter([]);
            }
        },
        enable: false,
    });


    $("#printpage").click(function (e) {
        var schedulerElement = $("#session-scheduler")
        schedulerElement.width(900);
        schedulerElement.data("kendoScheduler").resize();
        window.print();
        schedulerElement.width("");
        schedulerElement.data("kendoScheduler").resize();
    });

    function fitWidget() {
        var widget = $("#session-scheduler").data("kendoScheduler");
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
})();
