using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    
    public void SumarPuntos(int puntosASumar){
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }


}
