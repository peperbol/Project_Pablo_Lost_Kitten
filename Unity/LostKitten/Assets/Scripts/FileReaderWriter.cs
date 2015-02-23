using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class FileReaderWriter
{
  private static string levelDirectory = "Levels/";
  private static string levelExtention = ".dat";
  private static string readwritefolder = Application.persistentDataPath /*"Assets/StreamingAssets/"*/ ;
  private static string slash = "/";

  public static LevelTemplate GetLevelTemplate(string levelName)
  {
    string fileName = levelDirectory + levelName + levelExtention;
    if (!File.Exists(readwritefolder + slash + fileName)) UnpackFile(fileName);
    LevelTemplate lt;

    //lees de file
    FileStream stream = File.Open(readwritefolder + slash+ fileName, FileMode.Open);
    //zet om naar obj
    BinaryFormatter bformatter = new BinaryFormatter();
    lt = (LevelTemplate) bformatter.Deserialize(stream);

    stream.Close();

    return lt;
  }

  public static void SaveLevelTemplate(string levelName, LevelTemplate levelTemplate )
  {
    BinaryFormatter bf = new BinaryFormatter();
    FileStream stream = File.Create(Application.streamingAssetsPath + slash + levelDirectory + levelName + levelExtention);
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

  private static void UnpackFile(string fileName)
  {  //copies and unpacks file from apk to persistentDataPath where it can be accessed
    string destinationPath = readwritefolder + slash + fileName;
    string sourcePath = Application.streamingAssetsPath + slash + fileName;

    //if DB does not exist in persistent data folder (folder "Documents" on iOS) or source DB is newer then copy it
    if (!File.Exists(destinationPath) || (File.GetLastWriteTimeUtc(sourcePath) > File.GetLastWriteTimeUtc(destinationPath)))
    {
      if (sourcePath.Contains("://"))
      {// Android  
        WWW www = new WWW(sourcePath);
        while (!www.isDone) { ;}                // Wait for download to complete - not pretty at all but easy hack for now 
        if (String.IsNullOrEmpty(www.error))
        {
          File.WriteAllBytes(destinationPath, www.bytes);
        }
        else
        {
          Debug.Log("ERROR: the file DB named " + fileName + " doesn't exist in the StreamingAssets Folder, please copy it there.");
        }
      }
      else
      {                // Mac, Windows, Iphone                
        //validate the existens of the DB in the original folder (folder "streamingAssets")
        if (File.Exists(sourcePath))
        {
          string dir = destinationPath.Substring(0, destinationPath.LastIndexOf(slash)); //het pad naar de dir
          //copy file - alle systems except Android
          if (!Directory.Exists(dir))
          {
            Directory.CreateDirectory(dir );
          }
          File.Copy(sourcePath, destinationPath, true);
        }
        else
        {
          Debug.Log("ERROR: the file DB named " + fileName + " doesn't exist in the StreamingAssets Folder, please copy it there.");
        }
      }
    }
  }
  //uit http://answers.unity3d.com/questions/591545/not-able-to-load-binary-file-through-resourcesload.html?sort=oldest
}
