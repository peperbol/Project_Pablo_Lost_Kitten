using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

  private float timeLeft;
  public int totalTime = 90;
  // For our timer we will use minutes and seconds
  /*public float Seconds = 59;
  public float Minutes = 0;*/

  public Text displayObject;

	void Start ()
	{
	  timeLeft = totalTime;

	}


	void Update ()
	{
	  if (timeLeft > 0)
	  {
	    timeLeft -= Time.deltaTime; // de lengte van die frame in seconde, hoe lang die heeft geduurt, ervan aftrekken
	  }
	  else
	  {
	    timeLeft = 0;
      Gamecontroller.GameOver(false); // als de tijd om is, en je hebt niet gewonnen, krijg je u game-over bericht(false = not won)
	  }
    displayObject.text = GetMinutes().ToString("00") +":" + GetSecondsPerMinute().ToString("00"); // we willen 2 getallen, en aanvullen met 0'en
	  // This is if statement checks how many seconds there are to decide what to do.
	  // If there are more than 0 seconds it will continue to countdown.
	  // If not then it will reset the amount of seconds to 59 and handle the minutes;
	  // Handling the minutes is very similar to handling the seconds.
	  /*if(Seconds <= 0)
		{
			Seconds = 59;
			if(Minutes >= 1)
			{
				Minutes--;
			}
			else
			{
				Minutes = 0;
				Seconds = 0;
				// This makes the guiText show the time as X:XX. ToString.("f0") formats it so there is no decimal place.
				GameObject.Find("TimerText").guiText.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
			}
		}
		else
		{
			Seconds -= Time.deltaTime;
		}
		*/
	  // These lines will make sure the time is shown as X:XX and not X:XX.XXXXXX
	  /*if(Mathf.Round(Seconds) <= 9)
		{
			GameObject.Find("TimerText").guiText.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
		}
		else
		{
			GameObject.Find("TimerText").guiText.text = Minutes.ToString("f0") + ":" + Seconds.ToString("f0");
		}*/
	}

  //'k heb ff deze methods zo gezet, anders kon 'k ni runnen - Pepijn


  private int GetSecondsPerMinute()
  {
    return GetTotalSeconds()%60;
  }


  private int GetMinutes()
  {
    return GetTotalSeconds()/60;
  }


  private int GetTotalSeconds()
  {
    return Mathf.CeilToInt(timeLeft); // dat gaat hij naar boven afronden en als int teruggeven
  }



}

	

	
