using UnityEngine;
using System.Collections;

public abstract class ObjectInScene {

  //fields
  private Coordinates coordinate;
  protected GameObject gameObject;

  //property
  public Coordinates Coordinate
  {
    get { return coordinate; }
    set { coordinate = value; }
  }

  //constructor
  protected ObjectInScene(GameObject prefab, int xPosition, int yPosition) { 

    Coordinate = new Coordinates(xPosition, yPosition);

    gameObject = (GameObject) GameObject.Instantiate(prefab, Coordinate.GetUnityPosition(), Quaternion.identity);

  }
}
