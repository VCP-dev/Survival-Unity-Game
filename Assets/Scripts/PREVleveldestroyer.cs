using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PREVleveldestroyer : MonoBehaviour
{

   // public GameObject prevlevel;
    public GameObject ladder;

    //Vector2 wheretospawn;
    public GameObject FLOOR;
    public Transform level;

   // public GameObject level;

    public static int enemylimit;


     public static int enemycount=0;

     Vector2 wheretospawn,crateorig;

     public GameObject shooter;
     public GameObject crate,knifeadder;
     public static float var,diff=1f;


      int floorstillboss,bossfloorlevel;
     public GameObject bosslevel;

     public Transform floorp1,floorp2,floorp3,floorp4;
     public GameObject floorpiece;

    // public static float floorstillboss;


    
    // public Transform bossorigpos;
      

     // Start is called before the first frame update
    void Start()
    {   
       if(Random.Range(2,6)<3.56f)
               {
                knifeadder.SetActive(true);
               }
             else
               {
                knifeadder.SetActive(false);
               }
        bossfloorlevel=Random.Range(4,7);
        floorstillboss=0;
        shooter.SetActive(false);
        crate.SetActive(false);
        enemylimit=Random.Range(9,14);
        enemycount=0;
      // Ladderspawnerscript.spawned=false;
        FLOOR.SetActive(true);
        spawnshooter();
        //floorstillboss=0;
       // BOSS.SetActive(false);
       /*  bossback.SetActive(false);
        bosshealth.SetActive(false);
        bosstext.SetActive(false);*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if(enemycount>=enemylimit)
        {
            endfloor();

        }
       /*  if(BossScript.defeated==true)
        {
            floorstillboss=0;
            BossScript.defeated=false;
        }*/
    }

    public void endfloor()
    {       Invoke("dropplayer",1.7f);
            wheretospawn=level.position;

           // wheretospawn=transform.parent.position;
            wheretospawn=new Vector2(transform.position.x + diff ,transform.position.y-13.4f);
            crate.SetActive(true);
            crate.transform.position=new Vector2(Random.Range(FLOOR.transform.position.x-2,FLOOR.transform.position.x+2),crate.transform.position.y);
            enemylimit=Random.Range(9,14);
            var=Random.Range(2,8);
            enemycount=0;
            diff+=0.0423f;
            floorstillboss+=1;
            
    } 

   /*  void spawnboss()
    {
         //BOSS.SetActive(true);
        // BOSS.transform.position=bossorigpos.position;
        // BOSS.transform.position=new Vector2(FLOOR.transform.position.x+BossScript.bossorigposdiffX,FLOOR.transform.position.y+BossScript.bossorigposdiffY);
        
         BossScript.defeated=false;
    }*/

    void spawnshooter()
    {
        
        if(var<4.7)
        {
            shooter.SetActive(false);
        }
        else
        {
            shooter.SetActive(true);
            ShootingENEMYscript.health=100f;
        }
        
    }

    void dropplayer()
    {
        FLOOR.SetActive(false);
        Instantiate(floorpiece,floorp1.position,Quaternion.identity);
        Instantiate(floorpiece,floorp2.position,Quaternion.identity);
        Instantiate(floorpiece,floorp3.position,Quaternion.identity);
        Instantiate(floorpiece,floorp4.position,Quaternion.identity);
       
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            enemycount=0;
           // Destroy(prevlevel,0f);
           // Destroy(ladder,0f);
            //Leveladderscript.generated=false;
             StartCoroutine(spawnlevel());
            // generated=true;
            crate.SetActive(false);
             
            // Ladderspawnerscript.spawned=false;
             FLOOR.SetActive(true);
             return;   


            
           
        }
        if(col.CompareTag("enemy"))
        {
            Destroy(col.gameObject,0f);
        }
    }

     IEnumerator spawnlevel()
    {
        if(floorstillboss==bossfloorlevel)
        {
            Instantiate(bosslevel,wheretospawn,Quaternion.identity);
            /*  bossback.SetActive(true);
             bosshealth.SetActive(true);
             bosstext.SetActive(true);*/

            Floorcounterscript.floornumber+=1;
             Destroy(level.gameObject,0f);
        

        }//wheretospawn=new Vector2(transform.position.x+3.3361f,transform.position.y-8.2f);
        else
        {
        level.position=wheretospawn;
         Floorcounterscript.floornumber+=1;
         spawnshooter();
          if(Random.Range(2,6)<3.27f)
               {
                knifeadder.SetActive(true);
               }
             else
               {
                knifeadder.SetActive(false);
               }

       

        }
       
        crate.SetActive(false);
       
    
        yield return new WaitForSeconds(1);

    }



}
