using UnityEngine;
using UnityEngine.SceneManagement;

public class AtraparCoin : MonoBehaviour
{
    private int contador;

    private void OnTriggerEnter2D(Collider2D tocarMoneda)
    {
        if (tocarMoneda.gameObject.CompareTag("Coin"))
        {
            contador += 1;
            Destroy(tocarMoneda.gameObject);
        }
    }

    public int GetContadorMonedas()
    {
        return contador;
    }
}
