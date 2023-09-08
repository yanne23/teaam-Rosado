using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InicioJugador : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;
    //public List<Personajes> personajes;

    public void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        GameObject playerClone = Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);
        cinemachineCamera.Follow = playerClone.transform;
        
    }

    //private void Start(){
        //int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        //Instantiate(GameManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);
    //}


}
