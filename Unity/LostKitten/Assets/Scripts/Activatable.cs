using UnityEngine;
using System.Collections;

public abstract class Activatable : Entity { // je moet het uitbreiden om er iets aan te hebben.          abstract, Je gaat er geen object van maken

  // constructor die alles doorgeeft naar entity 
  protected Activatable(GameObject gameObject, int xPosition, int yPosition, GameObject parent) // hier geef je de methode activatable parameters mee
    : base(gameObject, xPosition, yPosition, parent) // hier geeft hij de parameters rechtstreeks door aan entity
  {   // :base gaat u parameters van de methode van u superklasse gebruiken. indien niets veranderd, mag je gewoon dubbelschrijven. anders mag je die aanpassen, maar dan wel hier boven niet laten staan. bv als je x positie = 3 zou willen maken vast

  }

  // abstracte methode
  public abstract void Activate();  // alles dat overerft van activatable gaat deze methode sowieso al overerven. Maar gaan er allemaal iets anders in doen.


}
