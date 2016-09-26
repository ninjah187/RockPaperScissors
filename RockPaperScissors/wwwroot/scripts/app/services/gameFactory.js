rockPaperScissorsApp.factory('gameFactory', ['$http', gameFactory]);

function gameFactory($http) {
    function getGame(gameId) {
        return $http.get('/api/games/' + gameId);
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

    var service = {
        getGame: getGame,
        createNewGame: createNewGame
    };

    return service;
}