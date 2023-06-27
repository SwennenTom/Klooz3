window.addEventListener('load', function() {
  var buttons = document.querySelectorAll('button');
  var delay = 100;
  var transitionTime = 250;

  for (var i = 0; i < buttons.length; i++) {
    (function(index) {
      setTimeout(function() {
        buttons[index].classList.add('green-button');
        setTimeout(function() {
          buttons[index].style.transition = "all " + transitionTime + "ms ease-in-out";
          buttons[index].classList.remove('green-button');
        }, delay);
      }, delay * index);

      buttons[index].addEventListener('click', function() {
          var topElement = document.getElementById("top");
          topElement.scrollIntoView({ behavior: "smooth" });
      });

    })(i);
  }
});

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