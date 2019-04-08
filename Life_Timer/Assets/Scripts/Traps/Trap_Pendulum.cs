using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Pendulum : MonoBehaviour {

    public Rigidbody2D rBody;
    public float velocidad;
    public float rango;
    private Vector3 lastPos;
    private bool playerIsUp;

	// Use this for initialization
	void Start () {

        rBody.angularVelocity = velocidad;
	}
	
	// Update is called once per frame
	void Update () {

        Move();
        lastPos = transform.position;

        if (playerIsUp)
        {
            GameObject.Find("Character").transform.position = GameObject.Find("Character").transform.position + (transform.position - lastPos);
        }
    }

    private void Move()
    {
        if (transform.rotation.z > 0 && transform.rotation.z < -rango && rBody.angularVelocity > 0 && rBody.angularVelocity < velocidad)
        {
            rBody.angularVelocity = velocidad;
        }

        if (transform.rotation.z < 0 && transform.rotation.z > rango && rBody.angularVelocity < 0 && rBody.angularVelocity > velocidad)
        {
            rBody.angularVelocity = velocidad * -1;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Character")
        {
            playerIsUp = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            playerIsUp = false;
        }
    }
}
