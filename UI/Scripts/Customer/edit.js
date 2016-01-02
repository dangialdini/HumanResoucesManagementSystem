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
            debugger;
            this.set("submitEnabled", false);

            var data = kendo.stringify({
                Id:         this.get("id"),
                CompanyId:  this.get("companyId"),
                Name:       this.get("name"),
                Abn:        this.get("abn"),
                Franchise:  this.get("franchise"),
                Phone:      this.get("phone"),
                Email:      this.get("email")
            });

            $.ajax({
                url: "/api/customer/",
                type: "PUT",
                dataType: "json",
                contentType: "application/json",
                data: data
            }).success(function (data, textStatus, jqXHR) {
                window.location.href = "/Management/Customer/";
            }).fail(function (jqXHR, textStatus, errorThrown) {

            }).always(function () {
                viewModel.set("submitEnabled", true);
            });
        }
    });

    var id = $("input[name=\"Id\"]").val();

    $.ajax({
        url: "/api/customers/" + id,
        type: "GET",
        dataType: "json"
    }).success(function (data, textStatus, jqXHR) {
        
        viewModel.set("id", data.Id);
        viewModel.set("companyId", data.CompanyId);
        viewModel.set("name", data.Name);
        viewModel.set("abn", data.Abn);
        viewModel.set("franchise", data.Franchise);
        viewModel.set("phone", data.Phone);
        viewModel.set("email", data.Email);
    }).fail(function (jqXHR, textStatus, errorThrown) {

    });

    $(function () {
        kendo.bind($("#customer-form"), viewModel);

        var container = $("#customer-form");

        container.find("input[name=\"CompanyId\"]").kendoDropDownList({
            dataSource: {
                transport: {
                    read: {
                        url: "/api/Company/Company",
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