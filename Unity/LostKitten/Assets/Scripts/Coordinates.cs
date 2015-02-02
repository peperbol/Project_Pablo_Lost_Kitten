using UnityEngine;
using System.Collections;

public class Coordinates {

  //static constants voor de omzetting van vector3 position en co-ords
  public static const float XSCALE = 1f;
  public static const float YSCALE = -1f;
  public static const float ZVALUE = 0f;

  //fields
  private int xPosition = 0;
  private int yPosition = 0;

  //properties
  public int XPosition
  {
    get { return xPosition; }
    set {
      if (value >= 0)
      {
        xPosition = value;
      }
    }
  }

  public int YPosition
  {
    get { return yPosition; }
    set {
      if (value >= 0)
      {
        yPosition = value;
      }
    }
  }

  // constructors
  public Coordinates(int x, int y) {
    XPosition = x;
    YPosition = y;
  }

  public Coordinates(Vector3 UnityPosition) {
    XPosition = (int) Mathf.Floor(UnityPosition.x / XSCALE);
    YPosition = (int) Mathf.Floor(UnityPosition.y / YSCALE);
  }

  // om de positie die in de scene overeen komen met de co-ords
  public Vector3 GetUnityPosition() {
    return new Vector3(XPosition * XSCALE, YPosition * YSCALE, ZVALUE);
  }

}
