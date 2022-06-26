using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    float jumpPressedRememberTimer;
    [Header("Button Settings")]
    [Tooltip("Jump Buffer Leniency")]
    public float jumpPressedRememberTime;
    [Tooltip("Coyote Time Leniency")]
    public float groundedRememberTime;
    float groundedRememberTimer;

    [Range(0f, 1f)]
    [Tooltip("Factor of how much a jump height should be cut based off of letting go of space")]
    public float cutJumpHeightFactor;
    [Tooltip("Leniency distance for what counts as on the ground.")]
    public float distance;
    public LayerMask mask;
    public float MinJumpForce;
    public float MaxJumpForce;
    public float MaxAerialJumps;
    float doubleJumpsLeft;
    public float maxSpeed = 10;
    //Movement
    public float accel;
    public float decel;
    public float moveVelocity;
    bool hasDoubleJumped;
    [Tooltip("True=you can do X consecutive in air jumps, False=you can do X double jumps")]
    public bool allowConsecutiveAerialJumps;
    float normalGravityScale;
   
    //Collision Audio
    //public AudioSource CollisionSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        doubleJumpsLeft = MaxAerialJumps;
        hasDoubleJumped = false;
        //CollisionSFX = GameObject.FindGameObjectWithTag("CollisionSFX").GetComponent<AudioSource>();
        normalGravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitGround;
        if (CompareTag("Circle"))
            hitGround = Physics2D.Raycast(transform.position, Vector3.down, distance + rb.GetComponent<CircleCollider2D>().radius, mask);
        else
            hitGround = Physics2D.Raycast(transform.position, Vector3.down, distance + rb.GetComponent<BoxCollider2D>().bounds.size.y / 2, mask);
        //grounded buffer
        groundedRememberTimer -= Time.deltaTime;
        if (hitGround.collider != null) //hit ground
        {
            groundedRememberTimer = groundedRememberTime;
            hasDoubleJumped = false;
        }
        //code for buffering jump
        jumpPressedRememberTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) { 
        jumpPressedRememberTimer = jumpPressedRememberTime; }

        //Left Right Movement
        if (CompareTag("Circle"))
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                moveVelocity += -accel;
                if (moveVelocity < -maxSpeed)
                {
                    moveVelocity = -maxSpeed;
                }
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                moveVelocity += accel;
                if (moveVelocity > maxSpeed)
                {
                    moveVelocity = maxSpeed;
                }
            }
        }
        else if (hitGround.collider == null && CompareTag("Rectangle"))
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                moveVelocity += -accel;
                if (moveVelocity < -maxSpeed)
                {
                    moveVelocity = -maxSpeed;
                }
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                moveVelocity += accel;
                if (moveVelocity > maxSpeed)
                {
                    moveVelocity = maxSpeed;
                }
            }
        }
        
        if (!(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))||(CompareTag("Rectangle")&&hitGround.collider!=null)){
            if (moveVelocity > 0)
            {
                moveVelocity = Mathf.Clamp(moveVelocity - decel, 0, moveVelocity - decel);
            }
            else if(moveVelocity<0)
            {
                moveVelocity = Mathf.Clamp(moveVelocity + decel, moveVelocity+decel, 0);
            }
        }
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        //jump
        if (groundedRememberTimer > 0 && jumpPressedRememberTimer > 0)
        {
            jumpPressedRememberTimer = 0;
            groundedRememberTimer = 0;
            float jumpForce;
            if (CompareTag("Circle"))
            {
                jumpForce = Mathf.Lerp(MinJumpForce, MaxJumpForce, Mathf.Abs(moveVelocity) / maxSpeed);
            }
            else jumpForce = MinJumpForce;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
    }

    
    //Collision Event for Collision sound effect
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollisionTag")
        {
            //CollisionSFX.Play();
        }
    }

}