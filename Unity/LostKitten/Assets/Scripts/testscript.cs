﻿using UnityEngine;
using System.Collections;

public class testscript : MonoBehaviour
{

	// Use this for initialization
	void Start () {

    /*
      FileReaderWriter.SaveLevelTemplate(
         "01", //naam
         new LevelTemplate(
             Resources.Load<Texture2D>("Temp/Map"), 
             Resources.Load<Texture2D>("Temp/Spectrum"), 

             new EntityTemplate[] //lijst van entities
	            {
                new EntityTemplate(1, 0, EntityType.Exit),
	              new EntityTemplate(61, 1, EntityType.Player)
	            }
         )
       );
     */
    /*
    FileReaderWriter.SaveLevelTemplate(
        "02", //naam
        new LevelTemplate(
            Resources.Load<Texture2D>("Temp/level02"),
            Resources.Load<Texture2D>("Temp/spectrum"),

            new EntityTemplate[] //lijst van entities
	            {
                new EntityTemplate(13, 14, EntityType.Exit),
	              new EntityTemplate(12, 21, EntityType.Player)
	            }
        )
      );
     */

    new Level(FileReaderWriter.GetLevelTemplate("02")) ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
