using System;
using UnityEngine;

/*summary:
 variabele om currentlevel aan te spreken ergens, player, timer, InGame is of hij in zijn level bezig is (in spel zit) of in de menu
GameOver --> methode, aangeroepen verloren hebt of gewonnen*/

 
public static class Gamecontroller
{
  
  
    
  //private variabelen
  private static Level currentLevel;
  private static Player player;
  private static Timer timer;
  private static bool inGame;





  //properties
  public static Level CurrentLevel 
  {
    get { return currentLevel; }
    set { currentLevel = value; } 
  }



  public static Player PlayerInGame
  {
    get { return player; }
    set { player = value; }
  }


  
  public static Timer CurrentTimer
  {
    get { return timer; }
    set { timer = value;}
  }


  public static bool InGame
  {
    get { return inGame; }
    set { inGame = value;}
  }



//methoden
  public static void GameOver(bool won)
  {
    Debug.Log(won);
    if (won)
    {
     Application.Quit();
    }

    else
    {
      Application.LoadLevel(Application.loadedLevelName);
    }
  }

  
}//einde klasse
