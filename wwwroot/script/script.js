function flipCard(card) {
  var allCards = document.querySelectorAll('.card.experimentcard');

  for (var i = 0; i < allCards.length; i++) {
    var currentCard = allCards[i];
    var cardFront = currentCard.querySelector('.card-front');
    var cardBack = currentCard.querySelector('.card-back');
    var isVisible = !cardFront.classList.contains('invisible');

    if (currentCard === card && isVisible) {
      cardFront.classList.add('invisible');
      cardBack.classList.remove('invisible');
    }
     else {
      cardFront.classList.remove('invisible');
      cardBack.classList.add('invisible');
    }
  }
}


/* Cookie*/
