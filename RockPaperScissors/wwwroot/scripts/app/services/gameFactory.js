rockPaperScissorsApp.factory('gameFactory', ['$http', gameFactory]);

function gameFactory($http) {
    function getGame(gameId) {
        return $http.get('/api/games/' + gameId);
    }

    var service = {
        getGame: getGame
    };

    return service;
}