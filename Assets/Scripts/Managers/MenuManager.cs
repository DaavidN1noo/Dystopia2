using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // el contador de monedas
    [SerializeField]
    TextMeshProUGUI monedas;
    private AtraparCoin monedaScript;

    // el contador de botones
    [SerializeField]
    TextMeshProUGUI botones;
    public TocarButton btn1;
    public TocarButton btn2;
    public TocarButton btn3;
    private int estadoBtn1;
    private int estadoBtn2;
    private int estadoBtn3;
    private int contadorBotones;

    // el contador de vidas
    [SerializeField]
    TextMeshProUGUI vidas;

    
    private void Start()
    {
        monedaScript = FindObjectOfType<AtraparCoin>();

        if (monedas == null)
        {
            monedas.text = "0";
            botones.text = "0";
        }
        
    }

    private void Update()
    {
        ActualizarMonedas();
        ActualizarBotones();
        ActualizarVidas();
    }

    private void ActualizarMonedas()
    {
        if(monedaScript != null && monedas != null) {
            int cantidadActual = monedaScript.GetContadorMonedas();

            monedas.text = cantidadActual.ToString();
        
    }
    }

    private void ActualizarBotones()
    {
        contadorBotones = 0;

        estadoBtn1 = btn1.retornarEstado();
        estadoBtn2 = btn2.retornarEstado();
        estadoBtn3 = btn3.retornarEstado();

        if (estadoBtn1 == 1) contadorBotones++;
        if (estadoBtn2 == 1) contadorBotones++;
        if (estadoBtn3 == 1) contadorBotones++;

        String contadorTexto = contadorBotones.ToString();

        botones.text = contadorTexto + "/3";

        if(contadorBotones == 3)
        {
            String texto = " Busca la Salida";
            botones.text =  contadorTexto + texto;
        }
    }

    private void ActualizarVidas()
    {
        // si tenemos el texto de vidas y el LivesManager existe
        if (vidas != null && LivesManager.Instance != null)
        {
            
            int vidasActuales = LivesManager.Instance.Vidas;
            
            
            vidas.text = "Lives: " + vidasActuales.ToString();
        }
    }
}