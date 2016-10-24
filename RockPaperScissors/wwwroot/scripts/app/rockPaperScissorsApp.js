var rockPaperScissorsApp = angular.module('rockPaperScissorsApp', ['ngRoute']);

rockPaperScissorsApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/scripts/app/partials/mainMenu.html',
                controller: 'mainMenuController'
            })
            .when('/gameSearch', {
                templateUrl: '/scripts/app/partials/gameSearch.html',
                controller: 'gameSearchController'
            })
            .when('/newGame', {
                templateUrl: '/scripts/app/partials/newGame.html',
                controller: 'newGameController'
            })
            .when('/games/:gameId', {
                templateUrl: '/scripts/app/partials/game.html',
                controller: 'gameController'
            })
            .when('/games/:gameId/:accessCode', {
                templateUrl: '/scripts/app/partials/game.html',
                controller: 'gameController'
            });
            //.when('/game', {
            //    templateUrl: '/scripts/app/partials/game.html',
            //    controller: 'gameController'
            //})
            //.when('/games/:gameId', {
            //    templateUrl: '/scripts/app/partials/game.html',
            //    controller: 'gameController'
            //})
            //.otherwise({
            //    templateUrl: '/scripts/app/partials/mainMenu.html',
            //    controller: 'mainMenuController'
            //});
    }
]);