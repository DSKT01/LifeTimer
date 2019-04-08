using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour {

    public CapsuleCollider2D collid;
    private float playerAge;

	// Use this for initialization
	void Start () {
		
        
	}
	
	// Update is called once per frame
	void Update () {

        playerAge = gameObject.GetComponent<CharacterMechanics>().age;

        if (playerAge <10)
        {
            collid.size = new Vector2(collid.size.x, 0.1f);
            collid.offset = new Vector2(collid.offset.x, -0.099f);
        }
        if (playerAge >= 10 && playerAge < 20)
        {
            collid.size = new Vector2(collid.size.x, 0.155f);
            collid.offset = new Vector2(collid.offset.x, -0.072f);
        }
        if (playerAge >= 20 && playerAge < 30)
        {
            collid.size = new Vector2(collid.size.x, 0.28f);
            collid.offset = new Vector2(collid.offset.x, -0.031f);
        }
        if (playerAge >= 30 && playerAge < 40)
        {
            collid.size = new Vector2(collid.size.x, 0.28f);
            collid.offset = new Vector2(collid.offset.x, -0.00856f);
        }
        if (playerAge >= 40 && playerAge < 50)
        {
            collid.size = new Vector2(collid.size.x, 0.28f);
            collid.offset = new Vector2(collid.offset.x, -0.00856f);
        }
        if (playerAge >= 50 && playerAge < 60)
        {
            collid.size = new Vector2(collid.size.x, 0.2700571f);
            collid.offset = new Vector2(collid.offset.x, -0.01497146f);
        }

        if (playerAge >= 60 && playerAge < 70)
        {
            collid.size = new Vector2(collid.size.x, 0.2700571f);
            collid.offset = new Vector2(collid.offset.x, -0.01497146f);
        }

        if (playerAge >= 70 && playerAge < 80)
        {
            collid.size = new Vector2(collid.size.x, 0.2700571f);
            collid.offset = new Vector2(collid.offset.x, -0.01497146f);
        }

        if (playerAge >= 80 && playerAge < 90)
        {
            collid.size = new Vector2(collid.size.x, 0.2535788f);
            collid.offset = new Vector2(collid.offset.x, -0.03321061f);
        }

        if (playerAge >= 90)
        {
            collid.size = new Vector2(collid.size.x, 0.19f);
            collid.offset = new Vector2(collid.offset.x, -0.05550554f);
        }

    }
}
