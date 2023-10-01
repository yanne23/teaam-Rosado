using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    public int EnemigosTotales { get { return enemigosTotales; } }
    private int enemigosTotales;
    
    public void SumarPuntos(int puntosASumar){
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }

    public void SumarEnemigos(int enemigosASumar){
        enemigosTotales += enemigosASumar;
        Debug.Log(enemigosTotales);
    }


}
