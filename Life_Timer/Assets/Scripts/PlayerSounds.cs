using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour {
    [SerializeField]
    AudioClip[] shots;

    [SerializeField]
    AudioClip jump, water, button;


    CharacterMechanics mec;

    AudioSource sound;
	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
        mec = GetComponent<CharacterMechanics>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Dash()
    {
        sound.pitch = 1;
        sound.clip = shots[Random.Range(0,3)];
        sound.Play();
    }
    public void Jump()
    {
        if (mec.age < 20)
            sound.pitch = 1.6f;
        else if (mec.age >= 20 && mec.age < 30)
            sound.pitch = 1.4f;
        else
            sound.pitch = 1;
        
        sound.clip = jump;
        sound.Play();
    }

    public void Water()
    {
        sound.pitch = 1;
        sound.clip = water;
        sound.Play();
    }
    public void Button()
    {
        sound.pitch = 1;
        sound.clip = button;
        sound.Play();
    }
}
