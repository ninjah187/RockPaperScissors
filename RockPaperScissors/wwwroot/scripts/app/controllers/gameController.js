rockPaperScissorsApp.controller('gameController', ['$scope', 'gameFactory', gameController]);

function gameController($scope, gameFactory) {
    $scope.game = gameFactory.currentGame;
}