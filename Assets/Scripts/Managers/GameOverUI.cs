using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // Referencia al texto que mostrará "GAME OVER"
    [SerializeField]
    private TextMeshProUGUI textoGameOver;
    
    // Panel o GameObject que contiene el mensaje (opcional, para mostrar/ocultar)
    [SerializeField]
    private GameObject panelGameOver;
    
    // Tiempo en segundos antes de reiniciar la escena
    [SerializeField]
    private float tiempoAntesDeReiniciar = 3f;
    
    private void Start()
    {
        // Al iniciar, ocultar el mensaje de GAME OVER
        OcultarGameOver();
    }
    
    // Método para mostrar GAME OVER
    public void MostrarGameOver()
    {
        // Si tenemos un panel, activarlo
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
        
        // Si tenemos un texto, mostrar "GAME OVER"
        if (textoGameOver != null)
        {
            textoGameOver.text = "GAME OVER";
            textoGameOver.gameObject.SetActive(true);
        }
        else
        {
            // Si no hay texto asignado, mostrar en consola
            Debug.Log("GAME OVER");
        }
        
        // Esperar un tiempo y luego reiniciar
        Invoke(nameof(ReiniciarEscena), tiempoAntesDeReiniciar);
    }
    
    // Método para ocultar GAME OVER
    private void OcultarGameOver()
    {
        // Ocultar el panel si existe
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(false);
        }
        
        // Ocultar el texto si existe
        if (textoGameOver != null)
        {
            textoGameOver.gameObject.SetActive(false);
        }
    }
    
    // Método para reiniciar la escena
    private void ReiniciarEscena()
    {
        // Reiniciar las vidas si el LivesManager existe
        if (LivesManager.Instance != null)
        {
            LivesManager.Instance.ReiniciarVidas();
        }
        
        // Cargar la escena actual de nuevo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



