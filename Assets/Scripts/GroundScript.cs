using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{

    public GameObject spawn1,spawn2;

   
    void Start()
    {
        gameObject.SetActive(true);
       
        

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && PREVleveldestroyer.enemycount<=PREVleveldestroyer.enemylimit)
        {
            StartCoroutine(SPAWN());

        }
    }

    IEnumerator SPAWN()
    {
        spawn1.SetActive(true);
        spawn2.SetActive(true);
        yield return null;
    }

    
}
