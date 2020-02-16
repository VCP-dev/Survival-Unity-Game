using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcessEnemyRemover : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D col)
   {
       if(col.CompareTag("enemy"))
       {
           Destroy(col.gameObject,0f);
       }
   } 

   
}
