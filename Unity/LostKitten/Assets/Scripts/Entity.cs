using UnityEngine;
using System.Collections;


/*summary:
 * entity --> alles wat "op" het platform staat bv kat, deurtje,..
 * Als het katje collide met een andere entity bv wat er moet gebeuren.
 */


public abstract class Entity : ObjectInScene, BlockField{

  public Entity(GameObject gameObject, int xPosition, int yPosition)
    : base(gameObject, xPosition, yPosition)
  {
    
  }


  //private variabele
  private EntityType typeOfEntity;
  public Block[,] Grid; 

  //property
  public EntityType TypeOfEntity
  {
    get { return typeOfEntity; }
    set { typeOfEntity = value; }
  }


  public int Width
  {
    get { return Grid.GetLength(0); }
  }

  public int Heigth
  {
    get { return Grid.GetLength(1); }
  }


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
