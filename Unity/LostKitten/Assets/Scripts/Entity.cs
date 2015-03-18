using UnityEngine;
using System.Collections;


/*summary:
 * entity --> alles wat "op" het platform staat bv kat, deurtje,..
 * Als het katje collide met een andere entity bv wat er moet gebeuren.
 */


public abstract class Entity : ObjectInScene, BlockField{

  //constructor
  //protected omdat het een abstracte klasse is --> geen object hiervan aanmaken dus public is niet nodig (mag wel) private gaat ook niet natuurlijk want je hebt hem wel nodig in je subklasses
  protected Entity(GameObject gameObject, int xPosition, int yPosition, GameObject parent)// gameobject --> prefab die je gebruikt voor de entity, positie waar de entity gaat staan, de parent bv world
    : base(gameObject, xPosition, yPosition, parent)//als je een nieuwe entity gaat aanmaken, ga je deze dingen meegeven tussen de haakjes
  {
    Position = Coordinate; //de coördinaten die ObjectInScene heeft aangemaakt --> in Position steken --> is de startpositie. Als je moved --> positie verandert 
  }



  //variabelen
  private EntityType typeOfEntity;//soort entity --> enum, keuze uit player, exit, slider, en lever
  private Block[,] grid; //2dimensionaal gridje waarop de entity staat (de ruimte die hij inneemt)
                         //komt van de interface Blockfield, erft er niet echt van over (is een interface, dat gaat niet) dus die moet hier terugkomen (code wordt niet automatisch hier al in "geplakt" zoals bij het overerven) 
                         


  //property
  public EntityType TypeOfEntity
  {
    get { return typeOfEntity; } //geef de waarde van de entity terug (bv player, exit,..)
    set { typeOfEntity = value; } // geef een nieuwe waarde (player, exit,..) aan de entity
  }



  public Block[,] Grid //read only property, grid waar hij opstaat teruggeven 
  {
    get { return grid; }
  }



  //abstract --> moet nog een waarde krijgen, is voor een hoogte en breedte te geven aan de blokken die de entities gaan innemen, enkel get is versch. voor elke entity
  public abstract int Width
  {
    get;
  }



  public abstract int Height
  {
    get;
  }



  
  public Coordinates Position // van property naar property (Position, Coordinate)
  {

    get { return Coordinate; } //geef de waarde van de property Coordinate terug, zijn de coördinaten x en y



    //de entity gaat zich verplaatsen en heeft dus een nieuwe positie, we werken via de property Coordinate uit ObjectInScene --> krijgt nieuwe coördinaten
    set
    {

      
      Coordinate = value; //we geven de property Coordinate een nieuwe waarde (nieuwe plaats van de entity)


      //nieuwe grid maken met de methode GetPartOfGrid, met de nieuwe Coördinaten, de breedte en hoogte (als hij zich verplaatst heeft -> nieuwe positie, nieuw deeltje van grid waar we mee werken)
      Block[,] newBlocksGrid = GameController.CurrentLevel.GetPartOfGrid(Coordinate, Width, Height); 


      if (grid != null) //als er WEL al een grid is (deeltje van grid waar hij op staat) --> moeten die oude blockjes vergeten dat er een entity op staat. Als we net een object van entity aanmaken (via de constructor van entity) heeft die nog zo geen grid. Dan slaat die dit deel over, want dit deel is eigenlijk voor bv als hij gaat moven dat zijn oude grid vergeet da hij erop staat (want hij staat er niet meer op) en dat het nieuwe grid leert dat hij erop staat.
      {

        //oude blockjes vergeten dat er een entity op zich staat (staat er niet meer op) VOOR we het grid gaan vervangen (anders werken we met het nieuwe grid voor dit en dat willen we niet)
        
        
        //we gaan checken of er blockjes zijn in het oude grid die exact op die plaats mogen blijven staan voor het nieuwe grid (moeten die niet verwijderen)
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
            tempOldBlockje.RemoveEntity(this); //de entity waar we het over hebben (klasse entity) verwijderen
          }

      
        }//einde foreach oude blockjes

      } //einde if




      //nieuwe grid in variabele "grid" steken (vervangen van inhoud)
      grid = newBlocksGrid;


      //nieuwe blockjes leren dat er een entity op zich staat
      foreach (Block tempBlockje in grid) // nieuwe gridje doorlopen
      {
        tempBlockje.AddEntity(this); //de entity waar we het over hebben (klasse entity) aanleren aan de blockjes
      }
      
    } //einde set

  }//einde Position property






  //METHODEN

  //gaat overschreven worden door Exit
  //wat moet er gebeuren als de player in contact komt met een andere entity (ze overlappen dan, de player komt in zijn territorium)
  public virtual void CollideEnter(Entity entity) 
  {
    //hier moet er nog niks ingevuld worden, is te verschillend van entity tot entity, als er meer entities zouden zijn, zouden deze methodes vaker overschreven worden
  }


  //Wat moet er gebeuren als de player niet meer in contact is met de andere entity (de player beweegt en is uit zijn territorium)
  public virtual void CollideLeave(Entity entity)
  {

  }



}//einde klasse
