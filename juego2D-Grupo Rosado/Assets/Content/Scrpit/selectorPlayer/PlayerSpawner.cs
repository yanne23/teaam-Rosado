using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;

public class PlayerSpawner : MonoBehaviour
{
    //public CinemachineVirtualCamera cinemachineCamera;
    [SerializeField] List<GameObject> players;
    // Start is called before the first frame update
    void Start()
    {
        
        var indice = PlayerPrefs.GetInt("indicePlayer");
        //cinemachineCamera.Follown Instantiate(players[indice], transform);



    }

    
}
