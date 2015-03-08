using UnityEngine;
using System.Collections;

public class testscript : MonoBehaviour
{

	// Use this for initialization
	void Awake () {

    /*
      FileReaderWriter.SaveLevelTemplate(
         "01", //naam
         new LevelTemplate(
             Resources.Load<Texture2D>("Temp/level01small"), 
             Resources.Load<Texture2D>("Temp/Spectrum"), 

             new EntityTemplate[] //lijst van entities
	            {
                new EntityTemplate(0, 0, EntityType.Exit),
	              new EntityTemplate(31, 0, EntityType.Player)
	            },
              90 //tijd van het level
         )
       );
      FileReaderWriter.SaveLevelTemplate(
         "02", //naam
         new LevelTemplate(
             Resources.Load<Texture2D>("Temp/level02small"),
             Resources.Load<Texture2D>("Temp/Spectrum"),

             new EntityTemplate[] //lijst van entities
	            {
                new EntityTemplate(1, 51, EntityType.Exit),
	              new EntityTemplate(28, 1, EntityType.Player)
	            },
              90 //tijd van het level
         )
       );
    FileReaderWriter.SaveLevelTemplate(
         "03", //naam
         new LevelTemplate(
             Resources.Load<Texture2D>("Temp/level03v2"),
             Resources.Load<Texture2D>("Temp/spectrum"),

             new EntityTemplate[] //lijst van entities
               {
                 new EntityTemplate(13, 14, EntityType.Exit),
                 new EntityTemplate(12, 21, EntityType.Player),
               },
              90 //tijd van het level
         )
       );
    */
    FileReaderWriter.SaveLevelTemplate(
        "04", //naam
        new LevelTemplate(
            Resources.Load<Texture2D>("Temp/level04v2"),
            Resources.Load<Texture2D>("Temp/spectrum"),

            new EntityTemplate[] //lijst van entities
               {
                 new EntityTemplate(11, 30, EntityType.Lever),
                 new EntityTemplate(69, 51, EntityType.Lever),
                 new EntityTemplate(16, 64, EntityType.Player),
                 new EntityTemplate(77, 30, EntityType.Exit)
               },
             120 //tijd van het level
        )
      );
      
    /*
    FileReaderWriter.SaveLevelTemplate(
        "05", //naam
        new LevelTemplate(
            Resources.Load<Texture2D>("Temp/level05"),
            Resources.Load<Texture2D>("Temp/spectrum"),

            new EntityTemplate[] //lijst van entities
               {
                 new EntityTemplate(38, 33, EntityType.Lever),
                 new EntityTemplate(54, 23, EntityType.Lever),
                 new EntityTemplate(35, 2, EntityType.Teleporter,new object[]{52,3}),
                 new EntityTemplate(51, 2, EntityType.Teleporter,new object[]{36,3}),
                 new EntityTemplate(52, 29, EntityType.Teleporter,new object[]{1,1}),
                 new EntityTemplate(44, 2, EntityType.Player),
                 new EntityTemplate(16, 44, EntityType.Exit)
               },
             150 //tijd van het level
        )
      );
    */
    new Level(FileReaderWriter.GetLevelTemplate("04")) ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
