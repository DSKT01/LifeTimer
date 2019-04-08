using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public RuntimeAnimatorController noventa;
    public RuntimeAnimatorController ochenta;
    public RuntimeAnimatorController setenta;
    public RuntimeAnimatorController sesenta;
    public RuntimeAnimatorController cincuenta;
    public RuntimeAnimatorController cuarenta;
    public RuntimeAnimatorController treinta;
    public RuntimeAnimatorController veinte;
    public RuntimeAnimatorController diez;
    public RuntimeAnimatorController cinco;
    private float playerAge;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        playerAge = GameObject.Find("Character").GetComponent<CharacterMechanics>().age;

        if (playerAge >= 90 && playerAge <=99)
        {
       
            this.GetComponent<Animator>().runtimeAnimatorController = noventa as RuntimeAnimatorController;
        }

        if (playerAge >= 80 && playerAge <= 89)
        {

            this.GetComponent<Animator>().runtimeAnimatorController = ochenta as RuntimeAnimatorController;
        }

        if (playerAge >= 70 && playerAge <= 79)
        {

            this.GetComponent<Animator>().runtimeAnimatorController = setenta as RuntimeAnimatorController;
        }

        if (playerAge >= 60 && playerAge <= 69)
        {

            this.GetComponent<Animator>().runtimeAnimatorController = sesenta as RuntimeAnimatorController;
        }

        if (playerAge >= 50 && playerAge <= 59)
        {

            this.GetComponent<Animator>().runtimeAnimatorController = cincuenta as RuntimeAnimatorController;
        }

        if (playerAge >= 40 && playerAge <= 49)
        {

            this.GetComponent<Animator>().runtimeAnimatorController = cuarenta as RuntimeAnimatorController;
        }

        if (playerAge >= 30 && playerAge <= 39)
        {

            this.GetComponent<Animator>().runtimeAnimatorController = treinta as RuntimeAnimatorController;
        }

        if (playerAge >= 20 && playerAge <= 29)
        {

            this.GetComponent<Animator>().runtimeAnimatorController = veinte as RuntimeAnimatorController;
        }

        if (playerAge >= 10 && playerAge <= 19)
        {

            this.GetComponent<Animator>().runtimeAnimatorController = diez as RuntimeAnimatorController;
        }

        if (playerAge >= 5 && playerAge <= 9)
        {

            this.GetComponent<Animator>().runtimeAnimatorController = cinco as RuntimeAnimatorController;
        }
    }
}
