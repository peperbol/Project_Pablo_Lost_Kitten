using UnityEngine;
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

      // vormt de juiste locatie van de nieuwe material. 
      string materialName = "Materials/Block_";

      switch (value) // neemt de juiste matierial suffix
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
      //veranderd de material van de block
      gameObject.transform.GetChild(0).renderer.material = (Material) Resources.Load(materialName, typeof(Material));

    }
  }

  public List<Entity> Entities //get property die de entity terug geeft
  {
    get
    {
      return entities;
    }
  }

  public bool IsEntityInList(Entity entityToCheck) // kijkt na of de enity al in de list staat
  {
    bool isInList = false;

    foreach (Entity ent in entities)
    {
      isInList |= (ent == entityToCheck);
    }
    return isInList;
  }


  public void AddEntity(Entity entityToAdd) // voegt de entity toe aan de list (als hij er nog niet in zit)
  {
    if (!IsEntityInList(entityToAdd))
    {
      
        foreach (Entity entInList in entities)
        {
          entInList.CollideEnter(entityToAdd); //geeft event door
        }
      entities.Add(entityToAdd);
      
    }
  }

  public void RemoveEntity(Entity entityToRemove) // verwijderd een entity van de list als hij er in zit
  {
    if (IsEntityInList(entityToRemove))
    {
        foreach (Entity entInList in entities)
        {
          entInList.CollideLeave(entityToRemove); // geeft event door
        }
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
