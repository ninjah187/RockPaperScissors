rockPaperScissorsApp.controller('gamesController', ['$scope', 'gamesFactory', gamesController]);

function gamesController($scope, gamesFactory) {
    $scope.games = [];

    gamesFactory.getGames()
        .success(function (data) {
            $scope.games = data;
        })
        .error(function (error) {
            console.log(error);
        });
}