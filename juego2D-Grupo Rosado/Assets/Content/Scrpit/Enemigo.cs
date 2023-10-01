using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float cooldownAtaque;
    private bool puedeAtacar = true;
    private SpriteRenderer spriteRenderer;

 

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

 

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) {

 

            // Si no puede atacar salimos de la función.
            if(!puedeAtacar) return;

 

            // Desactivamos el ataque.
            puedeAtacar = false;

 

            // Cambiamos la opacidad del sprite.
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;

 

			// Perdemos una vida.
            GameManagerScript.Instance.PerderVida();

 

			// Aplicamos golpe al personaje.
			//other.gameObject.GetComponent<CharacterController>().AplicarGolpe();

            //Invoke("ReactivarAtaque", cooldownAtaque);
        }
    }

 

    void ReactivarAtaque() {
        puedeAtacar = true;

 

        // Cambiamos la opacidad del sprite.
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }
}