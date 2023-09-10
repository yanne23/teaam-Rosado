using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSeleccionPersonaje : MonoBehaviour
{
    private int index;
    [SerializeField] private Image imagen;
    [SerializeField] private TextMeshProUGUI nombre;

    private GameManager gameManager;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameManager.Instance;
        index = PlayerPrefs.GetInt("JugadorIndex");

        if (index > gameManager.jugadores.Count - 1){
            index = 0;
        }
        cambiarPantalla();
    }

    // Update is called once per frame
    private void cambiarPantalla(){
        PlayerPrefs.SetInt("JugadorIndex", index);
        imagen.sprite = gameManager.personajes[index].imagen;
        nombre.text = gameManager.personajes[index].nombre;
    }

    public void bSiguiente(){
        if(index == gameManager.personajes.Count - 1){
            index = 0;
        }else{
            index++;
        }
        cambiarPantalla();
    }

    public void bAnterior(){
        if(index == 0){
            index = gameManager.personajes.Count - 1;
        }else{
            index--;
        }
        cambiarPantalla();
    }

    public void iniciarJuego(){
        SceneManagement.LoadScene(SceneManagement.GetActiveScene().buildIndex + 1);
    }
}
