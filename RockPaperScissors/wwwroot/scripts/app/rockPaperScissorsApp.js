var rockPaperScissorsApp = angular.module('rockPaperScissorsApp', ['ngRoute']);

rockPaperScissorsApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider
            .when('/games', {
                templateUrl: '/scripts/app/partials/games.html',
                controller: 'gamesController'
            })
            .when('/games/:gameId', {
                templateUrl: '/scripts/app/partials/game.html',
                controller: 'gameController'
            });
    }
]);