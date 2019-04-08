using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBullCall : MonoBehaviour {

    public GameObject barrera;
    // Use this for initialization

    // Update is called once per frame

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Character")
        {
            Destroy(barrera);
        }
    }
}
