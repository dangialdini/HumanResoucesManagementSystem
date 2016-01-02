$(function () {

    //var schedulerDataSource = new kendo.data.SchedulerDataSource({
    //    transport: {
    //        read: {
    //            url: "/api/LeadActions",
    //            type: "GET",
    //            dataType: "json"
    //        },
    //        create: {
    //            url: "/api/LeadActions",
    //            type: "POST",
    //            dataType: "json",
    //            contentType: "application/json",
    //            complete: function (e) {
    //                $("#schedulerSection").data("kendoScheduler").dataSource.read();
    //            }
    //        },
    //        update: {
    //            url: "/api/LeadActions",
    //            type: "PUT",
    //            dataType: "json",
    //            contentType: "application/json"
    //        },
    //        destroy: {
    //            url: "/api/LeadActions",
    //            type: "DELETE",
    //            contentType: "application/json"
    //        },
    //        parameterMap: function (data, type) {
    //            //if (type === "read")
    //            //{
    //            //    var scheduler = $("#schedulerSection").data("kendoScheduler");
    //            //    var result = {
    //            //        start: scheduler.view().start().toISOString(),
    //            //    end: scheduler.view().end().toISOString()
    //            //    }
    //            //    return result;
    //            //}
    //            return kendo.stringify(data);
    //        }
    //    },
    //    timezone: "Australia/Sydney",
    //    schema: {
    //        errors: 'Errors',
    //        total: 'Total',
    //        model: {
    //            id: "ActionId",
    //            fields: {
    //                ActionId: { from: "ActionId", type: "number" },
    //                Timestamp: {from : "Timestamp", nullable: true, type: "date"},
    //                title: { from: "Title", validation: { required: false } },
    //                start: { type: "date", from: "NextContactDate", defaultValue: "" },
    //                NextContactDate: { type: "date", from: "NextContactDate" },
    //                EndContact: { type: "date", from: "EndContact" },
    //                startTimezone: { from: "StartTimezone" },
    //                endTimezone: { from: "EndTimezone" },
    //                IsAllDay: { type: "boolean", from: "IsAllDay" },
    //                recurrenceId: { from: "RecurrenceID" },
    //                recurrenceRule: { from: "RecurrenceRule" },
    //                recurrenceException: { from: "RecurrenceException" },
    //                Customer: {
    //                    from: "Customer",
    //                    editable: true,
    //                    defaultValue: { 
    //                        CustomerId: 0,
    //                        CustomerName: ""
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    //filter: {
    //    //    logic: "or",
    //    //    filters: [
    //    //        { field: "SalePositionLeadId", operator: "eq", value: 1 },
    //    //        { field: "SalePositionLeadId", operator: "eq", value: 2 }
    //    //    ]
    //    //}
    //});


    //var schedulerOptions = {
    //    date: new Date("2015/6/13"),
    //    startTime: new Date("2015/6/13 07:00 AM"),
    //    height: 600,
    //    views: [
    //        "day",
    //        { type: "workWeek", selected: true },
    //        "week",
    //        "month",
    //        "agenda",
    //        { type: "timeline", eventHeight: 50 }
    //    ],
    //    dataSource: schedulerDataSource,
    //    selectable: true,
    //    editable: {
    //        mode: 'popup',
    //        template: kendo.template($("#edit-template").html())
    //    },
    //    eventTemplate: $("#scheduler-event-template").html()
    //    //dataBinding: scheduler_dataBinding,
    //    //dataBound: scheduler_dataBound,
    //    //save: scheduler_save,
    //    //remove: scheduler_remove,
    //    //edit: scheduler_edit,
    //    //cancel: scheduler_cancel
    //};

    //$(function () {
    //    $("#schedulerSection").kendoScheduler(schedulerOptions).data("kendoScheduler");
    //});


    //var app = angular.module("actionsApp", ["kendo.directives"]);

    //app.controller('ActionController', ['$scope', function ($scope) {
    //    $scope.schedulerOptions = schedulerOptions;
    //}])

});