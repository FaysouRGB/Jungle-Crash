using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip hurt;
    private Rigidbody2D rigidbody2D;
    private bool isGrounded;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    private void Update()
    {
        var moveInput = Input.GetAxis("Horizontal");
        playerSpriteRenderer.flipX = moveInput is not 0 ? moveInput < 0 : playerSpriteRenderer.flipX;
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        rigidbody2D.velocity = new Vector2(moveInput * moveSpeed, rigidbody2D.velocity.y);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void Die()
    {
        AudioSource.PlayClipAtPoint(hurt, Vector3.zero);
        transform.position = new Vector3(0, -2.5f, 0);
    }
}
