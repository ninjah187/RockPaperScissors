rockPaperScissorsApp.controller('newGameController', ['$scope', 'navigationService', 'gameFactory', 'shapesFactory', newGameController]);

function newGameController($scope, navigationService, gameFactory, shapesFactory) {
    var player = {};
    var shapes = shapesFactory.shapes;
    var chosenShape = shapes[0];
    $scope.shapes = shapes;
    $scope.player = player;
    $scope.chosenShape = chosenShape;
    $scope.clearData = function () {
        player.name = '';
        chosenShape = shapes[0];
    };
    $scope.createNewGame = function (player, chosenShape) {
        gameFactory.createNewGame(player, chosenShape)
            .success(function (game) {
                navigationService.goToGame(game.Id);
            })
            .error(function (error) {
                console.log(error);
            });
    };

    $scope.clearData();
}