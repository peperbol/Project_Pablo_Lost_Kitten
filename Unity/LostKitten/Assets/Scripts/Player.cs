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
    Gamecontroller.PlayerInGame = this; // dit is de player van gamecontroller aangeven
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
    get { return 4; } //krijgt de waarde 8 mee 
  }



  public override int Height
  {
    get { return 4; } //krijgt de waarde 8 mee 
  }





  //methoden


  //als de kleuren overeen komen mag hij bewegen in de richting die hij wilt, als ze niet overeen komen gaat hij niks doen
  //heeft coordinaten overgekregen van entity die die heeft van object in scene (overerving), gaat nu gaan checken welke kleuren er "voor" de player liggen (halve block) en beslissen of hij daarop mag staan
  
  public void Move(Direction direction) 
  {

    //lokale variabelen
    Coordinates positionPlayerSpacePlusMoveSpace;
    int widthPlayerSpacePlusMoveSpace, heightPlayerSpacePlusMoveSpace; // int height staat er eigenlijk ook, zijn de hoogtes en breedtes van de ruimte die de player inneemt PLUS de ruimte (die 2 blockjes) waar hij naartoe gaat gaan

    //voorlopig hebben deze variabelen nog deze waardes, de oude positie, en de oude hoogte en breedte
    positionPlayerSpacePlusMoveSpace = Position; //position property van entity om de oude positie weer te geven (kan ook met de set een nieuwe positie meegeven maar dat gaan we nu niet doen)
    widthPlayerSpacePlusMoveSpace = Width;   //properties van entity, hoeveel ruimte de player inneemt
    heightPlayerSpacePlusMoveSpace = Height;


    

    //hier gaan we een nieuw gebied selecteerbaar maken, namelijk de ruimte die de speler inneemt EN de ruimte waar hij mogelijk naartoe kan

    switch (direction) //Als de direction (parameter die je meegeeft bij het oproepen van de methode) gelijk is aan..
      {
        case Direction.Up://up gaat hij..
          heightPlayerSpacePlusMoveSpace += 1; //hoogte van ruimte die de speler inneemt + 1 blockje vanboven selecteren --> hoogte is dan bv 3 ipv. 2 (2 is dan Width, originele hoogte van ruimte die speler inneemt = de originele waarde van heightPlayerSpacePlusMoveSpace) (block waar player op staat --> 4 blockjes, 2 hoog, 2 breed)
          positionPlayerSpacePlusMoveSpace.YPosition -= 1; //veranderen de oude positie (altijd in de linkerbovenhoek van onze Block) -1 aangezien hoe hoger je in ons grid zit, hoe lager het getal van je positie bv 1tje naar boven --> van y positie 4 naar 3 bv. Positie van ons nieuw geselecteerd gebied ligt 1 tje hoger dan enkel de ruimte waar de speler zich bevind
          break;

        case Direction.Down:
          heightPlayerSpacePlusMoveSpace += 1; //hoogte gaat hier ook 3 zijn want het is nu gwn de ruimte die de speler inneemt + 1 blockje vanonder
          //hier verandert je position niet, aangezien de positie nog altijd in de linkerbovenhoek zit van ons groot veld dat we nu beschikbaar stellen
          break;

        case Direction.Left:
          widthPlayerSpacePlusMoveSpace += 1; //breedte neemt ook met 1 toe, ruimte van player + 1 blockje aan de linkerkant
          positionPlayerSpacePlusMoveSpace.XPosition -= 1; //veranderen de oude positie -1 aangezien hoe meer naar links je in ons grid zit, hoe lager het getal van je positie bv 1tje naar links --> van x positie 4 naar 3 bv. Positie van ons nieuw geselecteerd gebied ligt 1 tje meer naar links dan enkel de ruimte waar de speler zich bevind
          break;
         
        case Direction.Right:
          widthPlayerSpacePlusMoveSpace += 1; //ruimte van player + 1 blockje aan de rechterkant
          break;

          //default niet nodig aangezien je enkel die 4 dingen kan hebben bij de enum direction
      }


    // 4 dingen checken: of hij vanboven, vanonder, links of rechts niet uit het grid valt (geen blockjes meer zijn, aan de rand van je grid zit)
    if (positionPlayerSpacePlusMoveSpace.YPosition < 0 || //vanboven uit grid
        positionPlayerSpacePlusMoveSpace.XPosition < 0 || //links uit grid
        positionPlayerSpacePlusMoveSpace.YPosition + heightPlayerSpacePlusMoveSpace -1 >= Gamecontroller.CurrentLevel.Height || //vanonder uit grid, positie plus hoogte van (bv positie 5 (y coordinaat) + 3 hoog = 8 - 1 (omdat je het deel van het grid waar je naar gaat moven ook meetelt) = 7 (eindigt op coördinaat 7, als je grid maar 7 blokjes hoog is (index 6 is het laatste mogelijke lijntje waar hij dan op mag staan) --> valt hij uit grid, mag niet  
        positionPlayerSpacePlusMoveSpace.XPosition + widthPlayerSpacePlusMoveSpace -1 >= Gamecontroller.CurrentLevel.Width) //rechts uit grid
    {
      
      
      return; //kheb een resultaat denkt hij, stopt met de methode move --> gaat niet moven 

    }


    //nieuwe variabelen aanmaken 2d array van blocks --> met methode GetPartOfGrid van level gaan we van het deel dat we nu net geselecteerd hebben,ook echt een gridje op zich maken
    Block[,] gridPlayerSpaceMoveSpace = Gamecontroller.CurrentLevel.GetPartOfGrid(positionPlayerSpacePlusMoveSpace,
                                                                                  widthPlayerSpacePlusMoveSpace, 
                                                                                  heightPlayerSpacePlusMoveSpace);


    //Lijstje om alle kleuren die we uit ons gridje gaan halen gaan verzamelen
    List <BlockColor> listColors = new List<BlockColor>(); 
    

   
    //we gaan nu alle blockjes in ons nieuw gridje doorlopen (nog es, dat is het gebied waar de entity op staat EN waar hij naartoe wilt)
    foreach (Block tempBlock in gridPlayerSpaceMoveSpace)
    {
      

        BlockColor colorOfBlock = tempBlock.Color; //De kleur van een bepaalde block (met coördinaten x en y) Color = property van Block, in nieuwe variabele gestoken om het korter te kunnen schrijven
        
        bool isAlreadyAdded = false; //voorlopig op false zetten 



        foreach (BlockColor tempVar in listColors) //listColors kunnen er al mogelijk kleuren inzitten, we willen niet 2 keer dezelfde kleur erin hebben zitten dus gaan nu checken welke kleuren er al in zitten in listColors
        {
          if (tempVar == colorOfBlock) //gaan alle kleuren die er al in zitten vergelijken met de kleur van ons blockje dat we aan het checken zijn
          {
            isAlreadyAdded = true; //als die eraan gelijk is (zit er al in dus en willen we niet nog een keer erin), dan zetten we deze op true
          }
          
        }//einde foreach



        if (!isAlreadyAdded)//enkel als het nog niet geadd is (er nog niet in zit) 
        {
          listColors.Add(colorOfBlock);// gaan we hem toevoegen aan de listColors lijst (in de lijst zitten dus de kleuren waar hij op staat en waar hij op wilt gaan staan) 
        
        }



    }//einde foreach






    if (listColors.Count == 1 ||  //als er maar 1 kleur in zit (de kleur waar hij op staat is hetzelfde als de kleur waar hij naartoe wilt)
      (listColors.Count == 2  &&  ColorSpectrum.IsAdjacent(listColors[0], listColors[1]))) //kleur waar hij op staat is anders dan de kleur waar hij naartoe wilt, gaat dan checken of ze adjacent zijn
    {
      

      //als die voorwaarden voldaan worden mag hij ook effectief zich gaan verplaatsen naar waar hij wilt  --> position aan gaan passen

      Coordinates newPosition = Position; //de momentele positie hier al in steken (voorlopig)

      switch (direction)
      {
        case Direction.Up:
          newPosition.YPosition -= 1; //positie gaat 1tje naar boven --> boven is -
          break;

        case Direction.Down:
          newPosition.YPosition += 1;
          break;

        case Direction.Left:
          newPosition.XPosition -= 1;//positie gaat 1tje naar links --> links is -
          break;
        
        case Direction.Right:
          newPosition.XPosition += 1;
          
          break;

      }//einde switch


      Position = newPosition; //nieuwe positie in de oude gestoken. (is vervangen nu)
     


    }//einde if voor de move te bepalen


  }//einde move







  public void CheckForActivables()// om de player een lever of slider te laten activeren (algemeen, om EEN activatable te activeren)
  {
    
    
    //gaan terug het gridje waar hij opstaat selecteren en overlopen om te zien of er een activatable op staat. Dan kunnen we die ook activeren. 
    Coordinates positionPlayerSpace = Position; //niet meer plus moveSpace nu want we gaan enkel de ruimte die hij inneemt checken.
    int widthPlayerSpace = Width;   //properties van entity, hoeveel ruimte de player inneemt
    int heightPlayerSpace = Height;



    //een nieuw gridje aanmaken voor de ruimte van de player
    Block[,] gridPlayerSpace = Gamecontroller.CurrentLevel.GetPartOfGrid(positionPlayerSpace,
                                                                                  widthPlayerSpace,
                                                                                  heightPlayerSpace);


    //we gaan nu het gridje doorlopen en gaan checken of er ergens een activatable in zit
    foreach (Block tempBlock in gridPlayerSpace)
    {

      /*if (tempBlock is Activatable) //als er een activatable op staat (als het blockje dat we NU aan het bekijken zijn een Activatable op zich heeft staan)
      {

        Acitvatable tempBlockActivatable = (Activatable) tempBlock; //De elementen in de 2D Array zijn van het type Block. Eens we zeker zijn dat we het hebben over een Activatable, moeten we die nog omzetten van een Block type naar een Activatable type. Anders kunnen we de Activatable niet activeren.
        tempBlock.Activate(); //Activeer de activatable. Dit gaat nu wel aangezien het een element van het juiste type is. Deze methode staat in de klasse Activate.
      
      }*/


    }//einde foreach



  }//einde CheckActivatables







}//einde klasse
