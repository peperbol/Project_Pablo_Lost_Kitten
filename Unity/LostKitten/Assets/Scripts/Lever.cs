using UnityEngine;
using System.Collections;
using Boo.Lang;

public class Lever : Activatable {

  public Lever(int xPosition, int yPosition, GameObject parent) // public omdat iedereen het moet kunnen aanspreken
    : base((GameObject) Resources.Load("Prefabs/Lever", typeof (GameObject)), xPosition, yPosition, parent)
  {

  }

  private bool IsActivated = false;

  public override int Width // override : omdat er in entity al een abstract staat dat we nu aan het overschrijven zijn
  {
    get { return 4; } // 4 = breedte
  }

  public override int Height
  {
    get { return 4; }  //4 = de hoogte
  }



  private bool IsInArea(Block blockToCheck, List<Block> area) // methode om te kijken of u blokje al in de list zit. (als hij dezelfde kleur heeft)
  {
    foreach (Block block in area)
    {

      if (block == blockToCheck)
      {
        return true;  // zegt: u blokje zit er al in
      }

    }// einde foreach
    return false;
  } // einde IsInArea


  // aanmaken van scanForAdjacentBlocks  (focusblok = u main blokje waarrond je gaat kijken)
  private void ScanForAdjacentBlocks(Block focusBlock, BlockColor color, List<Block> area)
  {
    if (focusBlock.Color == color // hier gaat hij nakijken of de focusblokje en u kleur hetzelfde zijn. Op een bepaald punt gaat dit niet meer zo zijn als je aan de rand komt
        && !IsInArea(focusBlock, area)  // volgende voorwaarde waaraan het moet voldoen (met parameters) 
      )
    {// begin if
      area.Add(focusBlock); // als hij inderdaad dezelfde kleur heeft dan mag hij in de list



      ScanForAdjacentBlocks(
                          Gamecontroller.CurrentLevel.GetPartOfGrid(
                                      new Coordinates(focusBlock.Coordinate.XPosition, focusBlock.Coordinate.YPosition-1),
                                      1,1 )   [0, 0],                                                       //Ypos - 1 = gaat in u grid 1 naar boven gaan. bv als hij p 12 staat --> 12-1=11
                          color, 
                          area
                          ); // 
  
  }


  public override void Activate() // de abstracte die we bij activatable hebben gemaakt wordt hier nu aangemaakt
  {
    if (!IsActivated)
    {
      List<Block> area = new List<Block>();   // aanmaken van een list van blocks -- hierin staan alle blokjes van u 1 kleur van waar je opstaat

                   //    |  hieronder geeft een 2D array van blocks terug        | 
      BlockColor color = Gamecontroller.CurrentLevel.GetPartOfGrid(Position, 1, 1)[0, 0].Color;  // dit geeft de kleur van u blokje weer waar u lever op staat
      // (1,1) [0,0] er kan dus maar 1 ding in en we zetten 0,0 en daar nemen we de kleur van

  
      // je start op het blokje waar de lever op staat, en je moet alle blokjes van u kleur waar je opstaat (en waar de lever is) in u list krijgen
      // 
      ScanForAdjacentBlocks(Gamecontroller.CurrentLevel.GetPartOfGrid(Position, 1, 1)[0, 0], color, area);

      IsActivated = true;
    }
  }


}
