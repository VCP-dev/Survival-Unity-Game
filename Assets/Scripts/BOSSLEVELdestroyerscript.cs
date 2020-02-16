using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSLEVELdestroyerscript : MonoBehaviour
{

    public GameObject BOSS;
    public GameObject ground;

    public GameObject level,crate,currentbosslevel;

  
     Vector2 wheretospawn;

      public GameObject floorp1,floorp2,floorp3,floorp4;
     
   
    // Start is called before the first frame update
    void Start()
    {
        crate.SetActive(false);
        BOSS.SetActive(true);
        crate.transform.position=new Vector2(Random.Range(ground.transform.position.x-3,ground.transform.position.x+3),crate.transform.position.y);
        //level=GameObject.FindGameObjectWithTag("LEVEL").GetComponent<GameObject>();
        floorp1.SetActive(false);
        floorp2.SetActive(false);
        floorp3.SetActive(false);
        floorp4.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(BOSSscript.healthamount<=0)
        {
             
            endfloor();
            
        }
    }

  

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
             PREVleveldestroyer.enemycount=0;
             wheretospawn=transform.parent.position;
             wheretospawn=new Vector2(transform.position.x + PREVleveldestroyer.diff,transform.position.y-13.4f);
          
             StartCoroutine(spawnlevel());
             crate.SetActive(false);
             ground.SetActive(true);
             
             return;   
           
           
        }
        
    }

     IEnumerator spawnlevel()
    {
        //wheretospawn=new Vector2(transform.position.x+3.3361f,transform.position.y-8.2f);
       // level.SetActive(true);
        //spawnshooter();
        Instantiate(level,wheretospawn,Quaternion.identity);
        crate.SetActive(false);
        level.transform.position=wheretospawn;
        Destroy(currentbosslevel,0f);
        Floorcounterscript.floornumber+=1;
        Character.totalammo+=10;
        yield return new WaitForSeconds(1);

    }

     public void endfloor()
    {      
            Invoke("dropplayer",1.6f);
                       
           // crate.SetActive(true);
            
          
            // level.transform.position=wheretospawn;
            PREVleveldestroyer.enemylimit=Random.Range(9,14);
            PREVleveldestroyer.var=Random.Range(2,8);
            PREVleveldestroyer.enemycount=0;
            
            
            //floorstillboss+=1;

    } 

     void dropplayer()
    {
        ground.SetActive(false);
        floorp1.SetActive(true);
        floorp2.SetActive(true);
        floorp3.SetActive(true);
        floorp4.SetActive(true);
       
    }




}
