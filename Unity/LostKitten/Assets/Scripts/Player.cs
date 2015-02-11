using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*Perspective --> naar waar hij kijkt (draait hoofdje naar up, down, right, left)
 * Move: eerst checken of het kan -> als het kan => bewegen
                                  -> als het niet kan => niks
 * Currentcolor: kleur van "blokje" waar hij opstaat*/


public class Player : Entity
{


  //constructor
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



  public BlockColor CurrentColor // we gaan de kleur van de block waar hij op staat kunnen opvragen en meegeven
  {
    get { return currentColor; }
    set { currentColor = value; }
  }



  //geen abstract meer voor de breedte en hoogte die onze player inneemt --> gaan nu !!eindelijk!! een waarde krijgen --> initialiseren, readonly want het gaat sowieso 8 zijn de waarde (gaan het niet kunnen veranderen)
  public override int Width //override omdat het in entity abstract is 
  {
    get { return 8; } //krijgt de waarde 8 mee 
  }



  public override int Height
  {
    get { return 8; } //krijgt de waarde 8 mee 
  }







  //methoden



  //als de kleuren overeen komen mag hij bewegen in de richting die hij wilt, als ze niet overeen komen gaat hij niks doen
  //heeft coordinaten overgekregen van entity die die heeft van object in scene (overerving), gaat nu gaan checken welke kleuren er "voor" de player liggen (halve block) en beslissen of hij daarop mag staan
  public void Move(Direction direction) 
  {

    //lokale variabelen
    Coordinates newPosition;
    int widthPlayerSpacePlusMoveSpace, heightPlayerSpacePlusMoveSpace; // int height staat er eigenlijk ook, zijn de hoogtes en breedtes van de ruimte die de player inneemt PLUS de ruimte (die 2 blockjes) waar hij naartoe gaat gaan

    newPosition = Position; //position property van entity om de oude positie weer te geven (kan ook met de set een nieuwe positie meegeven maar dat gaan we nu niet doen)
    widthPlayerSpacePlusMoveSpace = Width;   //properties van entity, hoeveel ruimte de player inneemt
    heightPlayerSpacePlusMoveSpace = Height;



    

    //hier gaan we een nieuw gebied selecteerbaar maken, namelijk de ruimte die de speler inneemt + de ruimte waar hij mogelijkst naartoe kan

    switch (direction) //Als de direction (parameter van de methode) gelijk is aan..
      {
        case Direction.Up://up gaat hij..
          heightPlayerSpacePlusMoveSpace += 1; //hoogte van ruimte die de speler inneemt + 1 blockje vanboven selecteren --> hoogte is dan bv 3 ipv. 2 (2 is dan Width, originele hoogte van ruimte die speler inneemt = de originele waarde van heightPlayerSpacePlusMoveSpace) (block waar player op staat --> 4 blockjes, 2 hoog, 2 breed)
          newPosition.YPosition -= 1; //veranderen de oude positie (altijd in de linkerbovenhoek van onze Block) -1 aangezien hoe hoger je in ons grid zit, hoe lager het getal van je positie bv 1tje naar boven --> van y positie 4 naar 3 bv. Positie van ons nieuw geselecteerd gebied ligt 1 tje hoger dan enkel de ruimte waar de speler zich bevind
          break;

        case Direction.Down://down gaat hij..
          heightPlayerSpacePlusMoveSpace += 1; //hoogte gaat hier ook 3 zijn want het is nu gwn de ruimte die de speler inneemt + 1 blockje vanonder
          //hier verandert je position niet, aangezien de positie nog altijd in de linkerbovenhoek zit van ons groot veld dat we nu beschikbaar stellen
          break;

        case Direction.Left:
          widthPlayerSpacePlusMoveSpace += 1; //breedte neemt ook met 1 toe, ruimte van player + 1 blockje aan de linkerkant
          newPosition.XPosition -= 1; //veranderen de oude positie -1 aangezien hoe meer naar links je in ons grid zit, hoe lager het getal van je positie bv 1tje naar links --> van x positie 4 naar 3 bv. Positie van ons nieuw geselecteerd gebied ligt 1 tje meer naar links dan enkel de ruimte waar de speler zich bevind
          break;
         
        case Direction.Right:
          widthPlayerSpacePlusMoveSpace += 1; //ruimte van player + 1 blockje aan de rechterkant
          break;

          //default niet nodig aangezien je enkel die 4 dingen kan hebben bij de enum direction
      }



    //nieuwe variabelen aanmaken 2d array van blocks --> met methode GetPartOfGrid van level gaan we van het deel dat we nu net geselecteerd hebben,ook echt een gridje op zich maken
    Block[,] gridPlayerSpaceMoveSpace = new Block[1,1]; //voorlopig random 1,1




    //Lijstje om alle kleuren die we uit ons gridje gaan halen gaan verzamelen
    List <BlockColor> listColors = new List<BlockColor>(); 
    

    //we gaan nu alle blockjes in ons nieuw gridje doorlopen (nog es, dat is het gebied waar de entity op staat EN waar hij naartoe wilt)
    for (int y = 0; y < gridPlayerSpaceMoveSpace.GetLength(1); y++) //y-coördinaten doorlopen, u y-coordinaat moet kleiner zijn dan hoe groot u gridje is in de hoogte
    {

      for (int x = 0; x < gridPlayerSpaceMoveSpace.GetLength(0); x++) //x-coördinaten doorlopen, u x-coordinaat moet kleiner zijn dan hoe groot u gridje is in de breedte
      {

        BlockColor colorOfBlock = gridPlayerSpaceMoveSpace[x, y].Color; //Color = property van Block, in nieuwe variabele gestoken om het korter te kunnen schrijven
        bool isAlreadyAdded = false;

        //foreach (var VARIABLE in COLLECTION)
        {
          
        }

      }

    }

    //if () {}    
    
    //(else {} als de kleuren niet overeen komen gaat hij gwn die kant niet uitkunnen, gebeurt er dus niks --> dus else is niet nodig)

  }//einde move


}//einde klasse
