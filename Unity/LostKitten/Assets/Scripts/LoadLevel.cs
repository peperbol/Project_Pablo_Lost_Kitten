using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{

	  new Level(FileReaderWriter.GetLevelTemplate(GameController.CurrentLevelName)); //In FileReaderWriter hebben we een methode GetLevelTemplate waar je de naam van het Level dat je moet laden meegeeft, hij zoekt dan naar die file en laad het Level.

	}
	
}
