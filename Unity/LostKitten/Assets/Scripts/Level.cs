using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level 
{
  //fields
  private Block[,] grid;
  private GameObject worldRoot;
  private List<Entity> entities;
  private LevelTemplate template;

  public LevelTemplate Template
  {
    get { return template; }
  }



  //properties
  public Block[,] Grid
  {
    get { return grid; }
  }

  public int Width {
    get { return grid.GetLength(0); } // 0  => 1e dimentie is de breette
  }
  public int Height
  {
    get { return grid.GetLength(1); } // 1 => 2e dimentie is de hoogte
  }

  //Constuctor
  public Level (LevelTemplate levelTemplate)
  {
    GameController.CurrentLevel = this; // zet zich zelf als het huidige level
    worldRoot = GameObject.FindWithTag("WorldRoot"); // neemt de worldroot om mee te geven aan de objecten die hij gaat genereren
    template = levelTemplate; // onthoud het template in ene klasse variable
    BuildLevel(); // bouwt heel het level en instantiate een hoop dingen en maakt een hoob objecten
    SetCameraPosition(); // zet de camera juist
  }


  //public methods

  //geeft een beperkte oppervlakte van de blocks in het level 
  //zorgt ervoor dat je een bepaald deel van het grid (totaal grid) kunt opvragen, bv coordinaten 4,3 hoogte 5 breedte 7, dan ga je met dat bepaald deel iets nu kunnen doen
  public Block[,] GetPartOfGrid(Coordinates position, int width, int heigth) 
  {
    //check of de opgevraagde area valid is, 
    if (position.XPosition + width -1 <= Width && position.YPosition + heigth -1 <= Height) // chackt of de blockjes binnen het leve liggen
    {
      Block[,] part = new Block[width, heigth]; // maakt een array met de goede grootte, waarin we de blokjes gana steken
      //kopieer de blocks
      for (int y = 0; y < heigth; y++) 
      {
        for (int x = 0; x < width; x++)//geneste 2D loop
        { 
          part[x, y] = grid[position.XPosition + x , position.YPosition + y]; // neemt de blokjes over naar de nieuwe array
        }
      }
      return part;//geef de array terug

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
    //verwijder alle oude kinderen
    for (int i = 0; i < worldRoot.transform.childCount; i++)
    {
      GameObject.Destroy(worldRoot.transform.GetChild(i).gameObject);
      
    }

    //maakt voor elk element in de grid van de template een nieuwe block met bijpassende kleur. deze blokken zullen zelf zich in de scene zetten in de constructor
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

    foreach (EntityTemplate entityT in template.Entities) // voor elke entity die in de template staat gaat hij een nieuwe entity maken.
    {
      Entity newEntity ;
      switch (entityT.Type) //afhankelijk van het type entity gaat deze een andere constructor aanspreken
      {
        case EntityType.Player:
          newEntity = new Player(entityT.X, entityT.Y, worldRoot);
          break;
        case EntityType.Exit:
          newEntity = new Exit(entityT.X, entityT.Y, worldRoot);
          break;
        case EntityType.Teleporter:
          newEntity = new Teleporter(entityT.X,entityT.Y, worldRoot, new Coordinates((int)entityT.ExtraData[0],(int)entityT.ExtraData[1])); 
            // voor een tele word de extra data gebruikt, 1e element is int xcoordinaat, 2e element is int ycoordinaat
          break;
        case EntityType.Lever:
          newEntity = new Lever(entityT.X, entityT.Y, worldRoot);
          break;
        default:
          Debug.Log("Fout: EntityType is onbekend.");
          newEntity = null;
          break;
      }

      if (newEntity != null) // normaal gezien lukt dit maar toch om zeker te zijn
      {
        entities.Add(newEntity);
      }
      else
      {
        Debug.Log("FOUT: entity is niet geinitializeerd.");
      }
    }

    
  }

  public void SetCameraPosition()
  {
    // centreerd de camera volgens de juiste schaling en grootte van het level
    Camera.main.transform.position = new Vector3(Width / 2f * Coordinates.XSCALE, Height / 2f * Coordinates.YSCALE, Camera.main.transform.position.z); 
    // zet de FOV gelijk met de hoogte van het level.
    Camera.main.orthographicSize = Math.Abs( Height / 2f * Coordinates.YSCALE );
  }



}
