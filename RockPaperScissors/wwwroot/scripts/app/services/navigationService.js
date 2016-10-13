rockPaperScissorsApp.service('navigationService', ['$location', navigationService]);

function navigationService($location) {
    this.goToNewGameCreation = function () {
        $location.path('/newGame');
    };

    this.goToGameSearch = function () {
        $location.path('/gameSearch');
    };

    this.goToCurrentGame = (function () {
        $location.path('/game');
    });

    this.goToGame = function (gameId, accessCode) {
        var path = '/games/' + gameId;
        if (accessCode) {
            path += '/' + accessCode;
        }
        $location.path(path);
    };
}