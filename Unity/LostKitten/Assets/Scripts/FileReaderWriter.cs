using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class FileReaderWriter
{
  private static string levelDirectory = "Levels/";
  private static string levelExtention = ".dat";
  private static string readwritefolder = "Assets/readwrite/" ;

  public static LevelTemplate GetLevelTemplate(string levelName)
  {
    LevelTemplate lt;

    //lees de file
    FileStream stream = File.Open(readwritefolder + levelDirectory + levelName + levelExtention, FileMode.Open);
    //zet om naar obj
    BinaryFormatter bformatter = new BinaryFormatter();
    lt = (LevelTemplate) bformatter.Deserialize(stream);

    stream.Close();

    return lt;
  }

  public static void SaveLevelTemplate(string levelName, LevelTemplate levelTemplate )
  {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream stream = File.Create(readwritefolder + levelDirectory + levelName + levelExtention);
    bf.Serialize(stream, levelTemplate);
    stream.Close();
  }

  public static object GetRoadMap(string levelName)
  {
    return null;
  }

  public static int GetProgress(string levelName)
  {
    return 0;
  }

  //http://answers.unity3d.com/questions/591545/not-able-to-load-binary-file-through-resourcesload.html?sort=oldest
}
