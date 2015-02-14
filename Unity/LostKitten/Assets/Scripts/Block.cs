﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Block : ObjectInScene {
  //fields
  private BlockColor color; // kleur van e blok
  private List<Entity> entities = new List<Entity>(); // een lijst van alle entities die zich momenteel op deze blok bevinden // moet nog veranderen

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

  public bool IsEntityInList(Entity entityToCheck)
  {
    bool isInList = false;

    foreach (Entity ent in entities)
    {
      isInList |= (ent == entityToCheck);
    }
    return isInList;
  }


  public void AddEntity(Entity entityToAdd)
  {
    if (!IsEntityInList(entityToAdd))
    {
      entities.Add(entityToAdd);
    }
  }

  public void RemoveEntity(Entity entityToRemove)
  {
    if (IsEntityInList(entityToRemove))
    {
      entities.Remove(entityToRemove);
    }
  }


  //constructor
  public Block(int xPosition, int yPosition, BlockColor initialColor, GameObject parent)
    : base((GameObject)Resources.Load("Prefabs/Block", typeof(GameObject)), xPosition, yPosition, parent)
  {
    Color = initialColor;
  }

}
