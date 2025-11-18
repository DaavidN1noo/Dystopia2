using UnityEngine;

public class BlockDown : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       rb.bodyType= RigidbodyType2D.Dynamic;
       rb.gravityScale = 3;
    }
}
