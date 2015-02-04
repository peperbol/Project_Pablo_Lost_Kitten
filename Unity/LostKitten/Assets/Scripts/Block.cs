using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : ObjectInScene {
  //fields
  private BlockColor color;
  private List<object> entities = new List<object>(); // moet nog veranderen

  //properties
  public BlockColor Color
  {
    get { return color; }
    set { 
      color = value;

      // get the name of the according material 
      string materialName = "Materials/Block_";
      switch (value)
      {
        case BlockColor.Red:
          materialName += "Red";
          break;
        case BlockColor.Orange:
          materialName += "Orange";
          break;
        case BlockColor.Yellow:
          materialName += "Yellow";
          break;
        case BlockColor.Green:
          materialName += "Green";
          break;
        case BlockColor.Blue:
          materialName += "Blue";
          break;
        case BlockColor.Purple:
          materialName += "Purple";
          break;
      }
      //change the material of the block
      gameObject.transform.GetChild(0).renderer.material = (Material) Resources.Load(materialName, typeof(Material));

    }
  }

  public List<object> Entities // moet nog veranderen
  {
    get { return entities; }
  }

  //constructor
  public Block(int xPosition, int yPosition, BlockColor initialColor)
    : base((GameObject)Resources.Load("Prefabs/Block", typeof(GameObject)), xPosition, yPosition)
  {
    Color = initialColor;
  }

}
