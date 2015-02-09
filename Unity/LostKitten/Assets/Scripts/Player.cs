using UnityEngine;
using System.Collections;


/*Perspective --> naar waar hij kijkt (draait hoofdje naar up, down, right, left)
 * Move: eerst checken of het kan -> als het kan => bewegen
                                  -> als het niet kan => niks
 * Currentcolor: kleur van "blokje" waar hij opstaat*/


public class Player : Entity
{

  public Player(int xPosition, int yPosition, GameObject parent)//we gaan dezelfde constructor gebruiken als die van entity maar andere waarden meegeven --> de prefab die we gaan gebruiken voor player ligt WEL vast (in entity is dat algemeen) die kunnen we dus wel al meegeven voor het nieuwe object "player" (die gaat die dus al vast hebben) --> daarom staat die hier niet meer tussen (enkel de dingen die je nog moet meegeven als je het object aanmaakt moeten hier staan)
    : base((GameObject)Resources.Load("Prefabs/Player", typeof(GameObject)), xPosition, yPosition, parent) //we gaan naar de Unity vaste klasse Resources --> daaruit gaan we een bestand laden in het script, we gaan naar de map Prefabs en nemen daar het bestand Player uit en het is een Gameobject, we gaan het geheel ook omzetten naar ene Gameobject aangezien als je iets laad op deze manier het een object gaat teruggeven en niet een GAMEobject
  {
    //neemt hierin over wat er in de constructor staat van entity
  }
  
  
  //private variabelen

  private Direction perspective; //de player gaat een richting uitkijken als waarde --> enum --> up, down, left of right
  private BlockColor currentColor; //De player gaat ook op een bepaalde blok staan met zijn kleur --> enum --> alle kleuren


  //properties
  public Direction Perspective //we gaan de richting kunnen opvragen en meegeven
  {
    get { return perspective; }
    set { perspective = value; }
  }


  public BlockColor CurrentColor // we gaan de kleur kunnen opvragen en meegeven
  {
    get { return currentColor; }
    set { currentColor = value; }
  }


  //geen abstract meer --> gaan nu !!eindelijk!! een waarde krijgen --> initialiseren, readonly want het gaat sowieso 8 zijn de waarde (gaan het niet kunnen veranderen)
  public override int Width //override omdat het in entity abstract is 
  {
    get { return 8; } //krijgt de waarde 8 mee 
  }



  public override int Height
  {
    get { return 8; } //krijgt de waarde 8 mee 
  }




  //methoden
  public void Move(Direction direction) //als de kleuren overeen komen mag hij bewegen in de richting die hij wilt, als ze niet overeen komen gaat hij niks doen
  {

    //if () {}    (else {} niks dus mag eigenlijk weg)

  }


}//einde klasse
