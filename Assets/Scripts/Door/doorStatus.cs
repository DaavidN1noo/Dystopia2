using UnityEngine;
using UnityEngine.SceneManagement;

public class doorStatus : MonoBehaviour
{
    public ButtonListener estadosUnidos;

    private int estadoBotones;

    //sprites
    public Sprite doorOpen;
    public Sprite doorSemiOpen;
    public Sprite doorClose;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = doorClose;
    }

    private void Update()
    {
        estadoBotones = estadosUnidos.estadosJuntos();

        if (estadoBotones == 1) 
        { 
            sr.sprite = doorSemiOpen;
        } else
        {
            sr.sprite= doorClose;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (estadoBotones == 1)
        {
            sr.sprite = doorOpen;

            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("ThanksScreen");
            }

        } else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                print("debes de presionar todos los botónes para poder salir");
            }
        }
    }
}

