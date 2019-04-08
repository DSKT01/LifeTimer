using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act_Tech : MonoBehaviour
{
    public enum Type
    {
        Bridge,
        Slide,
        Door,
        Button
    }
    public Type type;
    [SerializeField]
    Act_Tech activatedBy;
    bool playerIsUp, actived = false;
    Vector3 initialPos, lastPos, initialScale;
    public int direction = 1;
    GameObject player;
    int fix = 1;
    float t = 0;
    float initialSizeY, initialSizeX;
    // Use this for initialization
    void Start()
    {
        initialPos = transform.position;
        initialScale = transform.localScale;

        initialSizeY = GetComponent<Renderer>().bounds.size.y / 2;


        initialSizeX = GetComponent<Renderer>().bounds.size.x / 2;


        if (type == Type.Button)
        {
            activatedBy = this.gameObject.GetComponent<Act_Tech>();
        }
        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case Type.Bridge:
                {
                    Act_Bridge();
                    break;
                }

            case Type.Slide:
                {
                    Act_Slide();
                    break;
                }
            case Type.Door:
                {
                    Act_Door();
                    break;
                }

            case Type.Button:
                {
                    Act_Button();
                    break;
                }

            default:
                {
                    break;
                }

        }
        actived = activatedBy.actived;
        lastPos = transform.position;
    }

    public void Act_Bridge()
    {

        if (actived)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPos, Vector3.Distance(initialPos, transform.position) * 2 * Time.deltaTime);



        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(initialPos.x, initialPos.y - 2000, initialPos.z), 50 * Time.deltaTime);
        }
    }
    public void Act_Slide()
    {
        if (actived)
        {
            transform.position += new Vector3(0.8f * direction * Time.deltaTime, 0, 0);
            if (playerIsUp)
            {

                player.transform.position = player.transform.position + (transform.position - lastPos);



            }


        }
    }
    public void Act_Door()
    {
        if (actived)
        {
            t += Time.deltaTime;
            if (initialSizeY > initialSizeX)
            {
                transform.position = Vector3.Lerp(initialPos, initialPos + new Vector3(0, initialSizeY, 0), t / 4);
            }
            else
            {
                transform.position = Vector3.Lerp(initialPos, initialPos + new Vector3(initialSizeX, 0, 0), t / 4);
            }
            transform.localScale = Vector3.Lerp(initialScale, new Vector3(initialScale.x, 0, initialScale.z), t / 4);
        }
    }
    public void Act_Button()
    {

        if (playerIsUp)
        {
            actived = true;

        }
        if (actived)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(initialPos.x, initialPos.y - 0.2f, initialPos.z), 0.5f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  
    {
        if (collision.gameObject.tag != "Player")
        {
            direction *= -1;          
        }
        else
        { 
            playerIsUp = true;
            if (type == Type.Button)
                GameObject.Find("Character").GetComponent<PlayerSounds>().Button();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsUp = false;
        }
    }
}
