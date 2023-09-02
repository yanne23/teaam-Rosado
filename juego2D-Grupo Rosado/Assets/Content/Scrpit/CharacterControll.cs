using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    private Rigidbody2D rigiBody;
    private bool mirandoDerecha = true;

    public void Start(){
        rigiBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcesandoMovimiento();
        ProcesarSalto();
    }

    void ProcesarSalto(){
        if(Input.GetKeyDown(KeyCode.Space)){
            rigiBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    
    }

    void ProcesandoMovimiento()
    {
       //logica del movimiento
       float inputMovimiento = Input.GetAxis("Horizontal");
       Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

       rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);

       GstionarOrientation(inputMovimiento);
    }

    //orientation
    void GstionarOrientation(float inputMovimiento){
        if((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0)){
            mirandoDerecha =!mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    } //
}
