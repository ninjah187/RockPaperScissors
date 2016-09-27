rockPaperScissorsApp.controller('mainMenuController', ['$scope', 'navigationService', mainMenuController])

function mainMenuController($scope, navigationService) {
    $scope.navigation = navigationService;
}