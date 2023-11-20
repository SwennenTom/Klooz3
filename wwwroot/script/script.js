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

// Add this script to your existing JavaScript file or include it in a separate file
document.addEventListener("DOMContentLoaded", function () {
    var footer = document.querySelector('.footer');

    function toggleFooter() {
        // Adjust the threshold as needed
        var threshold = window.innerHeight * 0.9;
        var isFooterVisible = window.innerHeight + window.scrollY >= document.body.offsetHeight - threshold;

        if (isFooterVisible) {
            footer.classList.add('show');
        } else {
            footer.classList.remove('show');
        }
    }

    // Initial check
    toggleFooter();

    // Listen for scroll events
    window.addEventListener('scroll', function () {
        toggleFooter();
    });
});
