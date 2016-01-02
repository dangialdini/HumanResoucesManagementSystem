$(document).ready(function () {
    var stats = [
                        { value: 30, date: new Date("2011/12/20") },
                        { value: 50, date: new Date("2011/12/21") },
                        { value: 45, date: new Date("2011/12/22") },
                        { value: 40, date: new Date("2011/12/23") },
                        { value: 35, date: new Date("2011/12/24") },
                        { value: 40, date: new Date("2011/12/25") },
                        { value: 42, date: new Date("2011/12/26") },
                        { value: 40, date: new Date("2011/12/27") },
                        { value: 35, date: new Date("2011/12/28") },
                        { value: 43, date: new Date("2011/12/29") },
                        { value: 38, date: new Date("2011/12/30") },
                        { value: 30, date: new Date("2011/12/31") },
                        { value: 48, date: new Date("2012/01/01") },
                        { value: 50, date: new Date("2012/01/02") },
                        { value: 55, date: new Date("2012/01/03") },
                        { value: 35, date: new Date("2012/01/04") },
                        { value: 30, date: new Date("2012/01/05") }
    ];

    function createChart() {
        $("#area-chart-date-axis").kendoChart({
            dataSource: {
                data: stats
            },
            series: [{
                type: "area",
                aggregate: "avg",
                field: "value",
                categoryField: "date"
            }],
            categoryAxis: {
                baseUnit: "weeks"
            }
        });
    }

    $(document).ready(createChart);
    $("#example").bind("kendo:skinChange", createChart);
    $(".box").bind("change", refresh);

    function refresh() {
        var chart = $("#area-chart-date-axis").data("kendoChart"),
            series = chart.options.series,
            categoryAxis = chart.options.categoryAxis,
            baseUnitInputs = $("input:radio[name=baseUnit]"),
            aggregateInputs = $("input:radio[name=aggregate]");

        for (var i = 0, length = series.length; i < length; i++) {
            series[i].aggregate = aggregateInputs.filter(":checked").val();
        }

        categoryAxis.baseUnit = baseUnitInputs.filter(":checked").val();

        chart.refresh();
    }

    $("#line-chart").kendoChart({
        title: {
            text: "Gross domestic product growth \n /GDP annual %/"
        },
        legend: {
            position: "bottom"
        },
        chartArea: {
            background: ""
        },
        seriesDefaults: {
            type: "line",
            style: "smooth"
        },
        series: [{
            name: "India",
            data: [3.907, 7.943, 7.848, 9.284, 9.263, 9.801, 3.890, 8.238, 9.552, 6.855]
        }, {
            name: "World",
            data: [1.988, 2.733, 3.994, 3.464, 4.001, 3.939, 1.333, -2.245, 4.339, 2.727]
        }, {
            name: "Russian Federation",
            data: [4.743, 7.295, 7.175, 6.376, 8.153, 8.535, 5.247, -7.832, 4.3, 4.3]
        }, {
            name: "Haiti",
            data: [-0.253, 0.362, -3.519, 1.799, 2.252, 3.343, 0.843, 2.877, -5.416, 5.590]
        }],
        valueAxis: {
            labels: {
                format: "{0}%"
            },
            line: {
                visible: false
            },
            axisCrossingValue: -10
        },
        categoryAxis: {
            categories: [2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011],
            majorGridLines: {
                visible: false
            },
            labels: {
                rotation: "auto"
            }
        },
        tooltip: {
            visible: true,
            format: "{0}%",
            template: "#= series.name #: #= value #"
        }
    });
});