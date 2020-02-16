using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorpiecescript : MonoBehaviour
{
   void Start()
   {
       Destroy(gameObject,1.23f);

   }
   void OnCollisionEnter2D(Collision2D col)
   {
       if(col.gameObject.CompareTag("enemy"))
           {
               Destroy(col.gameObject,0f);
             ScoreScript.Score+=10;
           }
       if(col.gameObject.CompareTag("ground"))
           {
               Destroy(gameObject,0f);
           }   
   }
}
