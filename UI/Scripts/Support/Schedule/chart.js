$(function () {


    var chartDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: '/api/SupportStaffShifts/',
                dataType: 'json',
                type: 'GET'
            }
        },
        sort: {
            field: "order",
            dir: "asc"
        },
        group: {
            field: "employee"
        },
        schema: {
            parse: function (response) {
                var shifts = [];
                for (var i = 0; i < response.length; i++) {
                    var shift = {
                        id: response[i].Id,
                        employeeId: response[i].EmployeeId,
                        start: response[i].Start,
                        end: response[i].End,
                        employee: response[i].Title,
                        color: response[i].Color,
                        hours: (moment(response[i].End).diff(moment(response[i].Start))/3600000)
                    };
                    shifts.push(shift);
                }
                return shifts;
            },
        },
    });


    var employeedonut = $("#scheduledhoursdonut").kendoChart({
        dataSource: chartDataSource,
        title: {
            text: "Scheduled Hours - Support Staff"
        },        
        legend: {
            position: "bottom"
        },
        tooltip: {
            visible: true,
            //template: "#= employee #"
        },
        seriesDefaults: {
            type: "donut",
            startAngle: 90
        },
        //seriesColors: [ "red", "green", "blue", "purple" ],
        series: [{            
            field: "hours",
            categoryField: "employee",
            visibleInLegendField: "visibleInLengend",
            padding: 10
        }],
        categoryAxis: {
            categories: [2014, 2015]
        }
    })

    var text = "Employees";
    $(".inner-content").text(text);


    function getTotalHours(e) {

        return total;
    }

    var donutchart = $("#scheduledhoursdonut2").kendoChart({
        title: { text: "Football stats" },
        legend: { position: "bottom" },
        tooltip: { visible: true, template: "#= category # - #= kendo.format('{0:P}', percentage) #" },
        seriesDefaults: { 
            labels: { 
                template: "#= category # - #= kendo.format('{0:P}', percentage)#",
                position: "outsideEnd",
                visible: true,
                background: "transparent"
            }},
        series: [{ 
            type: "donut",
            data: [{
                category: "Football",   // EmployeeName
                value: 35               // # of Hours
            }, {
                category: "Basketball",
                value: 25
            }, {
                category: "Volleyball",
                value: 20
            }, {
                category: "Rugby",
                value: 10
            }, {
                category: "Tennis",
                value: 10
            }]
        }],
    });


    function getDataSource() {
        chartDataSource.fetch(function () {
            var data = this.data();
            return this.view();
            //alert(data.employee);



            //alert(view.length);                     // Number of "Categories" GROUPED (From Group.Field)
            //var chiefWiggum = view[0];                // Displays the first "Category"
            //alert(chiefWiggum.value);                 // Dispalys Cheif Wiggums name
            //alert(chiefWiggum.items[0].hours);        // Displays Cheif Wiggums fist shift hours

            //var homer = view[1];
            //alert(homer.value);
            //alert(homer.items[0].hours);

            //var nedflanders = view[3];


        })
    }
})