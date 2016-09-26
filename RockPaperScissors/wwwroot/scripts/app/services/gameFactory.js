rockPaperScissorsApp.factory('gameFactory', ['$http', gameFactory]);

function gameFactory($http) {
    function getGames() {
        return $http.get('/api/games');
    }

    var service = {
        getGames: getGames
    };

    return service;
}
