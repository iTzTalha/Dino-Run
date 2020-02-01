using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpPower;
    //[SerializeField] private float _downPower;
    Rigidbody2D myRigidbody;
    private bool isGround;
    private Animator animator;
    private float _screenWigth;
    private GameManager gameManager;
    private bool canJump = false;
    private bool canCrouch = false;

    public bool IsDead { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _screenWigth = Screen.width;
        myRigidbody = GetComponent<Rigidbody2D>();       
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead && !gameManager.IsPaused)
        {
            //Keyboard Inputs
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                canJump = true;
            }

            if (Input.GetKeyDown(KeyCode.S) && isGround)
            {
                canCrouch = true;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("Down", false);
            }

            //Mobile Inputs
            int i = 0;
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).position.x < _screenWigth / 2 && Input.GetTouch(i).phase == TouchPhase.Began && isGround)
                {
                    canJump = true;
                }

                if (Input.GetTouch(i).position.x > _screenWigth / 2 && Input.GetTouch(i).phase == TouchPhase.Began && isGround)
                {
                    canCrouch = true;
                }
                else if (Input.GetTouch(i).position.x > _screenWigth / 2 && Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    animator.SetBool("Down", false);
                }
                ++i;
            }
        }
    }   

    void FixedUpdate()
    {
        //Jump
        if (canJump)
        {
            myRigidbody.AddForce(Vector2.up * _jumpPower * myRigidbody.mass * myRigidbody.gravityScale * Time.deltaTime);
            animator.SetBool("Jump", true);
            animator.SetBool("Down", false);
            isGround = false;
            canJump = false;
        }

        //crouch
        if (canCrouch)
        {
            // myRigidbody.AddForce(-Vector2.up * _downPower * myRigidbody.mass * myRigidbody.gravityScale * Time.deltaTime);
            animator.SetBool("Down", true);
            canCrouch = false;
        }
    }

    //jump only when colided with ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
            animator.SetBool("Jump", true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("Jump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {         
            IsDead = true;
            Time.timeScale = 0;
            animator.SetBool("Die", true);     
        }  
    }
}
