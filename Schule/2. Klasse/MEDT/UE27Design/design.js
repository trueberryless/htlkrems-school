debugger;
var count = 0;
var wait = 4000; // ms
var slides ;
var simpleSlides;

function Init() {
    slides = document.querySelectorAll(".slides");
    simpleSlides = function() {
        for(var i = 0; i < slides.length; i++){
            slides[i].setAttribute("style", "display: none");
        }
        slides[count].setAttribute("style", "display: block");
        count++;
        if(count >= slides.length){
            count = 0;
        }
        setTimeout(simpleSlides, wait);
    }

    simpleSlides();
}