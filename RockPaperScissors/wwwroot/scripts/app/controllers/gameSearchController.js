rockPaperScissorsApp.controller('gameSearchController', ['$scope', 'navigationService', 'gameFactory', gameSearchController]);

function gameSearchController($scope, navigationService, gameFactory) {
    $scope.search = function (gameId) {
        navigationService.goToGame(gameId);
        //gameFactory.searchGame(gameId)
        //    .success(function (gameData) {
                
        //    })
        //    .error(function (error) {
        //        console.log(error);
        //    });
    };
    $scope.$on('$viewContentLoaded', function () {
        focusElementModule.focus();
    });
}