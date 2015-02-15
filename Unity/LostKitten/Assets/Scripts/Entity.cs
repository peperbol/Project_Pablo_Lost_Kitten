using UnityEngine;
using System.Collections;


/*summary:
 * entity --> alles wat "op" het platform staat bv kat, deurtje,..
 * Als het katje collide met een andere entity bv wat er moet gebeuren.
 */


public abstract class Entity : ObjectInScene, BlockField{

  //constructor
  protected Entity(GameObject gameObject, int xPosition, int yPosition, GameObject parent)// gameobject --> prefab die je gebruikt voor de entity, positie waar de entity gaat staan, de parent bv world
    : base(gameObject, xPosition, yPosition, parent)//als je een nieuwe entity gaat aanmaken, ga je deze dingen meegeven tussen de haakjes
  {
    Position = Coordinate; //de coördinaten die ObjectInScene heeft aangemaakt --> nu al voorlopig in Position steken, positie kan nog verandert worden als je moved (dit is de startpositie)
  }



  //variabelen
  private EntityType typeOfEntity;//soort entity --> enum, keuze uit player, exit, slider, en lever
  private Block[,] grid; //komt van de interface Blockfield, erft er niet echt van over (is een interface, dat gaat niet) dus die moet hier terugkomen (code wordt niet automatisch hier al in "geplakt" zoals bij het overerven) 
                         //2dimensionaal gridje van zo 1 block waarop de entity staat (de ruimte die hij inneemt)


  //property
  public EntityType TypeOfEntity
  {
    get { return typeOfEntity; } //geef de waarde van de entity terug (bv player, exit,..)
    set { typeOfEntity = value; } // geef een nieuwe waarde (player, exit,..) aan de entity
  }



  public Block[,] Grid //read only property 
  {
    get { return grid; }
  }



  //abstract --> moet nog een waarde krijgen, dit zullen constanten worden (vandaar de hoofdletters), is voor een hoogte en breedte te geven aan de blokken die de entities gaan innemen, enkel get (const. kan je niet aanpassen --> vaste waarde) pepijn breekt mijn wereld --> propertie is NIET gelinkt aan een variabele maar aan een waarde, die je nu nog niet weet. (is versch. voor elke entity) 
  public abstract int Width
  {
    get;
  }



  public abstract int Height
  {
    get;
  }



  //de entity gaat zich verplaatsen en heeft dus een nieuwe positie, we werken via de property Coordinate uit ObjectInScene --> krijgt nieuwe coördinaten
  public Coordinates Position // van property naar property (Position, Coordinate)
  {

    get { return Coordinate; } //geef de waarde van de property Coordinate terug, zijn de coördinaten x en y


    set
    {
      Coordinate = value; //we geven de property Coordinate een nieuwe waarde (nieuwe plaats van de entity)

      Debug.Log("x: " + Coordinate.XPosition + " y: " + Coordinate.YPosition + " Width: " + Width + " Height: " + Height);

      //nieuwe grid maken met de methode GetPartOfGrid, met de nieuwe Coördinaten, de breedte en hoogte (als hij zich verplaatst heeft -> nieuwe positie, nieuw deeltje van grid waar we mee werken)
      Block[,] newBlocksGrid = Gamecontroller.CurrentLevel.GetPartOfGrid(Coordinate, Width, Height); 


      if (grid != null) //als er WEL al een grid is (deeltje van grid waar hij op staat) --> moeten die oude blockjes vergeten dat er een entity op staat
      {


        //oude blockjes vergeten dat er een entity op zich staat (staat er niet meer op) VOOR we het grid gaan vervangen
        foreach (Block tempOldBlockje in grid) //oude blockjes overlopen
        {

          bool leavesThisBlock = true;//al op true zetten voorlopig 


          foreach (Block tempNewBlockje in newBlocksGrid)// nieuwe blockjes doorlopen
          {

            if (tempOldBlockje == tempNewBlockje)//als oud blockje gelijk is aan nieuw blockje (zit dus al in nieuwe grid)
            {
              leavesThisBlock = false; //op false gezet --> niet nodig om die te verwijderen aangezien hij ook in het nieuwe grid mag
            }

          }//einde foreach nieuwe blockjes



          if (leavesThisBlock) //als hij niet gelijk is aan een blockje in de nieuwe grid --> hoort er dus niet te zijn in het nieuwe, moet verwijdert worden
          {
            tempOldBlockje.RemoveEntity(this); //de entity waar we het over hebben (klasse entity) verwijderen (is een oud blockje dat niet thuishoort in het nieuwe gridje van waar de entity zich gaat bevinden)
          }

      
        }//einde foreach oude blockjes

      } //einde if




      //nieuwe grid in variabele "grid" steken (vervangen van inhoud)
      grid = newBlocksGrid;


      //nieuwe blockjes (onderdeel van DE block waar hij op staat) leren dat er een entity op zich staat
      foreach (Block tempBlockje in grid) // nieuwe gridje doorlopen
      {
        tempBlockje.AddEntity(this); //de entity waar we het over hebben (klasse entity) aanleren aan de blockjes
      }
      
    } //einde set

  }//einde Position property






  //methoden

  //gaat overschreven worden door Exit, wat moet er gebeuren als de player in contact komt met een andere entity (ze overlappen dan, de player komt in zijn territorium)
  public virtual void CollideEnter(Entity entity) 
  {
    //hier moet er nog niks ingevuld worden, is te verschillend van entity tot entity, als er meer entities zouden zijn, zouden deze methodes vaker overschreven worden
  }


  //Wat moet er gebeuren als de player niet meer in contact is met de andere entity (de player beweegt en is uit zijn territorium)
  public virtual void CollideLeave(Entity entity)
  {

  }



}//einde klasse
