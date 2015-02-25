using UnityEngine;
using System.Collections;

public abstract class Activatable : Entity { // je moet het uitbreiden om er iets aan te hebben. Je gaat er geen object van maken


  protected Activatable(GameObject gameObject, int xPosition, int yPosition, GameObject parent) // hier geef je activatable parameters mee
    : base(gameObject, xPosition, yPosition, parent) // hier geeft hij de parameters rechtstreeks door aan entity
  {

  }

  public abstract void Activate();  // alles dat overerft van activatable gaat deze methode sowieso al overerven. Maar gaan er allemaal iets anders in doen.


}
