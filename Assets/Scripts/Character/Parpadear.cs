using UnityEngine;

public class Parpadear : MonoBehaviour
{
    public Animator animator;
    public float minTiempo = 2f;
    public float maxTiempo = 5f;
    private float siguienteParpadeo;

    void Start()
    {
        CalcularSiguienteParpadeo();
    }

    void Update()
    {
        if (Time.time >= siguienteParpadeo)
        {
            animator.Play("static", -1, 0f);
            CalcularSiguienteParpadeo();
        }
    }

    void CalcularSiguienteParpadeo()
    {
        siguienteParpadeo = Time.time + Random.Range(minTiempo, maxTiempo);
    }
}
