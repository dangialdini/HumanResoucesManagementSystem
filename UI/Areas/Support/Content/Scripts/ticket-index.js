$(function () {
    var ticketDataSource = new kendo.data.DataSource({
        type: "aspnetmvc-ajax",
        transport: {
            read: {
                url: "/api/SupportTicket",
                type: "GET",
                dataType: "json"
            },
            create: {
                url: "/api/SupportTicket",
                type: "POST",
                dataType: "json",
                success: function (data) {
                    $("#grid").data("kendoGrid").dataSource.read();
                    debugger;
                }
            },
            update: {
                url: "/api/SupportTicket",
                type: "PUT",
                dataType: "json"
            },
            destroy: {
                url: "/api/SupportTicket",
                type: "DELETE"
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }
        },
        serverPaging: true,
        schema: {
            data: "Data",
            total: "Total",
            errors: "Errors",
            model: {
                id: "Id",
                fields: {
                    Id: { editable: false, nullable: true, type: "number" },
                    Site: {
                        editable: true,
                        nullable: false,
                        defaultValue: { Id: 0, Name: "" }
                    },
                    TicketState: {
                        editable: true,
                        nullable: false,
                        defaultValue: { Id: 0, Name: "" }
                    },
                    Priority: {
                        editable: true,
                        nullable: false,
                        type: "number"
                    },
                    Timestamp: {
                        editable: true,
                        nullable: false,
                        type: "date"
                    },
                    Description: {
                        editable: true,
                        nullable: false,
                        type: "string"
                    }
                }
            }
        }
    });

    $("#grid").kendoGrid({
        dataSource: ticketDataSource,
        height: 600,
        groupable: true,
        sortable: true,
        resizable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        selectable: "multiple cell",
        allowCopy: true,
        toolbar: ["create", "pdf"],
        columns: [
            {
                field: "Timestamp",
                title: "Time and date created",
                format: "{0:yyyy-MM-dd, HH:mm}"
            },
            {
                field: "Site.Name",
                title: "Site",
                template: "#= Site.Name #",
                editor: siteDropDownEditor
            },
            {
                field: "TicketState.Name",
                title: "Ticket State",
                template: "#= TicketState.Name #",
                editor: ticketStateDropDownEditor
            },
            {
                field: "Priority",
                title: "Priority",
            },
            {
                field:
                  "Description",
                title: "Description"
            },
            {
                command:
                  ["edit", "destroy",
                  {
                      text: "Details",
                      click: showDetails
                  }],
                title: "Commands"
            }
        ],
        editable: {
            mode: "popup",
            confirmation: "Are you sure you want to delete this record?",
            template: kendo.template($("#popup-editor").html()),
            window: { draggable: true }
        },
        edit: function (e) {
            var siteInput = e.container.find("[Name=\"Site\"]");
            siteInput.kendoDropDownList({
                autoBind: false,
                optionLabel: { Id: 0, Name: "Please Select a Site" },
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/Sites",
                            type: "GET",
                            dataType: "json"
                        }
                    }
                }
            });

            var ticketStateInput = e.container.find("[Name=\"TicketState\"]");
            ticketStateInput.kendoDropDownList({
                autoBind: false,
                optionLabel: { Id: 0, Name: "Please Select a Ticket State" },
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/SupportTicketStates",
                            type: "GET",
                            dataType: "json"
                        }
                    }
                }
            });
        }
    });


    function siteDropDownEditor(container, options) {
        var field = options.field.replace('.Name', '');
        $('<input required data-text-field="Name" data-value-field="Id" data-bind="value: ' + field + '" />')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                //optionLabel: { Id: 0, Name: "Please Select a Site" },
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/Sites",
                            type: "GET",
                            dataType: "json"
                        }
                    },
                    schema: {
                        model: {
                            id: "Id"
                        }
                    }
                }
            });
    };

    function ticketStateDropDownEditor(container, options) {
        var field = options.field.replace(".Name", "");
        $('<input required data-text-field="Name" data-value-field="Id" data-bind="value: ' + field + '" />')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                dataSource: {
                    transport: {
                        read: {
                            url: "/api/SupportTicketStates",
                            type: "GET",
                            dataType: "json"
                        }
                    },
                    scehma: {
                        model: {
                            id: "Id"
                        }
                    }
                }
            });
    };

    //DETAILS MODAL WINDOW
    var wnd,
        detailsTemplate;
    wnd = $("#details").kendoWindow({
        title: "Ticket Details",
        modal: true,
        visible: false,
        resizabel: false,
        width: 400
    }).data("kendoWindow");
    detailsTemplate = kendo.template($("#template").html());

    function showDetails(e) {
        e.preventDefault();
        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        wnd.content(detailsTemplate(dataItem));
        wnd.center().open();
    };
});