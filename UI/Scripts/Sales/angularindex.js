var app = angular.module("SalesIndexApp", []);
app.controller("Fields", function ($scope) {
    $scope.StateId = 2;
    $scope.CustomerId = 4;

});

app.controller("ApiGet", function ($scope, $http) {
    $http.get("/api/saleLeads")
    .success(function (response) { $scope.leads = response.StateId; });
});