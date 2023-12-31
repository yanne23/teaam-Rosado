using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaScript : MonoBehaviour
{

    public int valor = 1;
    public GameManagerScript gameManager;
    public AudioClip moneda;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
            VolumenScript.Instance.ReproducirSonido(moneda);
        }
        
    }
}
 