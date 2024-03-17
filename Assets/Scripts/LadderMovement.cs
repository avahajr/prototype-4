using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    [SerializeField] float speed = 5f;
    private bool isVine;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isVine && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vine"))
        {
            isVine = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Vine"))
        {
            isVine = false;
            isClimbing = false;
        }
    }
}