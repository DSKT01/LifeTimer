using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_PushBall : MonoBehaviour {

    
    public float forceH;
    public float forceV;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character" && !collision.gameObject.GetComponent<CharacterMechanics>().trap )
        {
            collision.gameObject.GetComponent<CharacterMechanics>().trap = true;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce( new Vector2 (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x * forceH, -collision.gameObject.GetComponent<Rigidbody2D>().velocity.y * forceV), ForceMode2D.Impulse);
            Invoke("Espera", 0.5f);
            
        }
    }

    private void Espera()
    {
        GameObject.Find("Character").GetComponent<CharacterMechanics>().trap = false;
    }

}
