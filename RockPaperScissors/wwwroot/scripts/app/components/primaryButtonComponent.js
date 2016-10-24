rockPaperScissorsApp.component('primaryButton', {
    templateUrl: '/scripts/app/partials/primaryButton.html',
    controller: function () {
        this.text = 'primary button'
    },
    bindings: {
        text: '@'
    }
});