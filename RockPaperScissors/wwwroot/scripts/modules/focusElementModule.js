var focusElementModule = (function () {
    return {
        focus: function () {
            document.getElementsByClassName('focus-element')[0].focus();
        }
    };
})();