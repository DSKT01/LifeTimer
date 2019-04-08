using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Bull : MonoBehaviour {

    private bool canAttack = true;
    private Rigidbody2D mBody;
    public GameObject objective;
    private bool atacar = false;
    public float speed;
    public float fuerza;
    public float damage;


	// Use this for initialization
	void Start () {

        mBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if (atacar == true)
        {
            Vector3 newposition = transform.position;  // posicionar el objeto segun el valor que tenga la variable "carril"
            newposition.x = Mathf.Lerp(newposition.x, objective.transform.position.x, Time.deltaTime * speed);
            transform.position = newposition;
        }

        if ( Vector2.Distance( transform.position, objective.transform.position) <= 0.4)
        {
            canAttack = false;
        }

        
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == ("Character") && canAttack)
        {
            atacar = true;
        }
        }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == ("Character") && canAttack )
        {
            collision.gameObject.GetComponent<CharacterMechanics>().trap = true;
            collision.gameObject.GetComponent<CharacterMechanics>().age += mBody.velocity.x * 2f;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed* fuerza ,0), ForceMode2D.Impulse);
            collision.gameObject.GetComponent<CharacterMechanics>().age += Mathf.Abs(damage);
            GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color32(255, 172, 172, 255);
            damage = 0;

            Invoke("Espera", 0.5f);
            Invoke("Color", 0.9f);
        }
    }

    private void Espera()
    {
        GameObject.Find("Character").GetComponent<CharacterMechanics>().trap = false;

    }

    private void Color()
    {
        GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

    }

}

