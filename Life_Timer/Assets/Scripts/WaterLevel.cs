using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    float duracion;
    private bool actived = false;
    private float initialSizeY;
    private float initialSizeX;
    private Vector3 initialPos;
    private Vector3 initialScale;
    private float t;
    Renderer mRender;
    Collider2D mCollider;
    // Use this for initialization
    void Start()
    {
        mCollider = GetComponent<Collider2D>();
        mRender = GetComponent<Renderer>();
        initialSizeX = mCollider.bounds.size.x;
        initialSizeY = mCollider.bounds.size.y;
        duracion = initialSizeY * initialSizeX;
        initialPos = transform.position;
        initialScale = transform.localScale;
        
    }
    private void Update()
    {
        
        if (actived)
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(initialPos, initialPos - new Vector3(0, initialSizeY, 0), t / (duracion * 100 ));


            transform.localScale = Vector3.Lerp(initialScale, new Vector3(initialScale.x, 0, initialScale.z), t / (duracion * 100 ));
        }
        if (mRender.bounds.size.y <= 0)
        {
            mCollider.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            actived = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            actived = false;
        }
    }
}
