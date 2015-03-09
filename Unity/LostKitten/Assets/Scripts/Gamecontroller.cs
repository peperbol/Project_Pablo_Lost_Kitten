using System;
using UnityEngine;

/*summary:
 variabele om currentlevel aan te spreken ergens, player, timer, InGame is of hij in zijn level bezig is (in spel zit) of in de menu
GameOver --> methode, aangeroepen verloren hebt of gewonnen*/

 
public static class GameController//static class zodat je deze variabelen over alle klasses heen kan aanspreken
{
  
  
    
  //private variabelen
  private static Level currentLevel;
  private static string currentLevelName;
  private static Player player;
  private static Timer timer;
  private static bool inGame;





  //properties
  public static Level CurrentLevel //level waar je op het moment in zit
  {
    get { return currentLevel; }
    set { currentLevel = value; } 
  }



  public static string CurrentLevelName //een string waar de naam van level waar je in zit wordt bijgehouden --> als je je scene gaat laden dan haalt (als de scene geladen is) hij hieruit u level dat geladen moet worden
  {
    get { return currentLevelName; }

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
  public static void GameOver(bool won) //om het spel te laten stoppen
  {
    if (won) //je hebt net een level gespeeld en gewonnen. Nu moeten we kijken of je nog nooit zo ver bent geraakt -> dan is dit je nieuwste progress (en moet die aangepast worden), of als je dit spel al eerder gewonnen had, blijft de progress hetzelfde.
     
    {
     
      //huidige progress opvragen (hoe ver ben je al geraakt tot nu toe?)
      int progressLevelInt = Int32.Parse(FileReaderWriter.GetProgress()); //het hoogste level dat je al hebt gehaald


      //huidig level dat je net gewonnen hebt opvragen
      int currentLevelNameInt = Int32.Parse(CurrentLevelName);

      //checken of het level dat je net hebt gewonnen hoger is dan je progress (nog nooit zo ver geraakt dus)
      if (currentLevelNameInt > progressLevelInt)
      {

        FileReaderWriter.SetProgress(CurrentLevelName);//huidig level saven als nieuwe progress

      }

      Application.LoadLevel("Roadmap"); //naar de roadmap gaan (sowieso)


    }//einde if won

    else//als je verloren bent
    {
      Application.LoadLevel(Application.loadedLevelName); // laad level --> string meegeven --> unity de levelnaam meegeven die we nu hebben tijdens het spelen (op zelfde level blijven dus)
    }
  }



  public static void LoadLevel(string nameFileLevel) //methode om ons Level te laden, nameFileLevel = naam van het level dat je probeert te spelen (waar je op klikt in het Level overzicht)
  {


    if (Int32.Parse(FileReaderWriter.GetProgress()) + 1 >= Int32.Parse(nameFileLevel)) //.parse --> string omzetten naar een int, als 00 = --> +1 ga je het eerste level (01) spelen. Bv je hebt level 2 uitgespeeld en kan nu level 3 spelen (stuk voor ">=" = 03) en je klikt op level 5 (stuk na de ">=", nameFileLevel = 05) --> is 03 groter of gelijk aan 05? nee, false --> gaat deze methode niet uitvoeren (gaat de scene en het level waar je op geklikt hebt niet gaan laden)
    {

      string nameScene = "Level"; //variabele om de naam van de scene in te steken


      //scene laden
      Application.LoadLevel(nameScene); //laden van de scene --> gaan bij ons om te spelen altijd de scene Level laden, maar je moet die optie available laten


      //de waarde van level meegeven (zeggen welk level we nu moeten tonen)
      currentLevelName = nameFileLevel; //hier steken we de naam die we meegeven met de methode in onze (private) variabele van currentLevelName

    }

  }//einde methode


}//einde klasse
