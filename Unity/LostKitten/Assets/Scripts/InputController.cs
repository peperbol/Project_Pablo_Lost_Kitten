using UnityEngine;
using System.Collections;

public class Boundary
{
  public float xMin, xMax, zMin, zMax;  // zo kunnen we die aangezien we het in een aparte klasse steken, overal aan 
}



public class InputController : MonoBehaviour
{

  public float speed;
  public Boundary boundary;




  private void FixedUpdate()
  {

    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

                        // Vector3(x,y,z)
    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);   // nieuwe variabele aanmaken die beschrijft hoe de speler naar onder boven links en rechts gaat
    rigidbody.velocity = movement*speed;

    rigidbody.position = new Vector3    //(x,y,z)
      //boundary --> zorgt ervoor dat je speler binnen de perken van het spel blijft. en niet u scherm kan verlaten
      (
      Mathf.Clamp(rigidbody.position.x, xMin, xMax),    // clamp zorgt ervoor dat je een waarde hebt tussen een min en een max. 
      0.0f, // 2D je hoeft niet omhoog
      Mathf.Clamp(rigidbody.position.z, zMin, zMax)
      );
  }






}
