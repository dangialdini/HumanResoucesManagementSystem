(function () {
    var viewModel = new kendo.observable({
        id: 0,
        customerId: 0,
        addressId: 0,
        name: 0,
        phone: 0,
        email: 0,
        franchise: 0,
        headQuarters: 0,
        submitEnabled: true,
        submit: function () {
            debugger;
            this.set("submitEnabled", false);

            var data = kendo.stringify({
                Id: this.get("id"),
                CustomerId: this.get("customerId"),
                AddressId: this.get("addressId"),
                Name: this.get("name"),
                Phone: this.get("phone"),
                Email: this.get("email"),
                Franchise: this.get("franchise"),
                HeadQuarters: this.get("headQuarters"),

            });

            $.ajax({
                url: "/api/sites/",
                type: "PUT",
                dataType: "json",
                contentType: "application/json",
                data: data
            }).success(function (data, textStatus, jqXHR) {
                window.location.href = "/Management/Site/";
            }).fail(function (jqXHR, textStatus, errorThrown) {

            }).always(function () {
                viewModel.set("submitEnabled", true);
            });
        }
    });

    var id = $("input[name=\"Id\"]").val();

    $.ajax({
        url: "/api/sites/" + id,
        type: "GET",
        dataType: "json"
    }).success(function (data, textStatus, jqXHR) {
        debugger;
        viewModel.set("id", data.Id);
        viewModel.set("customerId", data.CustomerId);
        viewModel.set("addressId", data.AddressId);
        viewModel.set("name", data.Name);
        viewModel.set("phone", data.Phone);
        viewModel.set("email", data.Email);
        viewModel.set("franchise", data.Franchise);
        viewModel.set("headQuarters", data.HeadQuarters);

    }).fail(function (jqXHR, textStatus, errorThrown) {

    });

    $(function () {
        kendo.bind($("#site-form"), viewModel);

        var container = $("#site-form");

        container.find("input[name=\"CustomerId\"]").kendoDropDownList({
            dataSource: {
                transport: {
                    read: {
                        url: "/api/api/SiteCustomers",
                        type: "GET",
                        dataType: "json"
                    }
                }
            },
            dataValueField: "Id",
            dataTextField: "Description",
            optionLabel: "Select a Customer..."
        });

        container.find("input[name=\"AddressId\"]").kendoAutoComplete({
            dataSource: {
                transport: {
                    read: {
                        url: "/api/SiteAddresses",
                        type: "GET",
                        dataType: "json"
                    }
                }
            },
            dataValueField: "Id",
            dataTextField: "Street1",
            valueTemplate: "#= Street1 #, #= (data.Suburb.Name) ? Name : '' #",
            optionLabel: "Select a Address..."
        });

        //container.find("input[name=\"Start\"]").kendoDatePicker({
        //});

        //container.find("input[name=\"Finish\"]").kendoDatePicker({
        //});
    });
})();