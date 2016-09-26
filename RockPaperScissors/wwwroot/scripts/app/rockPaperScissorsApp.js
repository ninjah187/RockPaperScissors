var rockPaperScissorsApp = angular.module('rockPaperScissorsApp', ['ngRoute']);

rockPaperScissorsApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/scripts/app/partials/mainMenu.html',
                controller: 'mainMenuController'
            })
            .when('/newGame', {
                templateUrl: '/scripts/app/partials/newGame.html',
                controller: 'newGameController'
            })
            .when('/games', {
                templateUrl: '/scripts/app/partials/games.html',
                controller: 'gamesController'
            })
            .when('/games/:gameId', {
                templateUrl: '/scripts/app/partials/game.html',
                controller: 'gameController'
            })
            //.otherwise({
            //    templateUrl: '/scripts/app/partials/mainMenu.html',
            //    controller: 'mainMenuController'
            //});
    }
]);