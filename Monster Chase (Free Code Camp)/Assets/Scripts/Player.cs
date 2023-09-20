using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private string WALK_ANIMATION = "Walk"; // the name of the parameter used in transition between animations
    private string GROUND_TAG = "Ground"; // tag used with ground to help with detecting collision
    private string ENEMY_TAG = "Enemy"; // tag used with enemy to help with detecting collision
    private string COIN_TAG = "Coin"; // tag used with coin to help with detecting collision

    [SerializeField] // used to make a variable visible in the inspector tab
    private float moveForce = 10f;
    public float MoveForce { get; set; }
    [SerializeField]
    private float jumpForce = 11f;
    public float JumpForce { get; set; }

    [SerializeField]
    private float kbForce;
    [SerializeField]
    private float kbCounter;
    [SerializeField]
    private float kbTotalTime;

    // define my components
    private Rigidbody2D myBody; 
    private Animator anim;
    private SpriteRenderer sr;
    private HealthStatus healthStatus;

    [SerializeField]
    private float movementX;

    private bool isGrounded = true; // bool to denote if the player has landed
    private bool justJumped = false; // bool to denote if the player has pressed the jump button
    private bool knockFromRight;

    public static bool isCoinCollected;

    void Awake()
    { // get components as soon as the game starts
        myBody = GetComponent<Rigidbody2D> (); 
        anim = GetComponent<Animator> ();
        sr = GetComponent<SpriteRenderer> ();
        healthStatus = GetComponent<HealthStatus>();
    }


    // Update is called once per frame
    void Update() // where input is better called
    {
        AnimatePlayer();
        PlayerMoveKeyboard();
        PlayerJumpInput();
    }

    private void FixedUpdate() // where physics is better called
    {
        //AnimatePlayer();
        //PlayerMoveKeyboard();
        //PlayerJumpInput();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        if(kbCounter <= 0)
        {
            movementX = Input.GetAxisRaw("Horizontal"); // get input from keyboard and direction pressed on the hor axis (raw for direct change from 0 to 1 or -1)
            transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime; // equation for new position of player
        }
        else
        {
            if (knockFromRight)
            {
                myBody.velocity = new Vector3(-kbForce, kbForce, 0f);
            }
            else
            {
                myBody.velocity = new Vector3(kbForce, kbForce, 0f);
            }

            kbCounter -= Time.deltaTime;
        }
    }

    void AnimatePlayer()
    {
        if(movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true); // set transition parameter value
            sr.flipX = false; // set direction sprite will appear looking at (do not flip if sprite is moving to the right)
        }
        else if(movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true); // set transition parameter value
            sr.flipX = true; // set direction sprite will appear looking at (flip if sprite is moving to the left)
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false); // set transition parameter value
        }
    }

    void PlayerJump()
    {
        if(justJumped)
        {
            justJumped = false; // if the player will now jump, we can safely reset justJumped
            isGrounded = false; // if the player will now jump, it is not on the ground
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // apply physics (force) on sprite to jump
        }
    }

    void PlayerJumpInput()
    {
        if(Input.GetButtonDown("Jump") && !justJumped && isGrounded) // get input in update not fixed update
        {
            justJumped = true; //  the jump button is just pressed
        }
    }

    void OnCollisionEnter2D(Collision2D collision) // use to detect collision with collision parameter
    {
        if(collision.gameObject.CompareTag(GROUND_TAG)) // check if the collided with game object is tagged with a specific tag
        {
            isGrounded = true; // if sprite collides with the ground, it has landed
        }
        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            kbCounter = kbTotalTime;
            if (transform.position.x <= collision.transform.position.x)
            {
                knockFromRight = true;
            }
            else
            {
                knockFromRight = false;
            }
            healthStatus.TakeDamage();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            kbCounter = kbTotalTime;
            if (transform.position.x <= collision.transform.position.x)
            {
                knockFromRight = true;
            }
            else
            {
                knockFromRight = false;
            }
            healthStatus.TakeDamage();
        }
        if(collision.CompareTag(COIN_TAG))
        {
            Destroy(collision.gameObject);
            isCoinCollected = true;
        }
    }
}
