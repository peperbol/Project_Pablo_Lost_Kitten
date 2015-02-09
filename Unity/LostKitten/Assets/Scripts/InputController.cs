using UnityEngine;
using System.Collections;
using System.Diagnostics;


public class InputController : MonoBehaviour
{

  public float trigger = 0.5f;  //
  public float stepsPerSecond =  8; // want kat is 8 blokjes lang, dus dan gaat hij 8 blokjes per seconden kunnen doen.
  private float nextStepTime = 0;


  private void Update()
  {
    if (nextStepTime < Time.time)   // Time.time = hoe lang is het spel al aan het lopen/runnen?
    {
      nextStepTime = Time.time + 1/stepsPerSecond;  // het volgende tijdspunt, dat je terug een stap mag zetten   =   duratie van het spel +    1/8(hoelang 1 stap duurt)
    
      float moveHorizontal = Input.GetAxis("Horizontal");  // waarde tussen -1 en 1    bv: 0.4 naar links
      float moveVertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(moveHorizontal) > trigger) // dus als je 0.4 naar links gaat, dan ga je nog niet naar links, maar vanaf je move horizontal groter is dan 0.5 gaat hij naar links bewegen
        {
          if (moveHorizontal > 0)
          {
          }
          else
          {
          }
        }
        if (Mathf.Abs(moveVertical) > trigger)//dus als je 0.4 naar boven/onder gaat, gaat het niet mogen, mintsens 0.5 om te bewegen
        {
          if (moveVertical > 0)
          {

          }
          else
          {
        
          }
        }

    } // einde if time

  }






}
