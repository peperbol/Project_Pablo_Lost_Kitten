using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lever : Activatable {
                                            // alle objects in scene ( blocks, enities, levers) zijn een child van de parent gameobject 'world'
  public Lever(int xPosition, int yPosition, GameObject parent) // public: iedereen moet t kunnen aanspreken    De lever krijgt een x positie mee, een y positie, en gameobject parent 
    : base((GameObject) Resources.Load("Prefabs/Lever", typeof (GameObject)), xPosition, yPosition, parent)  // hier load je de afb voor de lever in
  {                                                     // parameter van rescources.Load, iets dat hij nodig heeft om de lever te kunnen laden

  }

  private bool IsActivated = false;   // variabele bool is activated aanmaken en op beginwaarde false zetten ==> dus nog niet geactiveerd/gebruikt



  public override int Width // override : omdat er in entity al een abstract staat dat we nu aan het overschrijven zijn
  {
    get { return 2; } // 2 = breedte
  }

  public override int Height
  {
    get { return 2; }  //2 = de hoogte
  }



              // var //name list
  private List<Block> area;  // aanmaken van een list van blocks -- hierin staan alle blokjes van u 1 kleur van waar je opstaat


  private bool IsInArea(Block blockToCheck) // methode om te kijken of u blokje al in de list zit. (als hij dezelfde kleur heeft)
  {
    foreach (Block block in area)
    {

      if (block == blockToCheck)    // als 
      {
        return true;  // zegt: u blokje zit er al in
      }

    }// einde foreach
    return false;
  } // einde IsInArea


  // aanmaken van scanForAdjacentBlocks  (focusblok = u main blokje waarrond je gaat kijken)
  private void ScanForAdjacentBlocks(Block focusBlock, BlockColor color)
  {
    if (focusBlock.Color == color // hier gaat hij nakijken of de focusblokje en u kleur hetzelfde zijn. Op een bepaald punt gaat dit niet meer zo zijn als je aan de rand komt
        && !IsInArea(focusBlock)  // volgende voorwaarde waaraan het moet voldoen (met parameters) 
      )
    {// begin if
      area.Add(focusBlock); // als hij inderdaad dezelfde kleur heeft dan mag hij in de list


      if (focusBlock.Coordinate.YPosition > 0) { 
        ScanForAdjacentBlocks(  // heeft 3 parameters (GameController/focusblock   , color   ,  area)
                         
                          GameController.CurrentLevel.GetPartOfGrid( // getPartOfGrid geeft een 2D array terug en heeft 2 parameters
                                      new Coordinates(focusBlock.Coordinate.XPosition, focusBlock.Coordinate.YPosition - 1),  //Linkerboven co-ordinaten  
                                      1, // breedte van array                              //Ypos - 1 = gaat in u grid 1 naar boven gaan. bv als hij p 12 staat --> 12-1=11
                                      1 // hoogte van array
                                )[0, 0],         // dit is de focusblock die linksboven in de array(van 1) staat                    
                          color
                          ); // block er boven
                // wanneer deze is afgelopen en alle bovenstaande blokken zitten in de lijst, gaan we verder naar hieronder
      }
      if (focusBlock.Coordinate.YPosition < GameController.CurrentLevel.Height - 1) { //checked of de focusblok niet op de onderste rij zit. je doet de hoogte van het actieve level -1 om de index van de onderste rij te bekomen
        // hier start je verder in de laatste focusblock
        ScanForAdjacentBlocks(  // heeft 3 parameters (GameController/focusblock   , color   ,  area)
                          GameController.CurrentLevel.GetPartOfGrid( // getPartOfGrid geeft een 2D array terug en heeft 2 parameters
                                      new Coordinates(focusBlock.Coordinate.XPosition, focusBlock.Coordinate.YPosition+1),
                                      1,                                                   //Ypos + 1 = gaat in u grid 1 naar onder gaan. bv als hij p 12 staat --> 12+1=13
                                      1
                               )[0, 0],         // dit is de focusblock die linksboven in de array(van 1) staat                                          
                          color
                          ); // block er onder
      }

      if (focusBlock.Coordinate.XPosition > 0) { 
        ScanForAdjacentBlocks(  // heeft 3 parameters (GameController/focusblock   , color   ,  area )
                          GameController.CurrentLevel.GetPartOfGrid( // getPartOfGrid geeft een 2D array terug en heeft 2 parameters
                                      new Coordinates(focusBlock.Coordinate.XPosition-1, focusBlock.Coordinate.YPosition),
                                      1,                                                //Xpos - 1 = gaat in u grid 1 naar links gaan. bv als hij p 12 staat --> 12-1=11
                                      1
                              )[0, 0],       // dit is de focusblock die linksboven in de array(van 1) staat                       
                          color
                          ); // block er links van
      }
      if (focusBlock.Coordinate.XPosition < GameController.CurrentLevel.Width - 1) { 
        ScanForAdjacentBlocks(   // heeft 3 parameters (GameController/focusblock   , color   ,  area)
                          GameController.CurrentLevel.GetPartOfGrid( // getPartOfGrid geeft een 2D array terug en heeft 2 parameters
                                      new Coordinates(focusBlock.Coordinate.XPosition+1, focusBlock.Coordinate.YPosition),
                                      1,                                                        //Xpos + 1 = gaat in u grid 1 naar rechts gaan. bv als hij p 12 staat --> 12+1=13
                                      1 
                              )   [0, 0],   // dit is de focusblock die linksboven in de array(van 1) staat                           
                          color
                          ); // block er rechts van
      }
    }// einde if
  } //  einde methode



  public override void Activate() // de abstracte die we bij activatable hebben gemaakt wordt hier nu aangemaakt
  {
    if (!IsActivated) // is niet geactiveerd --> is dus nog niet gebruikt, de lever moet nog gebruikt worden
    {
      area = new List<Block>();   // aanmaken van een list van blocks -- hierin staan alle blokjes van u 1 kleur van waar je opstaat

                   //    |  hieronder geeft een 2D array van blocks terug        | 
      BlockColor color = GameController.CurrentLevel.GetPartOfGrid(Position, 1, 1)[0, 0].Color;  // dit geeft de kleur van u blokje weer waar u lever op staat
      // (1,1) [0,0] er kan dus maar 1 ding in en we zetten 0,0 en daar nemen we de kleur van

  
      // je start op het blokje waar de lever op staat, en je moet alle blokjes van u kleur waar je opstaat (en waar de lever is) in u list krijgen
      ScanForAdjacentBlocks(GameController.CurrentLevel.GetPartOfGrid(Position, 1, 1)[0, 0], color);

      //nu zouden alle blockjes in de list moeten zitten


      foreach (Block block in area) // voor elke blok in de list area (waar alle blokjes in gezet worden die dezelfde kleur hebben) wordt het volgende uitgevoerd:
      {
        block.Color = ColorSpectrum.GetComplementColor(block.Color); // de kleur van de block(jes) wordt omgezet naar hun complementaire kleur
      }

      IsActivated = true;  // en op die manier zijn ze dan dus ook geactiveerd. 
    }
  }



}
