using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomAnimator : MonoBehaviour {

    private Animator animator;
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
    private RuntimeAnimatorController AnimActual;
    private float playerAge;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        playerAge = GameObject.Find("Character").GetComponent<CharacterMechanics>().age;

        if (playerAge >= 90 && playerAge <= 99)
            AnimActual = noventa;

        if (playerAge >= 80 && playerAge <= 89)
            AnimActual = ochenta;

        if (playerAge >= 70 && playerAge <= 79)
            AnimActual = setenta;

        if (playerAge >= 60 && playerAge <= 69)
            AnimActual = sesenta;

        if (playerAge >= 50 && playerAge <= 59)
            AnimActual = cincuenta;

        if (playerAge >= 40 && playerAge <= 49)
            AnimActual = cuarenta;

        if (playerAge >= 30 && playerAge <= 39)
            AnimActual = treinta;

        if (playerAge >= 20 && playerAge <= 29)
            AnimActual = veinte;

        if (playerAge >= 10 && playerAge <= 19)
            AnimActual = diez;

        if (playerAge >= 5 && playerAge <= 9)
            AnimActual = cinco;

    }
    public void anim()
    {
        animator.runtimeAnimatorController = AnimActual as RuntimeAnimatorController;
        animator.Rebind();
    }
}
