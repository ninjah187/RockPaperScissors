rockPaperScissorsApp.factory('shapesFactory', shapesFactory);

function shapesFactory() {
    var service = {
        shapes: [
            { name: 'rock',     value: 1, icon: 'fa fa-hand-rock-o' },
            { name: 'paper',    value: 2, icon: 'fa fa-hand-paper-o' },
            { name: 'scissors', value: 3, icon: 'fa fa-hand-scissors-o' },
        ]
    };

    return service;
}