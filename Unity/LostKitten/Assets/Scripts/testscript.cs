using UnityEngine;
using System.Collections;

public class testscript : MonoBehaviour
{
  private Level level;
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
     

    level = new Level(FileReaderWriter.GetLevelTemplate("01")) ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
