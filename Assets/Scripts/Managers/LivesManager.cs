using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    
    public static LivesManager Instance { get; private set; }
    private int vidas = 3;
    private const int VIDAS_INICIALES = 3;
    private GameOverUI gameOverUI;
    public int Vidas => vidas;
    
    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
           
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        
        gameOverUI = FindObjectOfType<GameOverUI>();
    }
    
    // método para perder una vida
    public void PerderVida()
    {
        
        vidas--;
        
        
        Debug.Log("Vidas restantes: " + vidas);
        
       
        if (vidas <= 0)
        {
            vidas = 0;
            
            MostrarGameOver();
        }
    }
    
    // método para reiniciar las vidas a 3
    public void ReiniciarVidas()
    {
        vidas = VIDAS_INICIALES;
    }
    
    // método para mostrar el gameover
    private void MostrarGameOver()
    {
       
        if (gameOverUI == null)
        {
            gameOverUI = FindObjectOfType<GameOverUI>();
        }
        
        
        if (gameOverUI != null)
        {
            gameOverUI.MostrarGameOver();
        }
        else
        {
            
            Debug.LogWarning("No se encontró GameOverUI. Reiniciando escena...");
            ReiniciarEscena();
        }
    }
    
    // método para reiniciar la escena después de un tiempo
    public void ReiniciarEscena()
    {
        
        ReiniciarVidas();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

