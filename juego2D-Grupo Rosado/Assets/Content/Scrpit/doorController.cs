using System.Collections;
using System.Collections.Generic;using UnityEngine;
using UnityEngine.SceneManagement;
public class doorController : MonoBehaviour
{    
    public string sceneNext;    
    private void OnCollisionEnter2D(Collision2D otherObject)
    {        
        if(otherObject.collider.tag=="Player") 
        {            
                SceneManager.LoadScene(sceneNext);       
        }       
    }
}
