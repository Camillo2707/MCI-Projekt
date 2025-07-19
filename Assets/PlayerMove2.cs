using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove2 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float extraJumpForce;
    private float moveInput;
    public GameObject player;
    
    private Rigidbody2D rb;
    
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    
    private int extraJumps;
    public int extraJumpsValue;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public GameObject Tutorial;
    public GameObject Plattform;
    public GameObject Plattform2;
    public GameObject DirectionText;
    
    private GameMaster gm;
    
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 && isGrounded == false)
        {
            rb.velocity = Vector2.up * extraJumpForce;
            extraJumps--;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

   private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.gameObject.CompareTag("DoubleJumpPickup"))
        {
            other.gameObject.SetActive(false);
            extraJumpsValue = 1;
            gm.doubleJumpCollected = true;
            Tutorial.SetActive(true);
            Plattform.SetActive(true);
            Plattform2.SetActive(true);
            DirectionText.SetActive(true);
        }
        if (other.gameObject.CompareTag("SceneChange"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }
   
}
