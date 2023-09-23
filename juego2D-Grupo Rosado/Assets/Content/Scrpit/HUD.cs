using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour
{
    public GameManagerScript gameManager;
    public TextMeshProUGUI puntos;

     public int counterTime= 300;
    public TextMeshProUGUI counterTimeText;

    public int enemy = 0;
    public TextMeshProUGUI enemyText;


    void Update()
    {
        puntos.text = gameManager.PuntosTotales.ToString();
    }

     void Start()
    {
        counterTimeText.text = string.Format("{0}", counterTime);
        InvokeRepeating("TimeCounter", 1f, 1f);
    }

    public void EnemyCounter(){
        enemy++;
        enemyText.text = string.Format("{0}", enemy);
    }

    public void TimeCounter(){
        counterTime--;
        if (counterTime<0){
            //desabilitar al player
            //enviar el mensaje de game over (habilitarlo)
            Debug.Log("Game Over");
        }
        counterTimeText.text = string.Format("{0}", counterTime);
    }


}
