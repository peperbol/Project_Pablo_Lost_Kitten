﻿using UnityEngine;
using System.Collections;

public static class ColorSpectrum // static klasse aanmaken - static zodat andere klassen enzo er ook aan kunnen (maar dus ook overal static hier bijschrijven, anders klaagt hij)
{

  private static BlockColor[] spectrum = new BlockColor[] // nieuwe array spectrum maken voor alle kleuren in te steken uit de enum BlockColor.  [] leeg: niets vastleggen qua aantal
  {
    BlockColor.Red,     //0
    BlockColor.Orange,  //1
    BlockColor.Yellow,  //2
    BlockColor.Green,   //3           // totale length van array = 6
    BlockColor.Blue,    //4
    BlockColor.Purple   //5
  };

  // methode aanmaken: bool IsAdjacent (blockColor, blockColor)  V 
 //methode aanmaken: GetComplementColor(blockColor) V


  //deze methode gaat gewoon de waarde in de array [i] van u kleur teruggeven.
  private static int GetIndexByValue(BlockColor bc)    // blockcolor bc = gewoon blockColor.Yellow of red of blue, maar met deze methode kan je beter werken.
  {
    int index = -1;  // variabele aanmaken index voor waarde []
    for (int i =0 ; i < spectrum.Length ; i++)// loop aanmaken zodat hij de array gaat doorlopen en ze allemaal een waarde geeft. i gaat nooit groter zijn dan de lengte van u spectrum array (6)
    {
      if (spectrum[i] == bc)   // de waarde in u plaats in u spectrum [] = krijgt de waarde bc(blockcolor) 
      {
        index = i; //dan is u indexwaarde = aan u waarde in u array[]    bv: if spectrum [0] == bc   ==> index = 0    dan doet hij i++ en wordt u i = 1
      }
    }
    return index;
  }



  public static bool IsAdjacent(BlockColor color1, BlockColor color2)   // checken of 2 kleuren adjacent zijn op het kleurenwiel
  {

    return (
      color1 == color2 ||   // is color 1 dezelfde kleur als color2 dan is hij adjacent OF
      (GetIndexByValue(color1) + 1) % spectrum.Length == GetIndexByValue(color2) ||  //OF   om naar onder toe ales adjacent te laten zijn (3+1)%6 = 4        (GetIndexByValue(color1) = een int (u index van vorige methode)   en dan +1 om 
      GetIndexByValue(color1) == (GetIndexByValue(color2) + 1)%spectrum.Length  // om ook 5 en 0 adjacent te laten zijn  bv: getindexbyvalue(color1)= 0 (red)  == getidexbyvalue(color2)+1  = (5 + 1)%6 = 0
      ); // = true, dan wordt dit gereturned

  
  }

  public static BlockColor GetComplementColor(BlockColor color)  // geeft de complementaire kleur terug 
  {

    return spectrum[  // wat hieronder staat, staat binnen de haakjes: [] en dus geeft dat een complementaire kleur als waarde [] terug  
      
     (GetIndexByValue(color)+(spectrum.Length)/2)%spectrum.Length   // u indexwaarde[] + de helft van u spectrum array lengte (6 /2 = 3) niet gewoon 3, want dat is hard coded. om aan u complementaire kleur te komen, en indien u cijfertje te klein is ook nog % nemen om er aan te geraken

     ];
    // bv:
    //  ( [4] blue + 3 )  % 6 =    (4+3)= 7      7%6 = 1 (orange)
    //  ( [2] yellow + 3 )% 6 =    (2+3)= 5      5%6 = 5 (purple)
    //  ( [3] green + 3 ) % 6 =    (3+3)= 6      6%6 = 0 (red)


  }


}
