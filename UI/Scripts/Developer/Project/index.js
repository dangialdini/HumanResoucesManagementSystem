//(function () {
//    var projectDatasource = new kendo.data.DataSource({
//        transport: {
//            read: {
//                url: "/api/projectdevelopments/",
//                dataType: "json",
//                type: "GET"
//            }
//        },
//        schema: {
//            model: {
//                id: "Id",
//                fields: {
//                    Start: { type: "date" },
//                    Finish: { type: "date" }
//                }
//            }
//        }
//    });

//    $(function () {
//        $("#project-grid").kendoGrid({
//            dataSource: projectDatasource,
//            height: 550,
//            columns: [
//                {
//                    field: "Start",
//                    title: "Start",
//                    format: "{0:dd/MM/yyyy}"
//                },
//                {
//                    field: "Finish",
//                    title: "Finish",
//                    format: "{0:dd/MM/yyyy}"
//                },
//                {
//                    command: [{
//                        name: "edit", click: function (e) {
//                            e.preventDefault();
//                            // e.target is the DOM element representing the button
//                            var tr = $(e.target).closest("tr"); // get the current table row (tr)
//                            // get the data bound to the current table row
//                            var data = this.dataItem(tr);

//                            window.location.href = "/Development/ProjectManagement/Edit/" + data.get("Id");

//                        }
//                    },
//                    { name: "destroy" }], title: "&nbsp;", width: "250px"
//                }
//            ],
//            toolbar: [{ template: kendo.template($("#add-template").html()) }]
//        })
//    });
//})();

// Mini SPA JavaScript
(function () {
    // Data Sources
    var projectDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/projectdevelopments/",
                dataType: "json",
                type: "GET"
            },
            create: {
                url: "/api/projectdevelopments/",
                dataType: "json",
                contentType: "application/json",
                type: "POST"
            },
            update: {
                url: "/api/projectdevelopments/",
                dataType: "json",
                contentType: "application/json",
                type: "PUT"
            },
            destroy: {
                url: "/api/projectdevelopments/",
                dataType: "json",
                type: "DELETE"
            },
            parameterMap: function (data, type) {
                return kendo.stringify(data);
            }

        },
        schema: {
            model: {
                id: "Id",
                fields: {
                    Start: { type: "date" },
                    Finish: { type: "date" }
                }
            }
        }
    });

    var enhancementRequestDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/EnhancementRequest/EnhancementRequest",
                type: "GET",
                dataType: "json"
            }
        },
        schema: {
            model: {
                id: "Id"
            }
        }
    });

    var managerDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/api/Development/Employees",
                type: "GET",
                dataType: "json"
            }
        },
        schema: {
            model: {
                id: "Id"
            },
            parse: function (response) {
                var values = response,
                    n = values.length,
                    value;
                for (var i = 0; i < n; i++) {
                    value = values[i];
                    value.FullName = kendo.format("{0}, {1}",
                        value.LastName,
                        value.FirstName);
                }

                return response;
            }
        }
    });

    var taskDevelopmentDataSource = new kendo.data.DataSource({

    })

    // Configuration
    var projectGridOptions = {
        dataSource: projectDataSource,
        height: 550,
        columns: [
            {
                field: "Start",
                title: "Start",
                format: "{0:dd/MM/yyyy}"
            },
            {
                field: "Finish",
                title: "Finish",
                format: "{0:dd/MM/yyyy}"
            },
            {
                command: [{
                    name: "details",
                    text: "Details",
                    click: function (e) {
                        // e.target is the DOM element representing the button
                        var tr = $(e.target).closest("tr"); // get the current table row (tr)
                        // get the data bound to the current table row
                        var data = this.dataItem(tr);

                        project.navigate("/details/" + data.get("Id"));
                        e.preventDefault();
                    }
                },
                {
                    name: "edit", click: function (e) {
                        // e.target is the DOM element representing the button
                        var tr = $(e.target).closest("tr"); // get the current table row (tr)
                        // get the data bound to the current table row
                        var data = this.dataItem(tr);

                        project.navigate("/edit/" + data.get("Id"));
                        e.preventDefault();
                    }
                },
                { name: "destroy" }], title: "&nbsp;", width: "250px"
            }
        ],
        toolbar: [{ template: kendo.template($("#add-template").html()) }, { name: "excel" }],
        editable: {
            mode: "popup",
            update: false,
            confirmation: true
        }
    };

    // View Models
    var editViewModel = kendo.observable({
        manager: null,
        setCurrent: function (projectId) {
            var current = projectDataSource.get(projectId);
            this.set("current", current);
            managerDataSource.fetch(function (e) {
                editViewModel.setManager(current.get("ManagerId"));
            });
        },
        setManager: function (managerId) {
            this.set("manager", managerDataSource.get(managerId));
        },
        submitEnabled: true,
        submit: function () {
            if (editValidator.validate()) {
                this.set("submitEnabled", false);

                projectDataSource.sync().then(function () {
                    editViewModel.set("submitEnabled", true);
                    project.navigate("/");
                });
            };
        },
        setManagerId: function (managerId) {
                this.get("current").set("ManagerId", managerId);
        }
    });

    var detailViewModel = kendo.observable({
        setCurrent: function (projectId) {
            var data = projectDataSource.get(projectId)
            this.set("current", data);
            this.set("start", kendo.format("{0:D}", data.get("Start")));
            this.set("finish", kendo.format("{0:D}", data.get("Finish")));
        }
    })

    var createViewModel = new kendo.observable({
        init: function () {
            this.set("id", 0);
            this.set("enhancementRequestId", 0);
            this.set("managerId", 0);
            this.set("manager", null);
            this.set("start", new Date());
            this.set("finish", new Date());
        },
        submitEnabled: true,
        submit: function () {
            if (createValidator.validate()) {
                this.set("submitEnabled", false);

                projectDataSource.add({
                    EnhancementRequestId: this.get("enhancementRequestId"),
                    ManagerId: this.get("managerId"),
                    Start: this.get("start"),
                    Finish: this.get("finish")
                });

                projectDataSource.sync().then(function () {
                    createViewModel.set("submitEnabled", true);
                    project.navigate("/project/" + 3 + "/tasks/");
                });
            };
        },
        setManagerId: function (managerId) {
            this.set("managerId", managerId);
        }
    });

    var tasksViewModel = new kendo.observable({
        init: function (projectId) {
            this.set("id", 0);
            this.set("projectId", projectId);
            this.set("developerId", 0);
            this.set("description", "");
            this.set("start", new Date());
            this.set("finish", new Date());
        },
        tasks: taskDevelopmentDataSource,
        addTask: function () {
            taskDevelopmentDataSource.add({
                ProjectId: this.get("projectId"),
                DeveloperId: this.get("developerId"),
                Description: this.get("description"),
                Start: this.get("start"),
                Finish: this.get("finish")
            });

            // Here we would save the task to the server, but for now I'm leaving that bit

            this.init(this.get("projectId"));
        },
        deleteTask: function (e) {
            var task = taskDevelopmentDataSource.get(e.data.get("Id"));
            taskDevelopmentDataSource.remove(task);

            // Here is where we would sync the datasource with the server
        }
    })

    // Validators
    var createValidator;
    var editValidator;

    // Layouts
    var layout = new kendo.Layout("<section id='content'></section>");

    // Views
    var create = new kendo.View("create-template", {
        model: createViewModel,
        init: function () {
            var container = this.element.find("#create-form");
            createValidator = container.kendoValidator().data("kendoValidator");

            container.find("input[name=\"EnhancementRequestId\"]").kendoDropDownList({
                dataSource: enhancementRequestDataSource,
                dataValueField: "Id",
                dataTextField: "Description",
                optionLabel: "Select a Enhancement Request..."
            });

            container.find("input[name=\"ManagerId\"]").kendoAutoComplete({
                dataSource: managerDataSource,
                dataTextField: "FullName",
                change: function () {
                    var manager = createViewModel.get("manager");
                    if (manager === null) {
                        return;
                    }

                    if ($.type(manager) === "string") {
                        createViewModel.set("manager", null);
                    }
                    else {
                        createViewModel.setManagerId(manager.get("Id"));
                    }
                }
            });

            container.find("input[name=\"Start\"]").kendoDatePicker({
            });

            container.find("input[name=\"Finish\"]").kendoDatePicker({
            });
        },
        hide: function () {
            createValidator.hideMessages();
        }
    });

    var edit = new kendo.View("edit-template", {
        model: editViewModel,
        init: function () {
            var form = this.element.find("#edit-form");
            editValidator = form.kendoValidator().data("kendoValidator");

            this.element.find("input[name=\"EnhancementRequestId\"]").kendoDropDownList({
                dataSource: enhancementRequestDataSource,
                dataValueField: "Id",
                dataTextField: "Description",
                optionLabel: "Select a Enhancement Request..."
            });

            this.element.find("input[name=\"ManagerId\"]").kendoAutoComplete({
                dataSource: managerDataSource,
                dataTextField: "FullName",
                change: function () {
                    var manager = editViewModel.get("manager");
                    if (manager === null) {
                        return;
                    }

                    if ($.type(manager) === "string") {
                        editViewModel.set("manager", null);
                    }
                    else {
                        editViewModel.setManagerId(manager.get("Id"));
                    }
                }
            });

            this.element.find("input[name=\"Start\"]").kendoDatePicker({
            });

            this.element.find("input[name=\"Finish\"]").kendoDatePicker({
            });
        },
        hide: function () {
            editValidator.hideMessages();
        }
    });

    var detail = new kendo.View("detail-template", {
        model: detailViewModel
    });

    var index = new kendo.View("index-template", {
        init: function () {
            this.element.find("#index-grid").kendoGrid(projectGridOptions);
        }

    });

    var tasks = new kendo.View("task-template", {
        model: tasksViewModel,
        init: function () {
            this.element.find("input[name=\"DeveloperId\"]").kendoDropDownList();

            this.element.find("input[name=\"Start\"]").kendoDatePicker({
            });

            this.element.find("input[name=\"Finish\"]").kendoDatePicker({
            });
        }
    });

    // Initialize Router
    var project = new kendo.Router({
        init: function () {
            layout.render("#application");
        }
    });

    // Routing
    project.route("/", function () {
        layout.showIn("#content", index);

        
    });

    project.route("/create", function () {
        createViewModel.init();
        layout.showIn("#content", create);
    });

    project.route("/edit/:id", function (projectId) {
        projectDataSource.fetch(function (e) {
            if (editViewModel.get("current")) { // existing view, start transition, then update content. This is necessary for the correct view transition clone to be created.
                layout.showIn("#content", edit);
                editViewModel.setCurrent(projectId);
            } else {
                // update content first
                editViewModel.setCurrent(projectId);
                layout.showIn("#content", edit);
            }
        });
    });

    project.route("/details/:id", function (projectId) {
        projectDataSource.fetch(function (e) {
            if (detailViewModel.get("current")) { // existing view, start transition, then update content. This is necessary for the correct view transition clone to be created.
                layout.showIn("#content", detail);
                detailViewModel.setCurrent(projectId);
            } else {
                // update content first
                detailViewModel.setCurrent(projectId);
                layout.showIn("#content", detail);
            }
        });
    });

    project.route("/project/:id/tasks", function (projectId) {
        tasksViewModel.init(projectId);
        layout.showIn("#content", tasks);
    });

    $(function () {
        project.start();
    });
})();