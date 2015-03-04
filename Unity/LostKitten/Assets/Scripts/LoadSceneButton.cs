using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
  public string LevelToLoad;
  public void onClick()
  {
    Debug.Log("hi");
	Application.LoadLevel(LevelToLoad);
	}
	
}
