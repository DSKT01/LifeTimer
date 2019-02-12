using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMechanics : MonoBehaviour
{

    public float babySpeed, joungSpeed, elderSpeed;

    [SerializeField] float jump;

    [SerializeField] float dashForce;
    [SerializeField] float dashTime;
    [SerializeField] bool canDash = true;


    public PhysicsMaterial2D bouncy;
    public PhysicsMaterial2D normalmaterial;

    MoveCamera mCamara;

    [SerializeField] MousePos mDirectionDash;
    Vector2 diretionDash;
    public float speed;
    float jumpForce;

    public float age = 5;


    bool inGround = false;
    [SerializeField] bool inDash = false;
    bool inWater = false;
    public bool presJump = false;

    public bool canMoveInAir = true;
    public LayerMask playerMask;

    public bool trap = false;
    bool fixDead = true;
    private float tDeMuerte = 0, tDeDash;
    public bool muriendo = false;

    public Animator animator;

    Rigidbody2D mBody;
    Transform tagTrans, tag2Trans;

    public ParticleSystem blood;
    PlayerSounds sounds;

    private IEnumerator coroutine;
    // Use this for initialization
    void Start()
    {
        tagTrans = GameObject.Find("Tag_ground").GetComponent<Transform>();
        tag2Trans = GameObject.Find("Tag_ground2").GetComponent<Transform>();
        mBody = GetComponent<Rigidbody2D>();
        mCamara = GameObject.Find("Main Camera").GetComponent<MoveCamera>();
        sounds = GetComponent<PlayerSounds>();
    }
    private void Update()
    {
        if (muriendo)
        {
            if (fixDead)
            {
                mBody.velocity = Vector2.zero;
                fixDead = false;
            }
            tDeMuerte += Time.deltaTime;
            if (tDeMuerte >= 1.5f)
            {
                GameObject.Find("Canvas").GetComponent<ButtonController>().Restart();

            }
        }
        else
        {
            mBody.drag = Mathf.Abs(mBody.velocity.y / 4);
        }

        
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        GameObject.Find("Boom").GetComponent<SpriteRenderer>().flipX = gameObject.GetComponent<SpriteRenderer>().flipX;
        if (age >= 100 || age < 1)
            Die();
        if (!muriendo)
        {
            diretionDash = mDirectionDash.dashDirection;
            //revisa si hay algun collider tocando una lnea generada desde el centro del personaje hasta sus pies
            inGround = Physics2D.Linecast(gameObject.transform.position, tagTrans.position, playerMask) || Physics2D.Linecast(gameObject.transform.position, tag2Trans.position, playerMask);



            Move(Input.GetAxis("Horizontal"));
            if (Input.GetButton("Jump"))
                Jump();
            else
                presJump = false;
            if (Input.GetButtonUp("Jump"))
                presJump = false;

            if (Input.GetMouseButton(0))
            {
                if (canDash)
                {
                    coroutine = Dash(diretionDash);
                    StartCoroutine(coroutine);

                    GameObject.Find("Boom").GetComponent<BoomAnimator>().anim();
                    GameObject.Find("Boom").GetComponent<Transform>().position = gameObject.transform.position;
                }
            }



            if (age < 10)
            {
                speed = babySpeed;
                jumpForce = 0;
            }
            if (age >= 10 && age < 80)
            {
                speed = joungSpeed;
                jumpForce = jump;
            }
            if (age >= 80)
            {
                speed = elderSpeed;
                jumpForce = 0;
            }

            if (inWater)
            {
                age -= 0.2f;

            }

        }
        if (inDash && (Mathf.Abs(mBody.velocity.y) < 0.01f))
        {
            tDeDash += 10;
            inDash = false;
            canDash = true;
            gameObject.GetComponent<CapsuleCollider2D>().sharedMaterial = normalmaterial;

        }
        if (tDeDash >= dashTime)
        {
            gameObject.GetComponent<CapsuleCollider2D>().sharedMaterial = normalmaterial;
            tDeDash = 0;
            inDash = false;
            canDash = true;

        }
        if (inDash)
        {
            tDeDash += Time.deltaTime;
            gameObject.GetComponent<CapsuleCollider2D>().sharedMaterial = bouncy;
            if (tDeDash > 0.2f)
            {
                age += 10 * Time.deltaTime;
            }
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider2D>().sharedMaterial = normalmaterial;
        }
        animator.SetFloat("velocidad", Mathf.Abs(mBody.velocity.x));
        animator.SetBool("InDash", inDash);
        animator.SetBool("IsGrounded", inGround);
        animator.SetBool("Muerto", muriendo);


    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Collision = collision.gameObject;
        if (Collision.tag == "Water")
        {
            inWater = true;
            sounds.Water();
            GetComponent<SpriteRenderer>().color = new Color32(194, 253, 211, 255);
        }
        if (Collision.tag == "DeathZone")
        {
            Die();
        }



    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameObject Collision = collision.gameObject;
        if (Collision.tag == "Water")
        {
            inWater = false;
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
    }


    public void Move(float horizontalInput)
    {
        Vector2 moveVel = mBody.velocity;


        if (moveVel.x > 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        if (moveVel.x < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;


        if ((!canMoveInAir && !inGround) || inDash || trap)
            return;


        moveVel.x = horizontalInput * speed;
        mBody.velocity = moveVel;

    }
    public void Jump()
    {
        
        if (!inGround || inDash)
            return;
        //mBody.velocity += jumpForce * Vector2.up;
        //mBody.AddForce (Vector2.up * jumpForce);
        mBody.velocity = new Vector2(mBody.velocity.x, jumpForce);
        presJump = true;
        if (age>=10 && age<80)
            sounds.Jump();
    }
    
    IEnumerator Dash(Vector2 point)
    {
        if (!inDash)
        {
            canDash = false;
            mBody.velocity = new Vector2(0, 0);
            mBody.simulated = false;
            transform.GetComponent<Renderer>().enabled = false;
            //mBody.velocity = (point * dashForce);
            mCamara.dashEffect = true;
            sounds.Dash();
            yield return new WaitForSeconds(0.2f);
            blood.Play();
            mCamara.dashEffect = false;
            mBody.velocity = new Vector2(0, 0);
            transform.GetComponent<Renderer>().enabled = true;
            mBody.simulated = true;
            inDash = true;
            mBody.AddForce(point * dashForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
            blood.Stop();
    
            
        }

    }

    public void Die()
    {
        muriendo = true;
        MoveCamera mCamera = GameObject.Find("Main Camera").GetComponent<MoveCamera>();
        mCamera.followPlayer = false;

    }






}
