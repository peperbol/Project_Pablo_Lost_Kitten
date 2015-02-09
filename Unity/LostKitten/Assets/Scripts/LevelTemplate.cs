using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[Serializable]
public class LevelTemplate
{
  //data die hij moet bijhouden
  public int Width;
  public int Height;
  public BlockColor[,] Blocks;
  public EntityTemplate[] Entities;

  //--constructor--
  //zal in het programma nooit worden gebruikt
  //enkel door dev's gebruikt om een nieuw level te genereren uit een bitmap(texture2D)
  //in het spel zelf worden de level templated ge deserialized uit een bestand dat vooraf word meegegeven.
  public LevelTemplate(Texture2D blocksTexture2D,Texture2D spectrum, EntityTemplate[] entities)
  {
    Entities = entities;

    Width = blocksTexture2D.width;
    Height = blocksTexture2D.height;
    Blocks = new BlockColor[Width,Height];

    //loop door al de pixels
    for (int y = 0; y < Height; y++)
    {
      for (int x = 0; x < Height; x++)
      {
        Color currentPixel = blocksTexture2D.GetPixel(x, y);

        //loop door het spectrum en check welek index er overeenkomt met de pixel;
        for (int i = 0; i < spectrum.width; i++)
        {
          if (currentPixel == spectrum.GetPixel(i, 0))
          {
            Blocks[x, y] = (BlockColor) i;
          }
        }
        // als de bitmap juist is opgestelt zou de Block[x,y] nu een waarde moeten hebben
        // het is gevaarlijk maar ook enkel voor devs bedoeld.
      }
    }

  }
}
