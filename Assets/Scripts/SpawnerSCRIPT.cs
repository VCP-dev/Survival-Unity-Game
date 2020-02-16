using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSCRIPT : MonoBehaviour
{

   
    public  GameObject enemy;
    
    //Vector2 wheretospawn;
    float spawnrate;
    float nextspawn =0;
    public bool spawner1=false;
    public bool spawner2=false;

   
   
    
   
    // Start is called before the first frame update
    void Start()
    {
        
       // gameObject.SetActive(false);
        

        if(spawner1==true)
        {
        spawnrate=Random.Range(1.03f,1.22f);  //  Random.Range(1.02f,1.22f);  
        }
        if(spawner2==true)
        {
        spawnrate=Random.Range(.99f,1.19f); // Random.Range(0.98f,1.19f);  
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(/* Ladderspawnerscript.spawned==true ||*/ PREVleveldestroyer.enemycount>=PREVleveldestroyer.enemylimit)
        {
           
           gameObject.SetActive(false);
           
           
        }
       else if((Time.time > nextspawn) && Character.isdead==false )
        {
            nextspawn = Time.time + spawnrate;
           
            Instantiate(enemy,transform.position,Quaternion.identity);
             if(spawnrate> 0.91f /*1.01f*/)
              {
               StartCoroutine(decreaserate());
              }
            
        }
       
        
       
    }

    IEnumerator decreaserate()
    {
        spawnrate-=0.005f;
        yield return null;
    }

    

   
}
