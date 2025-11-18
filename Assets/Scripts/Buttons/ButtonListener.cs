using UnityEngine;

public class ButtonListener : MonoBehaviour
{

    public TocarButton btn1;
    public TocarButton btn2;
    public TocarButton btn3;

    private int estadoBtn1;
    private int estadoBtn2;
    private int estadoBtn3;

    private int estadosUnidos;

    public int estadosJuntos()
    {
        estadoBtn1 = btn1.retornarEstado();
        estadoBtn2 = btn2.retornarEstado();
        estadoBtn3 = btn3.retornarEstado();

        if (estadoBtn1 == 1 && estadoBtn2 == 1 && estadoBtn3 == 1) 
        {
            estadosUnidos = 1;
            return estadosUnidos;
        } else
        {
            estadosUnidos = 0;
            return estadosUnidos;
        }
    }
}
