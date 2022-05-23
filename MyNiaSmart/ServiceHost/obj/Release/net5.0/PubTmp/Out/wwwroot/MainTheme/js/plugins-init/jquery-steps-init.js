(function($) {
    "use strict"
    var form = $("#step-form-horizontal");
    form.children('div').steps({
        headerTag: "h4",
        bodyTag: "section",
        transitionEffect: "slideLeft",
        autoFocus: true, 
        transitionEffect: "slideLeft",
        onStepChanging: function (event, currentIndex, newIndex)
        {
            form.validate().settings.ignore = ":disabled,:hidden";
            return form.valid();
        }
        
    });
    //$("#issue").text($("#step-form-horizontal").children('div').children('h4').first().text());

})(jQuery);