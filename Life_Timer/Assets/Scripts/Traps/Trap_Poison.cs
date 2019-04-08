using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Poison : MonoBehaviour {

    private float activo = 0;
    public float fuerza = 1;

    void Update()
    {
        GameObject.Find("Character").GetComponent<CharacterMechanics>().age += Time.deltaTime * activo * fuerza;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Character")
        {
            collision.gameObject.GetComponent<CharacterMechanics>().babySpeed -= 1;
            collision.gameObject.GetComponent<CharacterMechanics>().joungSpeed -= 1;
            collision.gameObject.GetComponent<CharacterMechanics>().elderSpeed -= 1;
            activo = 1;
            playercolor();
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            collision.gameObject.GetComponent<CharacterMechanics>().age += Time.deltaTime;
         
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            collision.gameObject.GetComponent<CharacterMechanics>().babySpeed += 1;
            collision.gameObject.GetComponent<CharacterMechanics>().joungSpeed += 1;
            collision.gameObject.GetComponent<CharacterMechanics>().elderSpeed += 1;
            activo = 0;
            collision.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }

    private void playercolor()
    {
        if (activo == 1)
        {
            GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color32(255, 172, 172, 255);
            Invoke("playerwhite", 0.5f);
        } 
            
    }

    private void playerwhite()
    {
        if (activo == 1)
        {
            GameObject.Find("Character").GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            Invoke("playercolor", 0.5f);
        } 

    }
}
