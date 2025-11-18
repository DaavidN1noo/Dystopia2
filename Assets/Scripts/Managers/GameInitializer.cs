using UnityEngine;


public class GameInitializer : MonoBehaviour
{
    private void Start()
    {
        // Asegurar que el LivesManager existe al iniciar el juego
        if (LivesManager.Instance == null)
        {
            GameObject livesManagerObj = new GameObject("LivesManager");
            livesManagerObj.AddComponent<LivesManager>();
            Debug.Log("LivesManager inicializado");
        }
    }
}



