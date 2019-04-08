using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    GameObject canvas;

	// Use this for initialization
	void Awake () {
        canvas = GameObject.Find("NextLevel");
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
