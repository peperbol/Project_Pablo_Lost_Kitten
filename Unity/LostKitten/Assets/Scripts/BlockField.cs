using UnityEngine;
using System.Collections;

public interface BlockField  {
  private Block[,] grid;
  public int Width { get; }
  public int Heigth { get; } 
}
