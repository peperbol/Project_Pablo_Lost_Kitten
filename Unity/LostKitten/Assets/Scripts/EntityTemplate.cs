using System;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

[Serializable]
public class EntityTemplate
{
  //data die hij moet bijhouden
  public int X;
  public int Y;
  public EntityType Type;
  //constructor
  public EntityTemplate(int x, int y, EntityType type)
  {
    X = x;
    Y = y;
    Type = type;
  }
}
