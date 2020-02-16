using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRATEscript : MonoBehaviour
{

    public GameObject scorekill;


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(HealthBarScript.health<70)
            {
                HealthBarScript.health+=30;
            }
            else
            {
                HealthBarScript.health=100;
            }
            
            Character.totalammo+=10;
             ScoreScript.Score+=30;
              gameObject.SetActive(false);
               SoundManagerScript.PlaySound("cratesound");
              Instantiate(scorekill,transform.position,Quaternion.identity);
        }
           
           

        if(col.gameObject.CompareTag("enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    
}
