using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool faceRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsSolid;
    public GameObject panel;
    public GameObject pause;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private async void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (faceRight && moveInput > 0)
        {
            Flip();
        }
        else if (!faceRight && moveInput < 0)
        {
            Flip();
        }

        if (moveInput == 0)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }

        if (HealthSystem.health <= 0)
        {
            _ = Task.Delay(100);
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsSolid);

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOf");
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJump", false);
        }
        else
        {
            anim.SetBool("isJump", true);
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
