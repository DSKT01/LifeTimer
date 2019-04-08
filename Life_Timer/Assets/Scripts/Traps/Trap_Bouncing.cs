using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Bouncing : MonoBehaviour {

    public Rigidbody2D rBody;
    private bool canAttack = true;
    public Vector2 fuerza;
    

	// Use this for initialization
	void Start () {
        rBody.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {

        rBody.angularVelocity = 350f;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character" && canAttack)
        {
            rBody.AddForce(fuerza, ForceMode2D.Impulse);
            rBody.gravityScale = 1;
            canAttack = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Character")
        {
            collision.gameObject.GetComponent<CharacterMechanics>().age += 1.5f * rBody.velocity.magnitude;
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 172, 172, 255);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }



}
