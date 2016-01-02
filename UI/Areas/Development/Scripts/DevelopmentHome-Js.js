function createChart() {
    $("#chart").kendoChart({
        title: {
            text: "Project Progress"
        },
        legend: {
            visible: false
        },
        seriesDefaults: {
            type: "bar"
        },
        series: [{
            name: "Submitted Projects",
            data: [25, 30, 40, 45, 50, 60]
        }, {
            name: "Completed Projects",
            data: [25, 30, 23, 40, 47, 59]
        }],
        valueAxis: {
            max: 140,
            line: {
                visible: false
            },
            minorGridLines: {
                visible: true
            },
            labels: {
                rotation: "auto"
            }
        },
        categoryAxis: {
            categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun"],
            majorGridLines: {
                visible: false
            }
        },
        tooltip: {
            visible: true,
            template: "#= series.name #: #= value #"
        }
    });
}

$(document).ready(createChart);
$(document).bind("kendo:skinChange", createChart);