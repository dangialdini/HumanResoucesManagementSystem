$(function () {
    var schedulerDataSource = new kendo.data.SchedulerDataSource({
        batch: false,
        transport: {
            read: {
                url: "/api/LeadActions",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/LeadActions",
                type: "POST",
                dataType: "json",
                contentType: "application/json"
            },
            update: {
                url: "/api/LeadActions",
                type: "PUT",
                dataType: "json",
                contentType: "application/json"
            },
            destroy: {
                url: "/api/LeadActions",
                type: "DELETE",
                dataType: "json",
                contentType: "application/json"
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        },
        schema: {
            model: {
                id: "Id",
                fields: {
                    id: { from: "Id", type: "number" },
                    nextContactDate: { type: "date", from: "NextContactDate" },
                    endContact: { type: "date", from: "EndContact" },
                    startTimezone: { type: "date", from: "StartTimezone" },
                    endTimezone: { type: "date", from: "EndTimezone" },
                    isAllDay: { type: "boolean", from: "IsAllDay" },
                    recurrenceRule: { from: "RecurrenceRule" },
                    recurrenceException: { from: "RecurrenceException" }
                }
            }
        },
        filter: {
            logic: "or",
            filters: [
                { field: "SalePositionLeadId", operator: "eq", value: 1 },
                { field: "SalePositionLeadId", operator: "eq", value: 2 }
            ]
        }
    });

    var gridDataSource = new kendo.data.DataSource({
        batch: true,
        transport: {
            read: {
                url: "/api/LeadActions",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/LeadActions",
                type: "POST",
                dataType: "json",
                contentType: "application/json"
            },
            update: {
                url: "/api/LeadActions",
                type: "PUT",
                dataType: "json",
                contentType: "application/json"
            },
            destroy: {
                url: "/api/LeadActions",
                type: "DELETE",
                dataType: "json",
                contentType: "application/json"
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        },
        schema: {
            model: {
                id: "Id"
            }
        },
        filter: {
            logic: "or",
            filters: [
                { field: "SalePositionLeadId", operator: "eq", value: 1 },
                { field: "SalePositionLeadId", operator: "eq", value: 2 }
            ]
        }
    });

    $("#scheduler").kendoScheduler({
        date: new Date("2013/6/13"),
        startTime: new Date("2013/6/13 07:00 AM"),
        height: 600,
        views: [
            "day",
            { type: "workWeek", selected: true },
            "week",
            "month",
            "agenda",
            { type: "timeline", eventHeight: 50 }
        ],
        timezone: "Etc/UTC",
        dataSource: schedulerDataSource,
        selectable: true


    });

    $("#grid").kendoGrid({
        dataSource: gridDataSource,
        height: 600,
        groupable: true,
        sortable: true,
        columns: [{
            field: "Timestamp",
            title: "Timestamp",
            width: 240
        },
        {
            field: "NextContactDate",
            title: "Next Contact Date",
            width: 240
        },
        {
            field: "EndContact",
            title: "End Contact",
            width: 240
        },
        {
            field: "IsAllDay",
            title: "Is All Day",
            width: 240
        },
        {
            field: "EndContact",
            title: "End Contact",
            width: 240
        },
        {
            field: "Notes",
            title: "Notes",
            width: 240
        }]
    });

    $("#gridButton").click(function () {
        $("#grid").show();
        $("#schedulerSection").hide();
        $("#editAction").hide();
    });

    $("#schedulerButton").click(function () {
        $("#schedulerSection").show();
        $("#editAction").show();
        $("#grid").hide();
    });


    $("#addAction").click(function () {
        if ($("#schedulerSection").is(":visible")) {
            var scheduler = $("#scheduler").data("kendoScheduler");
            scheduler.addEvent();
        }
        else {
            var grid = $("#grid").data("kendoGrid");
            grid.addRow();
        }

    });
    $("#editAction").click(function (e) {
        if ($("#schedulerSection").is(":visible")) {
            var scheduler = $("#scheduler").data("kendoScheduler");
            var event = scheduler.dataSource.at(e.selected.id);
            scheduler.editEvent();
        }
    });
    $("#deleteAction").click(function (e) {
        if ($("#schedulerSection").is(":visible")) {
            var scheduler = $("#scheduler").data("kendoScheduler");
            var event = scheduler.dataSource.at(e.selected.id);
            scheduler.removeEvent(event);
        }
        else {
            var grid = $("#grid").data("kendoGrid");
            grid.removeRow("tr:eq(" + e.selected.id + ")");
        }
    });

    $(document).ready(function () {
        $("#schedulerButton").click();
    });
});