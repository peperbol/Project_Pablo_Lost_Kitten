using UnityEngine;
using System.Collections;

public class Teleporter : Activatable
{

  private Coordinates destination;

  public Teleporter(int xPosition, int yPosition, GameObject parent, Coordinates destinationCoordinates)
    : base((GameObject)Resources.Load("Prefabs/BlackHole", typeof(GameObject)), xPosition, yPosition, parent)
  {
    destination = destinationCoordinates;
  }


  public override int Width // override : omdat er in entity al een abstract staat dat we nu aan het overschrijven zijn
  {
    get { return 6; } // 2 = breedte
  }

  public override int Height
  {
    get { return 6; }  //2 = de hoogte
  }

  public override void Activate()
  {
    GameController.PlayerInGame.Position = destination;
  }
}
