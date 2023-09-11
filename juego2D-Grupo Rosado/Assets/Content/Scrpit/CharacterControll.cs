using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public float saltosMaximos;
  
    public LayerMask capaSuelo;

    ///////////////////////

    RaycastHit2D hit;
    public Vector3 v3;
    public LayerMask layer;
    public float distance;

    ////////////////
    private Rigidbody2D rigiBody;
    private BoxCollider2D boxCollider;
    private bool mirandoDerecha = false;
    private float saltosRestantes;
  
    private Animator animator;

    public void Start(){
        rigiBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        saltosRestantes = saltosMaximos;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcesandoMovimiento();
        ProcesarSalto();
        Detector_Plataforma();
    }

    bool EstaEnSuelo(){

        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.1f, capaSuelo);
        return raycastHit.collider != null;  //OverlapCircle(transform.position, 0.5f, LayerMask.GetMask("Ground"));
    }

    void ProcesarSalto(){

        if(EstaEnSuelo()){
            saltosRestantes = saltosMaximos;
        }

        if(Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0){
            saltosRestantes--;
            rigiBody.velocity = new Vector2(rigiBody.velocity.x, 0f);
            rigiBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    
    }


    void ProcesandoMovimiento()
    {
       //logica del movimiento
       float inputMovimiento = Input.GetAxis("Horizontal");

        if(inputMovimiento != 0f){
            animator.SetBool("isRunning", true);
        }else{
            animator.SetBool("isRunning", false);
        }

       Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

       rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);

       GstionarOrientation(inputMovimiento);
    }

    
    void GstionarOrientation(float inputMovimiento){
        if((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0)){
            mirandoDerecha =!mirandoDerecha;
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
}