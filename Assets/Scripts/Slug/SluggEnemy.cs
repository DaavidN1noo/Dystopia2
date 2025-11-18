using UnityEngine;

public class SluggEnemy : MonoBehaviour
{
    public float velocidad = 2f;
    public float distanciaMinima = 0.5f;
    
    Transform player;
    Rigidbody2D rb;
    float escalaX;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        escalaX = Mathf.Abs(transform.localScale.x);
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
    
    void FixedUpdate()
    {
        if (player == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            return;
        }
        
        float distancia = Vector2.Distance(transform.position, player.position);
        
        if (distancia > distanciaMinima)
        {
            float dirX = player.position.x - transform.position.x;
            
            Vector2 direccion = new Vector2(dirX, 0);
            direccion.Normalize();
            
            rb.linearVelocity = new Vector2(direccion.x * velocidad, rb.linearVelocity.y);
            
            if (dirX > 0)
            {
                transform.localScale = new Vector3(-escalaX, transform.localScale.y, transform.localScale.z);
            }
            else if (dirX < 0)
            {
                transform.localScale = new Vector3(escalaX, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}