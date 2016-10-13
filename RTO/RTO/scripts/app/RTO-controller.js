angular.module('RTOApp', [])
    .controller('RTOCtrl', function ($scope, $http) {
        $scope.answered = false;
        $scope.title = "RTO";
        $scope.options = [];
        $scope.correctAnswer = false;
        $scope.working = false;

        $http.get("/api/trivia").success(function (data, status, headers, config) {
            $scope.options = data.options;
            $scope.title = data.title;
            $scope.answered = false;
            $scope.working = false;
        }).error(function (data, status, headers, config) {
            $scope.title = "Oops... something went wrong";
            $scope.working = false;
        });
    });