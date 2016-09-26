rockPaperScissorsApp.service('navigationService', ['$location', navigationService]);

function navigationService($location) {
    this.goToNewGameCreation = function () {
        $location.path('newGame');
    };

    this.goToGame = function (gameId) {
        $location.path('games/' + gameId);
    };
}