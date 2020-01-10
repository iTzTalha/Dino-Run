using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _jumpPower;
    [SerializeField]
    private float _downPower;
    Rigidbody2D myRigidbody;
    private bool isGround;
    private Animator animator;
    private float _screenWigth;
    private GameManager gameManager;

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
            //Space to Jump
            if (Input.GetKeyDown(KeyCode.Space) && !IsDead && isGround)
            {
                myRigidbody.AddForce(Vector2.up * _jumpPower * myRigidbody.mass * myRigidbody.gravityScale * Time.deltaTime);
                animator.SetBool("Jump", true);
            }
            else if (Input.GetKeyUp(KeyCode.Space) && !IsDead && isGround)
            {
                animator.SetBool("Jump", false);
            }

            //S to crouch
            if (Input.GetKeyDown(KeyCode.S) && !IsDead)
            {
                myRigidbody.AddForce(-Vector2.up * _downPower * myRigidbody.mass * myRigidbody.gravityScale * Time.deltaTime);
                animator.SetBool("Down", true);
            }
            else if (Input.GetKeyUp(KeyCode.S) && !IsDead)
            {
                animator.SetBool("Down", false);
            }

            //for mobile controls
            int i = 0;

            while (i < Input.touchCount)
            {
                //touch right to crouch
                if (Input.GetTouch(i).position.x > _screenWigth / 2 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    myRigidbody.AddForce(-Vector2.up * _downPower * myRigidbody.mass * myRigidbody.gravityScale * Time.deltaTime);
                    animator.SetBool("Down", true);
                }
                else if (Input.GetTouch(i).position.x > _screenWigth / 2 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    animator.SetBool("Down", false);
                }

                //touch left to Jump
                if (Input.GetTouch(i).position.x < _screenWigth / 2 && Input.GetTouch(0).phase == TouchPhase.Began && isGround)
                {
                    myRigidbody.AddForce(Vector2.up * _jumpPower * myRigidbody.mass * myRigidbody.gravityScale * Time.deltaTime);
                    animator.SetBool("Jump", true);
                }
                else if (Input.GetTouch(i).position.x < _screenWigth / 2 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    animator.SetBool("Down", false);
                }
                ++i;
            }
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
