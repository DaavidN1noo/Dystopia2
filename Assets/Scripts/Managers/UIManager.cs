using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void VolverAmenu()
    {
        SceneManager.LoadScene("menuPrincipal");
    }

    public void IrAJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
