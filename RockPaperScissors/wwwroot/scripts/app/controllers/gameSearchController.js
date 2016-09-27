rockPaperScissorsApp.controller('gameSearchController', ['$scope', 'navigationService', 'gameFactory', searchGameController]);

function searchGameController($scope, navigationService, gameFactory) {
    $scope.gameSearch = {};
    $scope.search = function (gameSearch) {
        gameFactory.searchGame(gameSearch)
            .success(function (gameData) {
                gameFactory.currentGame = gameData;
                navigationService.goToCurrentGame();
            })
            .error(function (error) {
                console.log(error);
            });
    };
}