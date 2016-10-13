rockPaperScissorsApp.controller('gameController', ['$scope', '$routeParams', 'gameFactory', gameController]);

function gameController($scope, $routeParams, gameFactory) {
    $scope.game = {};
    $scope.joinGame = function () {

    };

    var gameId = $routeParams.gameId;
    var accessCode = $routeParams.accessCode;

    gameFactory.getGame(gameId, accessCode)
        .success(function (game) {
            $scope.game = game;
        })
        .error(function (error) {
            console.log(error);
        });
}