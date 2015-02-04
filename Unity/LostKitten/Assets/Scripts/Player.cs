using UnityEngine;
using System.Collections;


/*Perspective --> naar waar hij kijkt (draait hoofdje naar up, down, right, left)
 * Move: eerst checken of het kan -> als het kan => bewegen
                                  -> als het niet kan => niks
 * Currentcolor: kleur van "blokje" waar hij opstaat*/


public class Player : Entity
{
  //private variabelen

  private Direction perspective;
  private BlockColor currentColor;


  //properties
  public Direction Perspective
  {
    get { return perspective; }
    set { perspective = value; }
  }


  public BlockColor CurrentColor
  {
    get { return currentColor; }
    set { currentColor = value; }
  }




  //methoden
  public void Move(Direction direction)
  {

    //if () {}    (else {} niks dus mag eigenlijk weg)

  }


}//einde klasse
