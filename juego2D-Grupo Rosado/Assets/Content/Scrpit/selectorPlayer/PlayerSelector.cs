using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{

    public Image[] selectionBoxes;
    public GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var img in this.selectionBoxes){
            img.gameObject.SetActive(false);
        }    

        this.Select(0);
    }

    public void Select(int index){
        foreach (var img in this.selectionBoxes){
            img.gameObject.SetActive(false);
        }

        this.selectionBoxes[index].gameObject.SetActive(true);
        PlayerStorage.playerPrefab = this.prefabs[index];
    }

}
