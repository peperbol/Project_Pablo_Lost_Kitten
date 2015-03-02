using System;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

[Serializable]
public class EntityTemplate
{
  //data die hij moet bijhouden
  public int X; // x coordinaat van het begin punt van de entity
  public int Y; // y coordinaat van het begin punt van de entity
  public EntityType Type; // type (enum) van de entity
  public object[] ExtraData; // extra data dat de entity nodig kan hebben afhankelijk van het type
  //constructor
  public EntityTemplate(int x, int y, EntityType type, object[] extraData = null)
  {
    
    X = x;
    Y = y;
    Type = type;
    ExtraData = extraData;
  }
}
