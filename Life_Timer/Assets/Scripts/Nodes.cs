using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour {
    public float size;
    public float cameraDelta;
    MoveCamera mCamera;
    Transform pTrans;
    Nodes me;
    // Use this for initialization
    void Start() {
        mCamera = GameObject.Find("Main Camera").GetComponent<MoveCamera>();
        pTrans = GameObject.Find("Character").GetComponent<Transform>();
        me = GetComponent<Nodes>();
	}
    private void FixedUpdate()
    {
        if (mCamera.selected == null)
        {
            if (Vector3.Distance(transform.position, pTrans.position) < size)
            {
                mCamera.Choose();
                
               
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
