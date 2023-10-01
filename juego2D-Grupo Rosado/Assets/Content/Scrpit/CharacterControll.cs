using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public float fuerzaGolpe;
    public float saltosMaximos;
    public LayerMask capaSuelo;
    public AudioClip sonidoSalto;

    ///////////////////////

    RaycastHit2D hit;
    public Vector3 v3;
    public LayerMask layer;
    public float distance;

    ////////////////
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = false;
    private float saltosRestantes;
    private Animator animator;
    private bool puedeMoverse = true;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
        Detector_Plataforma();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void ProcesarSalto()
    {
        if(EstaEnSuelo())
        {
            saltosRestantes = saltosMaximos;
        }

 

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            saltosRestantes--;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }


    void ProcesarMovimiento()
    {
        // Si no puede moverse, salimos de la funcion
        if(puedeMoverse == false) {
            return;
        }
 

        // Lógica de movimiento
        float inputMovimiento = Input.GetAxis("Horizontal");

 

        if(inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

 

        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);

        GestionarOrientacion(inputMovimiento);
    }
    
    void GestionarOrientacion(float inputMovimiento)
    {
        // Si se cumple condición
        if( (mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0) )
        {
            // Ejecutar código de volteado
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    bool CheckCollision{
        get{
            hit = Physics2D.Raycast(transform.position+v3, transform.up*-1, distance, layer);
            return hit.collider!= null;
        }
    }

    public void Detector_Plataforma(){
        if(CheckCollision){
            transform.parent = hit.collider.transform;
        }else{
            transform.parent = null;
        }
    }

    void OnDrawGizmos(){
         Gizmos.DrawRay(transform.position+v3, Vector3.up*-1*distance);
    }

    public void AplicarGolpe() {

 

        puedeMoverse = false;

 

        Vector2 direccionGolpe;

 

        if(rigidBody.velocity.x > 0)
        {
            direccionGolpe = new Vector2(-1, 1);
        } else {
            direccionGolpe = new Vector2(1, 1);
        }

 

        rigidBody.AddForce(direccionGolpe * fuerzaGolpe);

 

        StartCoroutine(EsperarYActivarMovimiento());
    }

   IEnumerator EsperarYActivarMovimiento() {
        // Esperamos antes de comprobar si esta en el suelo.
        yield return new WaitForSeconds(0.1f);

 

        while(!EstaEnSuelo()) {
            // Esperamos al siguiente frame.
            yield return null;
        }

 

        // Si ya está en suelo activamos el movimiento.
        puedeMoverse = true;
    }
}