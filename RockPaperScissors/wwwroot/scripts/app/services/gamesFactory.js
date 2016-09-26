rockPaperScissorsApp.factory('gamesFactory', ['$http', gamesFactory]);

function gamesFactory($http) {
    function getGames() {
        return $http.get('/api/games');
    }

    var service = {
        getGames: getGames
    };

    return service;
}
