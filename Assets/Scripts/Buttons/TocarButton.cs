using JetBrains.Annotations;
using UnityEngine;

public class TocarButton : MonoBehaviour
{
    //estado del botón
    private int btnStatus;
    public int btnID;

    //Sprites del botón
    public Sprite btnOn;
    public Sprite btnOff;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = btnOff;
    }

    private void OnMouseDown()
    {
        //apagado = 0
        //encendido = 1

        if (btnStatus == 0)
        {
            btnStatus = 1;
            sr.sprite = btnOn;
            print("Botón " + btnID + " ahora está en estado: " + btnStatus);
        }
        else
        {
            btnStatus = 0;
            sr.sprite = btnOff;
            print("Botón " + btnID + " ahora está en estado: " + btnStatus);
        }
    }

    //retornar el estado
    public int retornarEstado()
    {
        return btnStatus;
    }
}

