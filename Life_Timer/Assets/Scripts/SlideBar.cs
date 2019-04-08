using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideBar : MonoBehaviour {

    Slider bar;
    Text ageText;
	// Use this for initialization
	void Start () {
        bar = GetComponent<Slider>();
        ageText = GameObject.Find("Age").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        bar.value = GameObject.Find("Character").GetComponent<CharacterMechanics>().age;
        ageText.text = Mathf.Round(GameObject.Find("Character").GetComponent<CharacterMechanics>().age).ToString()+" Age";

    }
}
