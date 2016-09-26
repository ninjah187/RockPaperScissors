rockPaperScissorsApp.factory('shapesFactory', shapesFactory);

function shapesFactory() {
    var service = {
        shapes: [
            { name: 'rock',     value: 1 },
            { name: 'paper',    value: 2 },
            { name: 'scissors', value: 3 },
        ]
    };

    return service;
}