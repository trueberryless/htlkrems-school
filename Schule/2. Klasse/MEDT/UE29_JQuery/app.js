$(document).ready(function() {

    $("#b1").click(function() {
        $("#d1").slideToggle();
    })

    $("#b2").click(function() {
        $("#d1").animate({height: '15vw'}, "slow");
        $("#d1").animate({width: '80vw'}, "slow");
        $("#d1").animate({height: '5vw'}, "slow");
        $("#d1").animate({width: '30vw'}, "slow");
    })

    $("#b1").dblclick(function() {
        $("#d1").animate({left: '500px'});
        $("#d1").animate({top: '500px'});
        $("#d1").animate({left: '0'});
        $("#d1").animate({top: '0'});
    })
})