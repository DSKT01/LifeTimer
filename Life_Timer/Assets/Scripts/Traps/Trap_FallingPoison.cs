using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_FallingPoison : MonoBehaviour {

    public Rigidbody2D rBody;
    public Animator animator;
    private bool activo = false;
    

	// Use this for initialization
	void Start () {

        rBody.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {

        
        animator.SetBool("activa", activo);
        animator.SetFloat("piso", Mathf.Abs(rBody.velocity.y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            rBody.gravityScale = 1;
            activo = true;
            
        }
    }
}
