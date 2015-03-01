using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

  private float timeLeft;   // staat private, maar d.m.v constructors ga je er toch nog aan kunnen 
  public int totalTime = 90;   // de speler krijgt 90 seconden / 1m30s om het level te halen
  public Text displayObject;  // ?? is dit het aanmaken van de variabele om de timer-getallen op het scherm te hebben?


	void Start ()
	{
	  timeLeft = totalTime;   // wanneer het spel star moet de timer gestart worden met het totale tijdstip/ en dus ook de time left
	}


	void Update () // per frame wordt er gekeken hoeveel seconden er nog over zijn
	{
	  if (timeLeft > 0)   // als resterende tijd groter is dan 0
	  {
	    timeLeft -= Time.deltaTime; // timeLeft = timeLeft - time.deltaTime;   resterende tijd = resterende tijd - verstreken tijd?
	  }

	  else   // als resterende tijd niet groter is dan 0, maar 0 zelf
	  {
	    timeLeft = 0;
      GameController.GameOver(false); // als de tijd om is, en je hebt niet gewonnen, krijg je u game-over bericht(false = not won)
	  }
    // einde if else


    displayObject.text = GetMinutes().ToString("00") +":" + GetSecondsPerMinute().ToString("00"); // we willen 2 getallen, en aanvullen met 0'en

	}



  private int GetSecondsPerMinute()  // methode die de seconden terug geeft
  {
    return GetTotalSeconds()%60;  //totaal aantal seconden %60 = aantal minuten   --> bv  78%60 =  1.3      rest 1 minuten???
  }


  private int GetMinutes()   // methode die minuten teruggeeft
  {
    return GetTotalSeconds()/60;   // totaal aantal seconden:60 =     bv-->   85:60= 1.4166   ?????? is het dan hier niet dat je % moet gebruiken?
  }


  private int GetTotalSeconds()   // methode die de timeLeft naar boven gaat afronden
  {
    return Mathf.CeilToInt(timeLeft); // dat gaat hij naar boven afronden en als int teruggeven
  }



}

	

	
