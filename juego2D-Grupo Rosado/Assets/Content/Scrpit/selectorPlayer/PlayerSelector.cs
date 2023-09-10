using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using Cinemachine;


public class PlayerSelector : MonoBehaviour
{
    //public CinemachineVirtualCamera cinemachineCamera;

    [SerializeField] List<Sprite> players;

    Image playerSelect;
    int indicePlayer = 0;

    void Start()
    {
        //cinemachineCamera.gameObject.SetActive(false);
        playerSelect = GetComponent<Image>();
        playerSelect.sprite = players[indicePlayer];
    }

    public void pSiguiente(){
        indicePlayer++;
        if(indicePlayer >= players.Count){
            indicePlayer = 0;
        }
        ActualizarImg(indicePlayer);
    }

    public void pAnterior(){
        indicePlayer--;
        if(indicePlayer < 0){
            indicePlayer = players.Count - 1;
        }
        ActualizarImg(indicePlayer);
    }

    private void ActualizarImg(int indice){
        playerSelect.sprite = players[indice];
    }

    public void jugar(){
        PlayerPrefs.SetInt("indicePlayer", indicePlayer);
        SceneManager.LoadScene("Nivel1Scene");
        //cinemachineCamera.gameObject.SetActive(false)
        //cinemachineCamera.Follow = players[indice], transform;
    }

    
}
