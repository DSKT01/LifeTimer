using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    Transform pTransform;
    CharacterMechanics pMechanics;
    Transform[] nodesPos;
    Nodes[] progNodes;
    [SerializeField]
    float speedFactor = 1;
    public Nodes selected = null;
    int selectIndex = 0;
    public bool followPlayer = true, canSelect = true;
    [SerializeField]
    Camera me;
    [SerializeField]
    float cameraScaleSpeed;
    private float k = 1, deltaSpeed, t;
    Vector3 lastPos;
    public bool dashEffect;

    // Use this for initialization
    void Start()
    {
        pTransform = GameObject.Find("Character").GetComponent<Transform>();
        pMechanics = pTransform.GetComponent<CharacterMechanics>();
        progNodes = GameObject.Find("Nodes").GetComponentsInChildren<Nodes>();

        nodesPos = new Transform[progNodes.Length];

        me.orthographic = false;
        for (int i = 0; i < nodesPos.Length; i++)
        {
            nodesPos[i] = progNodes[i].gameObject.GetComponent<Transform>();
        }

        Choose();
        lastPos = pTransform.position;
    }
    public void Choose()
    {
        selected = null;
        if (!pMechanics.muriendo)
        {
            for (int i = 0; i < progNodes.Length; i++)
            {

                if (Vector3.Distance(nodesPos[i].position, pTransform.position) < progNodes[i].size)
                {
                    selected = progNodes[i];
                    selectIndex = i;
                    followPlayer = true;

                }
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        deltaSpeed = Vector3.Distance(lastPos, pTransform.position);
        if (selected != null)
        {
            if (Vector3.Distance(pTransform.position, nodesPos[selectIndex].position) > selected.size)
            {
                followPlayer = false;
                if (canSelect)
                {
                    Choose();
                    canSelect = false;
                }
            }

            if (followPlayer)
            {

                k = 1 / ((Mathf.Pow(Vector3.Distance(transform.position, pTransform.position), 2)) / 10) * (Mathf.Exp(deltaSpeed + 0.5f));

                if (Vector3.Distance(new Vector3(transform.position.x - 0.2f, transform.position.y - 0.5f, 0), pTransform.position) > 0.1f)
                {
                    //transform.position = Vector3.MoveTowards(transform.position, new Vector3(pTransform.position.x + 0.2f, pTransform.position.y + 0.5f, transform.position.z), k / ((Mathf.Abs(speedFactor)) + 1f));
                    transform.position = Vector3.Lerp(transform.position, new Vector3(pTransform.position.x + 0.2f, pTransform.position.y + 0.5f, transform.position.z), k);

                }
                if (!dashEffect)
                {
                    t = 0;
                    me.fieldOfView = Mathf.MoveTowards(me.fieldOfView, ((Mathf.Sign(selected.cameraDelta) * (1.5F - (1.5F / (pMechanics.age + 1))))) + (selected.cameraDelta * 1.5f), cameraScaleSpeed / 150f);
                }
                else
                {
                    t = (Mathf.Sign(selected.cameraDelta) * (1.5F - (1.5F / (pMechanics.age + 1)))) + (selected.cameraDelta / 200);
                    me.fieldOfView = Mathf.MoveTowards(me.fieldOfView, t - (t/900) , 0.18f * t);
                }
                


                canSelect = true;
            }
        }
        lastPos = pTransform.position;
    }
}
