using UnityEngine;

public class Trampa : MonoBehaviour
{
    // Variable para evitar que se reste vida múltiples veces muy rápido
    private bool puedePerderVida = true;
    private float tiempoEntreMuertes = 0.5f;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si toca una trampa o enemigo
        if (collision.gameObject.CompareTag("Trampa") || collision.gameObject.CompareTag("Enemy"))
        {
            PerderVida();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si toca una trampa o enemigo
        if (collision.gameObject.CompareTag("Trampa") || collision.gameObject.CompareTag("Enemy"))
        {
            PerderVida();
        }
    }
    
    // Método para perder una vida
    private void PerderVida()
    {
        // Evitar perder múltiples vidas muy rápido
        if (!puedePerderVida)
        {
            return;
        }
        
        // Asegurar que el LivesManager existe
        AsegurarLivesManager();
        
        // Restar una vida si el LivesManager existe
        if (LivesManager.Instance != null)
        {
            LivesManager.Instance.PerderVida();
        }
        
        // Respawnear al punto de inicio
        Respawnear();
        
        // Bloquear perder vida por un tiempo
        puedePerderVida = false;
        Invoke(nameof(ReactivarPerderVida), tiempoEntreMuertes);
    }
    
    // Método para respawnear al punto de inicio
    private void Respawnear()
    {
        GameObject puntoInicio = GameObject.FindWithTag("puntoInicio");
        if (puntoInicio != null)
        {
            transform.position = puntoInicio.transform.position;
        }
        else
        {
            Debug.LogWarning("No se encontró un objeto con el tag 'puntoInicio'");
        }
    }
    
    // Método para asegurar que el LivesManager existe
    private void AsegurarLivesManager()
    {
        // Si no existe el LivesManager, crearlo
        if (LivesManager.Instance == null)
        {
            GameObject livesManagerObj = new GameObject("LivesManager");
            livesManagerObj.AddComponent<LivesManager>();
            Debug.Log("LivesManager creado automáticamente");
        }
    }
    
    // Método para reactivar la posibilidad de perder vida
    private void ReactivarPerderVida()
    {
        puedePerderVida = true;
    }
}
