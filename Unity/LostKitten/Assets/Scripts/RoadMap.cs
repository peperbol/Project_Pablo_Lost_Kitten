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

	// Use this for initialization
	void Start () {
	
	}

  public void Reset()
  {

  }

}
