using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public Rigidbody2D rb;
    private bool isGrounded;
    public LayerMask groundLayer;

    // Quantum Phase Variables
    private bool isPhasing = false;
    public float phaseDuration = 2f;

    void Update()
    {
        // Move left/right
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Quantum Phase Shift
        if (Input.GetKeyDown(KeyCode.E) && !isPhasing)
        {
            StartCoroutine(QuantumPhase());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    IEnumerator QuantumPhase()
    {
        isPhasing = true;
        GetComponent<SpriteRenderer>().color = new Color(0, 1, 1, 0.5f); // Semi-transparent
        gameObject.layer = LayerMask.NameToLayer("Ghost"); // Pass through objects
        yield return new WaitForSeconds(phaseDuration);
        GetComponent<SpriteRenderer>().color = Color.white;
        gameObject.layer = LayerMask.NameToLayer("Default");
        isPhasing = false;
    }
}
