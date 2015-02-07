using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;

public class Level : BlockField
{
  //fields
  private Block[,] grid;
  private GameObject worldRoot;
  private List<Entity> entities;
  private LevelTemplate template;


  //properties
  public int Width {
    get { return grid.GetLength(0); }
  }
  public int Heigth
  {
    get { return grid.GetLength(1); }
  }

  //Constuctor
  public Level (LevelTemplate levelTemplate)
  {
    template = levelTemplate;
    BuildLevel();
  }


  //public methods

  //geeft een beperkte oppervlakte van de blocks in het level 
  public Block[,] GetPartOfGrid(Coordinates position, int width, int heigth) 
  {
    //check of de opgevraagde area valid is, 
    if (position.XPosition + width <= Width && position.YPosition + heigth <= Heigth)
    {
      Block[,] part = new Block[width, heigth];
      //kopieer de blocks
      for (int y = 0; y < heigth; y++)
      {
        for (int x = 0; x < width; x++)
        {
          part[x, y] = grid[position.XPosition + x, position.YPosition + y];
        }
      }
      return part;

    }
    else
    { //opgevraagde area is ni valid
      Debug.Log("FOUT: er werd een area buiten het level opgevraagd, returned null.");
      return null;
    }
  }

  //private methods

  //bouwt heel het level op vanuit het template
  public void BuildLevel() 
  {
    //new blocks
    grid = new Block[template.Width,template.Height];

    for (int y = 0; y < template.Height; y++)
    {
      for (int x = 0; x < template.Width; x++)
      {
        grid[x,y] = new Block(x,y,template.Blocks[x,y]);
      }
    }

    //new entities
    entities = new List<Entity>();

    foreach (EntityTemplate entityT in template.Entities)
    {
      Entity newEntity ;
      switch (entityT.Type)
      {
        case EntityType.Player:
          newEntity = new Player();
          break;
        case EntityType.Exit:
          newEntity = new Exit();
          break;
        case EntityType.Slider:
          //aanvullen
          break;
        case EntityType.Button:
          //aanvullen
          break;
      }

      if (newEntity != null)
      {
        entities.Add(newEntity);
      }
      else
      {
        Debug.Log("FOUT: entity is niet geinitializeerd.");
      }
    }
      //aanvullen

    }
  }

}
