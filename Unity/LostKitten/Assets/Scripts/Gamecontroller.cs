using System;
using UnityEngine;

/*summary:
 variabele om currentlevel aan te spreken ergens, player, timer, InGame is of hij in zijn level bezig is (in spel zit) of in de menu
GameOver --> methode, aangeroepen verloren hebt of gewonnen*/

 
public static class GameController//static class zodat je deze variabelen over alle klasses heen kan aanspreken
{
  
  
    
  //private variabelen
  private static Level currentLevel;
  private static Player player;
  private static Timer timer;
  private static bool inGame;





  //properties
  public static Level CurrentLevel //level waar je op het moment in zit
  {
    get { return currentLevel; }
    set { currentLevel = value; } 
  }



  public static Player PlayerInGame //met welke player je aan het spelen bent (voor moest er iemand het spel uitbreiden bv)
  {
    get { return player; }
    set { player = value; }
  }


  
  public static Timer CurrentTimer //de timer die je aan het gebruiken bent
  {
    get { return timer; }
    set { timer = value;}
  }


  public static bool InGame //of je het spel aan het spelen bent (als je in de menu zit bv staat dit op false)
  {
    get { return inGame; }
    set { inGame = value;}
  }



//methoden
  public static void GameOver(bool won) //om het spel te laten stoppen (naar levels pagina)
  {
    Debug.Log(won); 
    if (won)
    {
     Application.Quit();
    }

    else
    {
      Application.LoadLevel(Application.loadedLevelName); // laad level --> string meegeven --> unity de levelnaam meegeven die we nu hebben tijdens het spelen (op zelfde level blijven dus)
    }
  }

  
}//einde klasse
