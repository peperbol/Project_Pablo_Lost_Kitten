﻿using UnityEngine;
using System.Collections;


/*summary:
 * entity --> alles wat "op" het platform staat bv kat, deurtje,..
 * Als het katje collide met een andere entity bv wat er moet gebeuren.
 */


public abstract class Entity : ObjectInScene, BlockField{

  protected Entity(GameObject gameObject, int xPosition, int yPosition, GameObject parent)// gameobject --> prefab die je gebruikt voor de entity, positie waar de entity gaat staan, de parent bv world
    : base(gameObject, xPosition, yPosition, parent)//als je een nieuwe entity gaat aanmaken, ga je deze dingen meegeven tussen de haakjes
  {
    grid = new Block[Width, Height];//we gaan hier algemeen bepalen hoeveel ruimte ze in de breedte en lengte gaan innemen (de entity waar we het over hebben)
  }


  //variabelen
  private EntityType typeOfEntity;//soort entity --> enum, keuze uit player, exit, slider, en lever
  private Block[,] grid; //2dimensionale array die van de interface Blockfield komt, erft er niet echt van over (is een interface, dat gaat niet) dus die moet hier terugkomen (code wordt niet automatisch hier al in "geplakt" zoals bij het overerven) 
 

  //property
  public EntityType TypeOfEntity
  {
    get { return typeOfEntity; } //geef de waarde van de entity terug (bv player, exit,..)
    set { typeOfEntity = value; } // geef een nieuwe waarde (player, exit,..) aan de entity
  }



  public Block[,] Grid //read only property 
  {
    get { return grid; }
  }


  //abstract --> moet nog een waarde krijgen, dit zullen constanten worden (vandaar de hoofdletters), is voor een hoogte en breedte te geven aan de blokken die de entities gaan innemen, enkel get (const. kan je niet aanpassen --> vaste waarde) pepijn breekt mijn wereld --> propertie is NIET gelinkt aan een variabele maar aan een waarde, die je nu nog niet weet. (is versch. voor elke entity) 
  public abstract int Width
  {
    get;
  }


  public abstract int Height
  {
    get;
  }





  /*
  public int Width
  {
    get { return grid.GetLength(0); } //property --> NIET gelinkt aan een variabele. Enkel de lengte van width teruggeven --> in de array gaan kijken [,] eerste dimensie (voor ,) is de width (de x-as)
  }

  public int Heigth
  {
    get { return grid.GetLength(1); }
  }*/







  //methoden

  //gaat overschreven worden door Exit, wat moet er gebeuren als de player in contact komt met een andere entity (ze overlappen dan, de player komt in zijn territorium)
  public virtual void CollideEnter(EntityType entity)
  {
    
  }

  // als hij nog steeds in het "territorium" van de andere entity zit en zich beweegt (verder lopen maar zit nog steeds in zijn territorium zitten)
  public virtual void CollideMove(EntityType entity)
  {

  }


  //Wat moet er gebeuren als de player niet meer in contact is met de andere entity (de player beweegt en is uit zijn territorium)
  public virtual void CollideLeave(EntityType entity)
  {

  }



}//einde klasse
