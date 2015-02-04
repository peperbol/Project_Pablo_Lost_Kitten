using UnityEngine;
using System.Collections;

public static class ColorSpectrum // static zoadat andere klassen enzo er ook aan kunnen (maar dus ook overal static hier bijschrijven, anders klaagt hij)
{

  private static BlockColor[] spectrum = new BlockColor[]
  {
    BlockColor.Red,     //0
    BlockColor.Orange,  //1
    BlockColor.Yellow,  //2
    BlockColor.Green,   //3
    BlockColor.Blue,    //4
    BlockColor.Purple   //5
  };

// methode aanmaken: IsAdjacent (blockColor, blockColor)
// methode aanmaken: GetAdjacentColor(bool, blockColor)
 //methode aanmaken: GetComplementColor(blockColor)

  //deze methode gaat de waarde [] van u kleur teruggeven.
  private static int GetIndexByValue(BlockColor bc)    // blockcolor bc = gewoon blockColor.Yellow of red of blue
  {
    int index = -1;  // variabele aanmaken index voor waarde []
    for (int i =0 ; i < spectrum.Length ; i++)// loop aanmaken zodat hij de array gaat doorlopen en ze allemaal een waarde geeft. i gaat nooit groter zijn dan de lengte van u spectrum array (6)
    {
      if (spectrum[i] == bc)   // als de plaats in u spectrum [] gelijk is aan bc(blockcolor) dan is u indexwaarde = aan u waarde in u array
      {
        index = i; //dan is u indexwaarde = aan u waarde in u array[]    bv: if spectrum [0] == bc   ==> index = 0    dan doet hij i++ en wordt u i = 1
      }
    }
    return index;
  }

  public static bool IsAdjacent(BlockColor color1, BlockColor color2)   // checken of 2 kleuren adjacent zijn op het kleurenwiel
  {

    return (
      color1 == color2 ||   // is color 1 hetzelfde als color2 dan is hij adjacent 
      (GetIndexByValue(color1) + 1) % spectrum.Length == GetIndexByValue(color2) ||   // om naar onder toe ales adjacent te laten zijn (3+1)%6 = 4        (GetIndexByValue(color1) = een int (u index van vorige methode)   en dan +1 om 
      GetIndexByValue(color1) == (GetIndexByValue(color2) + 1)%spectrum.Length  // om ook 5 en 0 adjacent te laten zijn  bv: getindexbyvalue(color1)= 0 (red)  == getidexbyvalue(color2)+1  = (5 + 1)%6 = 0
      ); // = true, dan wordt dit gereturned

  
  }
  

}
