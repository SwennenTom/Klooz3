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

function setCookie(name, value, days) {
    console.log("SetCookiefunction triggered")
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

function hideCookieConsent() {
    console.log("hideCookieConsent")
    var cookieConsentBanner = document.querySelector('.cookies-eu-banner');
    if (cookieConsentBanner) {
        cookieConsentBanner.style.display = 'none';
    }
}

function handleAcceptClick() {
    console.log("Ok! clicked")
    setCookie("cookieConsent", "accepted", 365); // Cookie will expire after 1 year
    hideCookieConsent();
}


function handleRefuseClick() {
    console.log("handlerefuseclicked triggered")
    setCookie("cookieConsent", "refused", 365); // Cookie will expire after 1 year
    hideCookieConsent();
}
