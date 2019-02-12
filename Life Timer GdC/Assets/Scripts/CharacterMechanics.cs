using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterMechanics : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;

    bool inGround = false;

    public bool presJump = false;

    Rigidbody2D mBody;

    // Use this for initialization
    void Start()
    {
        mBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inGround = !(Mathf.Abs(mBody.velocity.y) > 0);

        Move(Input.GetAxis("Horizontal"));
        if (Input.GetButton("Jump"))
            Jump();
        else
            presJump = false;
        if (Input.GetButtonUp("Jump"))
            presJump = false;
    }

    public void Move(float horizontalInput)
    {
        Vector2 moveVel = mBody.velocity;


        if (moveVel.x > 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        if (moveVel.x < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;


        if (!inGround)
            return;


        moveVel.x = horizontalInput * speed;
        mBody.velocity = moveVel;

    }

    public void Jump()
    {

        if (!inGround)
            return;

        mBody.velocity = new Vector2(mBody.velocity.x, jumpForce);
        presJump = true;
    }
}
