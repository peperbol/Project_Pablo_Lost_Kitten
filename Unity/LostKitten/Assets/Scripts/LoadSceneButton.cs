using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
  public string SceneToLoad;
  public bool IsLevel = false;
  public void onClick()
  {
    if (!IsLevel)
    {
    Application.LoadLevel(SceneToLoad);
    }
    else
    {
      GameController.LoadLevel(SceneToLoad);
    }
  }
}
	
