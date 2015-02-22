using UnityEngine;
using System.Collections;

public abstract class ObjectInScene {

  //fields
  private Coordinates coordinate;
  protected GameObject gameObject;

  //property
  public Coordinates Coordinate
  {
    get {
     
      return coordinate.Copy; //anders kan men DEZE instantie (coordinate) intern aanpassen. Je past nu zijn kopie aan. In de get ga je anders het object kunnen opvragen en daarna (via zijn properties --> XPositie en YPositie) aanpassen. We willen dat dit enkel via de set gaat gebeuren dus sturen we met de get gewoon een kopie van wat de coordinaten zijn op dit moment. (die kan je dan niet aanpassen)
    }
    set
    {
      coordinate = value; //als we de coordinaten willen veranderen moet dit via de SET gebeuren!
      gameObject.transform.position = value.GetUnityPosition();
    }
  }

  //constructor
  protected ObjectInScene(GameObject prefab, int xPosition, int yPosition,GameObject parent) { 

    

    gameObject = (GameObject) GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);

    gameObject.transform.parent = parent.transform;

    Coordinate = new Coordinates(xPosition, yPosition);
  }
}
