using UnityEngine;
using System.Collections;

public interface BlockField  {
  Block[,] Grid { get; }

  int Width { get; }
  int Height { get; } 
}
