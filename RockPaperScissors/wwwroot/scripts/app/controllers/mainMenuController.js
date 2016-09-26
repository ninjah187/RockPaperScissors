rockPaperScissorsApp.controller('mainMenuController', ['$scope', 'navigationService', mainMenuController])

function mainMenuController($scope, navigationService) {
    $scope.goToNewGameCreation = function () {
        navigationService.goToNewGameCreation();
    };
}