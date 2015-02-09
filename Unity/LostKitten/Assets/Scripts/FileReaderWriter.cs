using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class FileReaderWriter {

  public static LevelTemplate GetLevelTemplate(string levelName)
  {
    LevelTemplate lt;

    //lees de file
    Stream stream = File.Open(levelName+".level", FileMode.Open);
    //zet om naar obj
    BinaryFormatter bformatter = new BinaryFormatter();
    lt = (LevelTemplate) bformatter.Deserialize(stream);

    stream.Close();

    return lt;
  }

  public static object GetRoadMap(string levelName)
  {
    return null;
  }

  public static int GetProgress(string levelName)
  {
    return 0;
  }
}
