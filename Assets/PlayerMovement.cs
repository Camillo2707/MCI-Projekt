
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    public int jumps;
    public float jumpforce;
    public GameObject player;
    public bool isJumping;
    public Transform groundCheck;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,body.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumps == 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpforce);
                jumps++;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumps = 0;
            isJumping = false;
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            Destroy(player);
            SceneManager.LoadScene("GameOver");
        }
    }
        
    
}
