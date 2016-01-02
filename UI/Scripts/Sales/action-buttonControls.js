$(function () {
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
    //$("#editAction").click(function (e) {
    //    id(e.selected.id != null)
    //    {
    //        if ($("#schedulerSection").is(":visible")) {
    //            var scheduler = $("#scheduler").data("kendoScheduler");
    //            var event = scheduler.dataSource.at(e.selected.id);
    //            scheduler.editEvent();
    //        }
    //    }
    //});
    //$("#deleteAction").click(function (e) {
    //    if (e.selected.id != null) {
    //        if ($("#schedulerSection").is(":visible")) {
    //            var scheduler = $("#scheduler").data("kendoScheduler");
    //            var event = scheduler.dataSource.at(e.selected.id);
    //            scheduler.removeEvent(event);
    //        }
    //        else {
    //            var grid = $("#grid").data("kendoGrid");
    //            grid.removeRow("tr:eq(" + e.selected.id + ")");
    //        }
    //    }
    //});

    $("#gridButton").click(function () {
        $("#grid").show();
        $("#schedulerSection").hide();
        $("#addAction").hide();
        $("#gridControls").show();
        $("#schedulerControls").hide();
    });

    $("#schedulerButton").click(function () {
        $("#schedulerSection").show();
        $("#addAction").show();
        $("#grid").hide();
        $("#gridControls").hide();
        $("#schedulerControls").show();
    });

});