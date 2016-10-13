rockPaperScissorsApp.factory('gameFactory', ['$http', gameFactory]);

function gameFactory($http) {
    function getGame(gameId) {
        return $http.get('/api/games/' + gameId);
    }

    function getGame(gameId, accessCode) {
        var resource = '/api/games/' + gameId;
        if (accessCode) {
            resource += '/' + accessCode;
        }
        return $http.get(resource);
    }

    function createNewGame(player, chosenShape) {
        var data = {
            playerName: player.name,
            chosenShape: chosenShape.value
        };

        return $http.post('/api/newGame', {
            playerName: player.name,
            chosenShape: chosenShape.value
        });
    }

    function searchGame(gameSearch) {
        return $http.post('/api/gameSearch', gameSearch);
    }

    var service = {
        getGame: getGame,
        createNewGame: createNewGame,
        searchGame: searchGame,
        currentGame: {}
    };

    return service;
}