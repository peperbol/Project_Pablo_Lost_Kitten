using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : BlockField
{
  //fields
  private Block[,] grid;
  private GameObject worldRoot;
  private List<Entity> entities;
  private LevelTemplate template;



  //properties
  public Block[,] Grid
  {
    get { return grid; }
  }

  public int Width {
    get { return grid.GetLength(0); }
  }
  public int Height
  {
    get { return grid.GetLength(1); }
  }

  //Constuctor
  public Level (LevelTemplate levelTemplate)
  {
    worldRoot = GameObject.FindWithTag("WorldRoot");
    template = levelTemplate;
    BuildLevel();
  }


  //public methods

  //geeft een beperkte oppervlakte van de blocks in het level 
  //zorgt ervoor dat je een bepaald deel van het grid (totaal grid) kunt opvragen, bv coordinaten 4,3 hoogte 5 breedte 7, dan ga je met dat bepaald deel iets nu kunnen doen
  public Block[,] GetPartOfGrid(Coordinates position, int width, int heigth) 
  {
    //check of de opgevraagde area valid is, 
    if (position.XPosition + width -1 <= Width && position.YPosition + heigth -1 <= Height)
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

//bouwt heel het level op vanuit het template
  public void BuildLevel() 
  {
    //new blocks
    grid = new Block[template.Width,template.Height];

    for (int y = 0; y < template.Height; y++)
    {
      for (int x = 0; x < template.Width; x++)
      {
        grid[x,y] = new Block(x,y,template.Blocks[x,y],worldRoot);
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
          newEntity = new Player(entityT.X, entityT.Y, worldRoot);
          break;
        case EntityType.Exit:
          newEntity = new Exit(entityT.X, entityT.Y, worldRoot);
          break;
        case EntityType.Slider:
          newEntity = null; //nog verder aanvullen
          break;
        case EntityType.Button:
          newEntity = null; //nog verder aanvullen
          break;
        default:
          Debug.Log("Fout: EntityType is onbekend.");
          newEntity = null;
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
