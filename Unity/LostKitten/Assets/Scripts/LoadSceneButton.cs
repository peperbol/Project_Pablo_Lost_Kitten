using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
  public string sceneToLoad;
  public bool isLevel = false;
  public bool useCurrentLevel = false;
  public bool quitGame = false;


  public void OnClick()
  {
    if (quitGame)
    {
      Application.Quit();
    }
    else if (!isLevel)//als je niet op een bepaald level klikt om te spelen
    {
    Application.LoadLevel(sceneToLoad);//de scene laden die je wilt laden met de button
    }

    else//als je wel een bepaald level wilt spelen
    {

      if (useCurrentLevel) //als je het currentLevel wilt spelen door op de button te klikken
      {
        GameController.LoadSceneLevel(GameController.CurrentLevelName); //laad het currentLevel
      }

      else
      {
        GameController.LoadSceneLevel(sceneToLoad); //als je een ander level wilt laden dan het currentlevel (wordt gebruikt bij de roadmap)
      }
      

    }//einde else
  }//einde onClick
}
	
