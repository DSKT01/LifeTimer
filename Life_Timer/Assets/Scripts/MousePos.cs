using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePos : MonoBehaviour
{
    [SerializeField]
    float mouseX, mouseY, maxDisX, maxDisY;
    [SerializeField]
    Transform camara, jugador;
    public Vector3 dashDirection;
    Camera camCam;
    // Use this for initialization
    void Start()
    {
        camCam = camara.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camara != null && jugador!= null)
        {
            if (Time.timeScale == 1)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
            //transform.localScale = new Vector3(camCam.orthographicSize / 2.5f, camCam.orthographicSize / 2.5f, 1);
            //transform.Rotate(new Vector3(0, 0, 1));
            //mouseX = Input.GetAxis("Mouse X") * Time.timeScale / 10;
            //mouseY = Input.GetAxis("Mouse Y") * Time.timeScale / 10;
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x + mouseX, camara.position.x - maxDisX * camCam.orthographicSize, camara.position.x + maxDisX * camCam.orthographicSize), Mathf.Clamp(transform.position.y + mouseY, camara.position.y - maxDisY * camCam.orthographicSize, camara.position.y + maxDisY * camCam.orthographicSize), 0);
            ////transform.position = new Vector3(Mathf.Clamp(transform.position.x + mouseX, camara.position.x - maxDisX , camara.position.x + maxDisX ), Mathf.Clamp(transform.position.y + mouseY, camara.position.y - maxDisY , camara.position.y + maxDisY ), 0);
            //dashDirection = (transform.position - jugador.position).normalized;
            //dashDirection.y = dashDirection.y * 1.5f;
            transform.localScale = new Vector3(camCam.fieldOfView / 20f, camCam.fieldOfView / 20f, 1);
            transform.Rotate(new Vector3(0, 0, 1));
            mouseX = Input.GetAxis("Mouse X") * Time.timeScale / 10;
            mouseY = Input.GetAxis("Mouse Y") * Time.timeScale / 10;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + mouseX, camara.position.x - (maxDisX / 9.5f)* camCam.fieldOfView, camara.position.x + (maxDisX / 9.5f) * camCam.fieldOfView), Mathf.Clamp(transform.position.y + mouseY, camara.position.y - (maxDisY / 9.5f) * camCam.fieldOfView, camara.position.y + (maxDisY / 9.5f) * camCam.fieldOfView), 0);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x + mouseX, camara.position.x - maxDisX , camara.position.x + maxDisX ), Mathf.Clamp(transform.position.y + mouseY, camara.position.y - maxDisY , camara.position.y + maxDisY ), 0);
            dashDirection = (transform.position - jugador.position).normalized;
            dashDirection.y = dashDirection.y * 1.5f;
        }
        
    }

}

