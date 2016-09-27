rockPaperScissorsApp.service('navigationService', ['$location', navigationService]);

function navigationService($location) {
    this.goToNewGameCreation = function () {
        $location.path('newGame');
    };

    this.goToGameSearch = function () {
        $location.path('gameSearch');
    };

    this.goToCurrentGame = (function () {
        $location.path('game');
    });
}