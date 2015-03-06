using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoadMap : MonoBehaviour
{
   [Header("Player Visual")]
  public RectTransform Player;
  public Vector2[] PlayerPositions;
   [Header("Clouds Visual")]
  public Image[] clouds;

  public Color ActiveColor;
  public Color InactiveColor;

	void Start () {
    //progress ophalen
	  int progress = Int32.Parse(FileReaderWriter.GetProgress());

    //de kleuren van de wolken juist zetten, enkel speelbare level active
	  for (int i = 0; i < clouds.Length; i++)
	  {
	    if (i <= progress)
	    {
	      clouds[i].color = ActiveColor;
	    }
	    else
      {
        clouds[i].color = InactiveColor;
	    }
	  }

    //pablo juist positioneren
	  Player.anchorMin = PlayerPositions[progress];
	  Player.anchorMax = PlayerPositions[progress];
	}

  public void Reset()
  {
    FileReaderWriter.SetProgress("00");
    Start();
  }

}
