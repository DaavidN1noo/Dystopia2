using UnityEngine;
using UnityEngine.SceneManagement;

public class moviimiento2d : MonoBehaviour

{
    //movilidad y controles
    public Controles controles;

    public Vector2 direccion;

    public Rigidbody2D rb2D;

    public float velocidadMovimiento;

    public bool mirandoDerecha = true;

    public float fuerzaSalto;

    //control de suelo
    public LayerMask queEsSuelo; 
    public Transform controladorSuelo; //donde esta el suelo
    public Vector3 dimensionesCaja; //detector del suelo
    public bool enSuelo;

    //Control de salto para bloquear en AutoJump
    public bool saltoBloqueado = false;
    

    //Animaciones
    public Animator animator;

    private void Awake()
    {
        controles = new();
    }

    private void OnEnable()
    {
        controles.Enable();
        controles.movimiento.saltar.started += _=>Saltar();
        
    }

    private void OnDisable()
    {
        controles.Disable();
        controles.movimiento.saltar.started -= _=>Saltar();
    }

    private void Update()
    {
        direccion = controles.movimiento.mover.ReadValue<Vector2>();
        AjustarRotación(direccion.x);

        //Animator Moverse
        animator.SetFloat("movement", Mathf.Abs(direccion.x));

        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        //Animator saltar
        animator.SetBool("enSuelo", enSuelo);

        if (enSuelo)
        {
            saltoBloqueado = false;
        }
    }

    public void FixedUpdate()
    {
        rb2D.linearVelocity = new Vector2(direccion.x * velocidadMovimiento, rb2D.linearVelocity.y);
    }

    private void AjustarRotación(float direccionX)
    {
        if(direccionX > 0 && !mirandoDerecha)
        {
            Girar();
        } else if(direccionX < 0 && mirandoDerecha)
        {
            Girar();
        }
    }
    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Saltar()
    {
        if (saltoBloqueado) return;

        if (enSuelo)
        {
            rb2D.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
