(function () {
    var viewModel = new kendo.observable({
        id: 0,
        companyId: 0,
        name: 0,
        abn: 0,
        franchise: 0,
        phone: 0,
        email: 0,
        submitEnabled: true,
        submit: function () {
            this.set("submitEnabled", false);

            var data = kendo.stringify({
                Id: this.get("id"),
                CompanyId: this.get("companyId"),
                Name: this.get("name"),
                Abn: this.get("abn"),
                Franchise: this.get("franchise"),
                Phone: this.get("phone"),
                Email: this.get("email")
            });

            $.ajax({
                url: "/api/customers/",
                type: "PUT",
                dataType: "json",
                contentType: "application/json",
                data: data
            }).success(function (data, textStatus, jqXHR) {
                window.location.href = "/Management/Customers/";
            }).fail(function (jqXHR, textStatus, errorThrown) {

            }).always(function () {
                viewModel.set("submitEnabled", true);
            });
        }
    });

    $(function () {
        kendo.bind($("#customer-form"), viewModel);

        var container = $("#customer-form");

        container.find("input[name=\"CompanyId\"]").kendoDropDownList({
            dataSource: {
                transport: {
                    read: {
                        url: "/api/Companty/Company",
                        type: "GET",
                        dataType: "json"
                    }
                }
            },
            dataValueField: "Id",
            dataTextField: "Description",
            optionLabel: "Select a Company..."
        });

        
    });
})();