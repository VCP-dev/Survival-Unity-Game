using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topfloorscript : MonoBehaviour
{
    public GameObject topfloor,levtemp; 
   void OnTriggerEnter2D(Collider2D col)
   {
       if(col.gameObject.CompareTag("Player"))
       {
          Floorcounterscript.floornumber+=1;
           topfloor.SetActive(false);
           levtemp.SetActive(true);

       }
   }
}
