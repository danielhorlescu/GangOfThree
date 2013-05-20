$(document).ready(function() {
    var validator = $('#body').kendoValidator().data('kendoValidator');
    $("input[type='submit']").click(function(e) {
        if (!validator.validate()) {
            e.preventDefault();
        }
    });
});