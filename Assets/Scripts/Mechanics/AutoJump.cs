using UnityEngine;

public class AutoJump : MonoBehaviour
{
    
    public float autoJumpXForce = 4f;
    public float autoJumpYForce = 15f;
    Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger detectado con: " + collision.name);
        if (collision.CompareTag("Player"))
        {
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            moviimiento2d mov = collision.GetComponent<moviimiento2d>();

            mov.saltoBloqueado = true;
            rb.AddForce(new Vector2(autoJumpXForce, autoJumpYForce), ForceMode2D.Impulse);
        }
    }
}
