using UnityEngine;
using System.Collections;

public interface BlockField  {
  Block[,] grid;
  int Width { get; }
  int Heigth { get; } 
}
