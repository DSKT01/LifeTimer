using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject[] Panels;
    GameObject pause, nextLevel;
    void Start()
    {
        Time.timeScale = 1;
        pause = GameObject.Find("Pause");
        if (pause != null)
        {
            pause.SetActive(false);
        }
        nextLevel = GameObject.Find("NextLevel");
        if (nextLevel != null)
        {
            nextLevel.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pause != null)
            {
                if (Time.timeScale != 0)
                    Pause();
                else
                    Continue();
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause()
    {
        //print(Panels.Length);
        Panels[0].SetActive(false);
        Panels[1].SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        Panels[0].SetActive(true);
        Panels[1].SetActive(false);
    }
    public void Exit()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
        
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
