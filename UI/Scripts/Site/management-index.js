//Management - SITE - Index

$(document).ready(function () {
	alert("This Area is For Managers Only");
		
	//alert("hello from Management-site-index");
	var siteDataSource = new kendo.data.DataSource({

		transport: {

			read:           { url: "/api/sites/Get", type: "get", dataType: "json" },
			create:         { url: "/api/sites/Post", type: "post", dataType: "json", contentType: "application/json" },
			update:         { url: "/api/sites/Update", type: "put", dataType: "json", contentType: "application/json" },
			destroy:        { url: "/api/sites/Delete", type: "delete", contentType: "application/json" },
			createaddress:  { url: "/api/address/Index" },
			parameterMap: function (data, type) {
				return kendo.stringify(data);
			}
		},

		pageSize: 20,
		schema: {
			model: {
				id: "siteId",
				fields: {
					siteId: { from: "Id", type: "number" },
					//We also need to update the model to receive this new template Value
					customerId:     { from: "CustomerId", type: "number", validation: { required: true, min: 1 } },
					customerName:   { from: "CustomerName", validation: { required: true } },
					addressId:      { from: "AddressId", type: "number", validation: { required : true, min: 1} },
					addressName:    { from: "AddressName", validation: { required: true } },
					streetAddress : { from: "StreetAddress" },
					suburb:         { from: "Suburb" },
					state:          { from: "State"},
					name:           { from: "Name", type: "string", validation: { required: true } },
					phone:          { from: "Phone", validation: { required: true } },
					email:          { from: "Email", type: "email", validation: { required: true } },
					franchise:      { from: "Franchise", type: "boolean" },
					headquarters:   { from: "HeadQuarters", type: "boolean" },
				}
			}
		}
	});

	$("#management-site-grid").kendoGrid({
		dataSource: siteDataSource,
		height: 600,
		filterable: { mode: "row" },
		//groupable: true,
		//sortable: true,
		pageable: true,
		toolbar: [{ name: "create", text: "Register New Site" }, { name: "createaddress" , text: "Register New Address"}, "excel", "pdf"],
		columns: [
		 //{ field: "Id", title: "Site Id",width: 120 },
		 { field: "addressName", title: "Address", width: 120 },
		 //we declare a customer template for all fields
		 { field: "customerName", title: "Customer", width: 120 },
		 { field: "name", title: "Name", width: 200 },
		 { field: "phone", title: "Phone", width: 200 },
		 { field: "email", title: "Email", width: 240 },
		 { field: "franchise", title: "Franchise", width: 140 },
		 { field: "headquarters", title: "HeadQuarters", width: 140 },

		 { command: ["edit", "delete", { text: "Show on Map", click: showDetails }], title: "&nbsp;" }
		],

	   


		//we pass the template to the editor
		editable: {
			mode: "popup",
			template: kendo.template($("#site-popup-editor").html()), window: { draggable: true }
		},

		edit: function (e) {

			var model = e.model;

			var customerInput = e.container.find("input[name=\"Customer\"]");

			customerInput.kendoDropDownList({
				autoBind: false,
				dataSource: {
					transport: {
						read: { url: "/api/SiteCustomers/", dataType: "json", type: "get" }
					}
				},
				change: function (e) {
					model.set("customerId", 1);
				}
			});

			//var model = e.model;

			//var addressInput = e.container.find("input[name=\"Address\"]");

			//addressInput.kendoDropDownList({
			//	autoBind: false,
			//	dataSource: {
			//		transport: {
			//			read: { url: "/api/SiteAddresses/", dataType: "json", type: "get" }
			//		}
			//	},
			//	change: function (e) {
			//		model.set("addressId", 1);
			//	}

			//});

			// Here we are accessing the container field on the event arguments.  The container is the jQuery object that contains the HTML of our form.
			// Using the find method, we can find an element (or elements) inside our edit form.  Here we are finding the input element that has a name attribute
			// value of Address.  This is the element we want to set as an auto complete,
			var addressInput = e.container.find("input[name=\"addressId\"]");

			addressInput.kendoDropDownList({
				dataSource: {
							transport: {
								read: { url: "/api/SiteAddresses/", dataType: "json", type: "get" }
							}
						},
				filter: "contains",
				dataTextField: "Street1",
				dataValueField: "Id",
				valueTemplate: "#= Street1 #  #= Suburb #, #= Postcode # #= State #",
				//placeholder: "Select address or create new...",
				//separator: ", ",
				change: function (e) {
					var dataItem = e.sender.dataItem();

					model.set("streetAddress", dataItem.get("Street1"));
					model.set("suburb", dataItem.get("Suburb"));
					model.set("postcode" , dataItem.get("Postcode"));
					model.set("state", dataItem.get("State"));
				}
			});

			}
			
	});

	function createMap() {
		$("#site-map").kendoMap({
			center: [-33.867486, 151.206990],
			zoom: 15,
			layers: [{
				type: "tile",
				urlTemplate: "http://#= subdomain #.tile2.opencyclemap.org/transport/#= zoom #/#= x #/#= y #.png",
				subdomains: ["a", "b", "c"],
				attribution: "&copy; <a href='http://osm.org/copyright'>OpenStreetMap contributors</a>." +
							 "Tiles courtesy of <a href='http://www.opencyclemap.org/'>Andy Allan</a>"
			}, {
				type: "marker",
				dataSource: {
					transport: {
					    read: { url: "/api/sites/GetLocation", type: "get", dataType: "json" }
					}
				},
				locationField: "latlng",
				titleField: "name"
			}]
		});
	}

	$(document).ready(createMap);

});

//we pass the details 
//detailsTemplate;
//var wnd,
//		wnd = $("#sitedetails")
//				.kendoWindow({
//					title: "Site Details",
//					modal: true,
//					visible: false,
//					resizable: false,
//					width: 300
//				}).data("kendoWindow");

//detailsTemplate = kendo.template($("#sitetemplate").html());


//function showDetails(e) {
//	e.preventDefault();

//	var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
//	wnd.content(detailsTemplate(dataItem));
//	wnd.center().open();
//}



