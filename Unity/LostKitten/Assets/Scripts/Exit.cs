using UnityEngine;
using System.Collections;


/*summary:
 * Waar level eindigt, waar je naartoe moet als Pablo.
Een override van de CollideEnter van de superklasse entity
 */


public class Exit : Entity {


  //constructor
  public Exit(int xPosition, int yPosition, GameObject parent)
    : base((GameObject)Resources.Load("Prefabs/Exit", typeof(GameObject)), xPosition, yPosition, parent) //zelfde maar we gaan bij exit de prefab Exit gaan zoeken en laden
  {
    //neemt hierin over wat er in de constructor staat van entity
  }
  
  
  
  //properties
  public override int Width
  {
    get { return 8; } //krijgt de waarde 8 mee (toevallig hetzelfde als player maar we kunnen die een andere waarde mee geven ook)
  }



  public override int Height
  {
    get { return 8; } //krijgt de waarde 8 mee 
  }


  
  //methodes
  //wat moet er gebeuren als de player in contact komt met de deur --> over gaan naar het scherm met het overzicht van de levels op
  public override void CollideEnter(EntityType entity)
  {

  }


}//einde klasse
