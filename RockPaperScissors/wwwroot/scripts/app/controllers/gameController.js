rockPaperScissorsApp.controller('gameController', ['$scope', 'gameFactory', gameController]);

function gameController($scope, gameFactory) {
    $scope.games = [];

    gameFactory.getGames().success(function (data) {
        $scope.games = data;
    }).error(function (error) {
        console.log(error);
    });
}