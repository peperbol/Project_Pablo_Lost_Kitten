using UnityEngine;
using System.Collections;

public interface BlockField  {
  public Block[,] Grid;
  public int Width { get; }
  public int Heigth { get; } 
}
