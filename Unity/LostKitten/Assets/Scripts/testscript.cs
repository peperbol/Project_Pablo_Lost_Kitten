using UnityEngine;
using System.Collections;

public class testscript : MonoBehaviour
{
  private Level level;
	// Use this for initialization
	void Start () {
    level = new Level(new LevelTemplate(Resources.Load<Texture2D>("Temp/Map"), Resources.Load<Texture2D>("Temp/Spectrum"))) ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
