using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class FileReaderWriter
{

  //private variabelen
  private static string levelDirectory = "Levels/"; // de map waarin levels worden bewaard
  private static string levelExtention = ".dat"; //extantie van de levels
  private static string progressFile = "progress.dat"; // bestand waar je vooruitgang (huidig level) is staat opgelsagen
  private static string readwritefolder = Application.persistentDataPath ; // is in windows <je gebruiker>/Appdata/locallow/projectpablo/lostkitten
  private static string slash = "/";




  //methoden

  //leest een leveltemplate van de hardeschijf
  public static LevelTemplate GetLevelTemplate(string levelName)
  {


    string fileName = levelDirectory + levelName + levelExtention;//relatieve plek/naam van het bestand
    

    // als het er nog niet staat (1st boot ofzo) kan hij het kopieren uit de "streaming assets" (deel dan de unity bestanden)
    // hij doet dit dan eerst
    if (!File.Exists(readwritefolder + slash + fileName))
    {

      UnpackFile(fileName);

    }



     // nu gaan we het effectief van file naar object omzetten


    LevelTemplate lt;//nieuwe variable om het object in te steken


    //lees de file
    FileStream stream = File.Open(readwritefolder + slash+ fileName, FileMode.Open);

    //zet om naar obj en stop het in de variable
    BinaryFormatter bformatter = new BinaryFormatter();
    lt = (LevelTemplate) bformatter.Deserialize(stream);

    stream.Close(); // en afsluiten

    return lt;
  }//einde methode





  // zal enkel door devs gebruikt worden
  // het opslaan van een nieuw level template
  public static void SaveLevelTemplate(string levelName, LevelTemplate levelTemplate )
  {

    BinaryFormatter bf = new BinaryFormatter();
    FileStream stream = File.Create(Application.streamingAssetsPath + slash + levelDirectory + levelName + levelExtention);
    bf.Serialize(stream, levelTemplate);
    stream.Close();

  }//einde methode





  public static String GetProgress()
  {

    string fileName = progressFile;//relatieve plek/naam van het bestand


    // als het er nog niet staat (1st boot ofzo) kan hij het kopieren uit de "streaming assets" (deel dan de unity bestanden)
    // hij doet dit dan eerst
    if (!File.Exists(readwritefolder + slash + fileName))
    {

      UnpackFile(fileName);

    }



    if (File.Exists(readwritefolder + slash + fileName))
    {
      // nu gaan we het effectief van file naar object omzetten

      string levelName; //nieuwe variable om het object in te steken

      //lees de file
      FileStream stream = File.Open(readwritefolder + slash + fileName, FileMode.Open);

      //zet om naar obj en stop het in de variable
      BinaryFormatter bformatter = new BinaryFormatter();
      levelName = (string) bformatter.Deserialize(stream);

      stream.Close(); // en afsluiten

      return levelName;

    }

    return "00";

  }//einde methode





  public static void SetProgress(string progress)
  {

    BinaryFormatter bf = new BinaryFormatter();


    FileStream stream = File.Create(readwritefolder + slash + progressFile);
    bf.Serialize(stream, progress);
    stream.Close();

  }//einde methode



  // wanneer een bestand nog niet in de persistend data zit, zal dit eerst moeten worden gekopieerd. ook vooral voor als het later voor android zou worden geport
  // aangepast uit de code uit volgende UnityAnswers tread
  // http://answers.unity3d.com/questions/591545/not-able-to-load-binary-file-through-resourcesload.html?sort=oldest
  
  private static void UnpackFile(string fileName) // filename kan ook diepere mappen bevatten
  {  

    //copies and unpacks file from apk to persistentDataPath where it can be accessed

    string destinationPath = readwritefolder + slash + fileName;
    string sourcePath = Application.streamingAssetsPath + slash + fileName;



    if (!File.Exists(destinationPath)) // nakijken of het er al niet staat.
    {
            
        //kijkt na of het bestand bestaat dat hij moet kopieren (folder "streamingAssets")
        if (File.Exists(sourcePath))
        {
          
          string dir = destinationPath.Substring(0, destinationPath.LastIndexOf(slash)); //het volledige pad naar de bestemmings map
          
          if (!Directory.Exists(dir))
          { 

            // als de map er nog niet is maken we deze eerst aan.
            Directory.CreateDirectory(dir );

          }


          // het bestand effectief kopieren
          File.Copy(sourcePath, destinationPath, true);

        }//einde if
          
      }//einde nakijken of het bestaat
    
  }//einde methode
}//einde klasse
