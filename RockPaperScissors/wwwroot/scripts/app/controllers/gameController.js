rockPaperScissorsApp.controller('gameController', ['$scope', '$routeParams', 'gameFactory', gameController]);

function gameController($scope, $routeParams, gameFactory) {
    $scope.game = {};

    var gameId = $routeParams.gameId;

    gameFactory.getGame(gameId)
        .success(function (data) {
            $scope.game = data;
        })
        .error(function (error) {
            console.log(error);
        });
}