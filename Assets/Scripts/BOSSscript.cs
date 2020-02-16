using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSscript : MonoBehaviour
{
     private Animator anim;

    public GameObject bossblood;
    private Transform target;
    public static Vector2 localScale;
    private bool facingright;
    Rigidbody2D rb;


    float spawnrate=0.7f;
    //  float speed;
    float nextspawn =0;
     Vector2 projpos;
     public GameObject projright,projleft;



     float projcount,speed,direc;

     public static float healthamount;


     public GameObject scorekill,alterscorekill,carcass;
    

   
    // Start is called before the first frame update
    void Start()
    {
       
        healthamount=1f;
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        localScale = transform.localScale;
        rb=GetComponent<Rigidbody2D>();
         anim=GetComponent<Animator>();
         projcount=0;
         speed=2.7f;
         
    }

    // Update is called once per frame
    void Update()
    {
        if(healthamount<=0f)
        {
         Instantiate(carcass,gameObject.transform.position,Quaternion.identity);
         gameObject.SetActive(false);
         Instantiate(bossblood,gameObject.transform.position,Quaternion.identity);
         Instantiate(scorekill,gameObject.transform.position,Quaternion.identity);
         ScoreScript.Score+=500;
           
        }

        if(speed<2.1f)
        {
            speed+=0.01f;
        }

         if(Time.time>nextspawn && Character.isdead!=true && projcount!=4) 
        {
              anim.SetBool("isblinking",true);
              nextspawn = Time.time + spawnrate;
              projpos=transform.position;
                           if(facingright)
                            {
                            direc=localScale.x;
                              projpos+=new Vector2(+0.53f,-0.045f);
                              Instantiate(projright,projpos,Quaternion.identity);
                              projcount+=1;
                             // rb.velocity = new Vector2(localScale.x*speed,rb.velocity.y);
            
                            //bulletscript.velx=Mathf.Abs(bulletscript.velx);
                            }
                            else
                            {
                                direc=localScale.x;
                              projpos+=new Vector2(-0.53f,-0.045f);
                              Instantiate(projleft,projpos,Quaternion.identity);
                              projcount+=1;
                             // rb.velocity = new Vector2(localScale.x*speed,rb.velocity.y);
            
                               //bulletscript.velx=(-1)*Mathf.Abs(bulletscript.velx);
                            }              

        }
        

    }
    
    void charge()
    {
        
        if(facingright && projcount==4)
            {

                anim.SetBool("isblinking",false);
                
                rb.velocity = new Vector2(direc*speed,rb.velocity.y);
            }
            else if(!facingright && projcount==4)
            {
                anim.SetBool("isblinking",false);
               
                rb.velocity = new Vector2(direc*speed,rb.velocity.y);
            }


    }

     void LateUpdate()
    {
         if(target.position.x<transform.position.x)
        {
            facingright=false;
           
           
        }
        else if(target.position.x>=transform.position.x)              // Used to check the direction the player is in and move towards it
        {
            facingright=true;
           

        }
        if(((facingright) && (localScale.x<0)) || ((!facingright) && (localScale.x>0)))
        {
            localScale.x*=-1;
        }
        transform.localScale=localScale;

        
         if(projcount==4)
        {
            Invoke("charge",1f);
        }

      


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("bullet"))
        {
            SoundManagerScript.PlaySound("bosshit");
            healthamount-=0.08f;
            Destroy(col.gameObject,0f);
            if(healthamount>0)
            {
               Instantiate(alterscorekill,gameObject.transform.position,Quaternion.identity); 
               ScoreScript.Score+=10;
            }
        }

        if(col.gameObject.CompareTag("Player"))
        {
            HealthBarScript.health-=100f;
        }

        if(col.gameObject.CompareTag("wall-left"))
        {
             
             projcount=0;
        }
        if(col.gameObject.CompareTag("wall-right"))
        {
            
            projcount=0;
        }
    }
}
