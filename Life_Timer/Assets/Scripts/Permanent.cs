using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Permanent : MonoBehaviour
{

    static Permanent perma;
    public int level;

    // Use this for initialization
    void Start()
    {
        if (perma != null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            perma = this;
        }

        level = 1;
    }
}
