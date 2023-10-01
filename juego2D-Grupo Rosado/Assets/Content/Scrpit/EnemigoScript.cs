using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoScript : MonoBehaviour
{
    public int valor = 1;
    public GameManagerScript gameManager1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            gameManager1.SumarEnemigos(valor);
            Destroy(this.gameObject);
        }
        
    }
}
