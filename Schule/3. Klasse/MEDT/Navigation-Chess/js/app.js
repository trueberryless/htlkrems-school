const cards = document.querySelectorAll('.card');

let hasFlippedCard = false;
let lockBoard = false;
let firstCard, secondCard;

function flipCard(){

    if(lockBoard) return;
    if(this === firstCard) return;

    this.classList.add('flip');

    if(!hasFlippedCard){
        //1. klick
        hasFlippedCard = true;
        firstCard = this;
        //2. klick
        return;
    } 
    secondCard= this;
    checkForMatch();
}

function checkForMatch(){
    let isMatch = firstCard.dataset.img === secondCard.dataset.img;
    isMatch ? disableCards() : unflipCards();    
}

function disableCards(){
    setTimeout(() => {
        firstCard.removeEventListener('click', flipCard);
        secondCard.removeEventListener('click', flipCard);
    }, 1500);
    setTimeout(() => {
        var links = new Array("https://lichess.org/", "https://www.youtube.com/user/RosenChess", "https://www.chess.com/", "https://lichess.org/team/friends281986", "https://lichess.org/study/3UK7vWYe", "https://lichess.org/tv");
        var randomNum = Math.floor(Math.random() * links.length);
        console.log(randomNum);
        open(links[randomNum]);        
    }, 1500);
    resetBoard();
}

function unflipCards(){

    lockBoard= true;

    setTimeout(() => {
        firstCard.classList.remove('flip');
        secondCard.classList.remove('flip');
        resetBoard();
    }, 1500);
}

function resetBoard(){
    [hasFlippedCard, lockBoard] = [false, false];
    [firstCard, secondCard] = [null,null];
}

(function shuffle(){
    cards.forEach(card =>{
        let randomPos = Math.floor(Math.random()*12);
        card.style.order = randomPos;
    });
})();

cards.forEach(card => card.addEventListener('click', flipCard));