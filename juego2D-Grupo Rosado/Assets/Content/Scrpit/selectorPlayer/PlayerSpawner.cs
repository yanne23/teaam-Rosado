using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(PlayerStorage.playerPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);

    }

    
}
