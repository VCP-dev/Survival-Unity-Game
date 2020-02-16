using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    float speed;
    private Animator anim;
    private Transform target;
    private Vector2 localScale;
    private bool facingright,contact;
    Rigidbody2D rb;


    public GameObject scorekill;
      
    public GameObject blood,eye,tophalf,bottomhalf;
        // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        localScale = transform.localScale;
        rb=GetComponent<Rigidbody2D>();
        contact = false;
        speed=/*2.8f;*/2.97f;  
        

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("ismoving",true);
        /* if( Vector2.Distance(transform.position,target.position)>0.9 )
         {
         //transform.position =  Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
         

         }*/
         
         if(contact && Pausemenu.gameispaused==false)
         {
              
             HealthBarScript.health-=.73f;

         }
        /* if(Ladderspawnerscript.spawned==true)
        {
            speed=0.21f;
        } */

        if(speed</*3.0*/ 3.19)
        {
        speed+=0.01f;
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
         rb.velocity = new Vector2(localScale.x*speed,rb.velocity.y);


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("bullet") || col.gameObject.CompareTag("projectile") || col.gameObject.CompareTag("floorpiece"))
        {
            killenemy();
        }

        if(col.gameObject.CompareTag("Player") && Character.hasknife==true)
        {
             killenemy();
             if(HealthBarScript.health<100)
             {
                 HealthBarScript.health+=0.5f;

             }
             
        }
       
    
        if(col.gameObject.CompareTag("Player"))
        {
            //HealthBarScript.health-=10f;
            contact=true;
        }
        else
        {
            contact = false;

        }
    
       
    }

    void OnTriggerEnter2D(Collider2D col)                // When the player jumps on an enemy
    {
        if(col.gameObject.CompareTag("Player") )
        {
            killenemy();
           
        }
    }

    void killenemy()
    {
            SoundManagerScript.PlaySound("enemykilled");
            Destroy(gameObject,0f);
            Instantiate(blood,transform.position,Quaternion.identity);
             Instantiate(scorekill,transform.position,Quaternion.identity);
            Instantiate(eye,transform.position,Quaternion.identity);
            Instantiate(tophalf,transform.position,Quaternion.identity);
            Instantiate(bottomhalf,transform.position,Quaternion.identity);
            PREVleveldestroyer.enemycount+=1;
           /*  if(StaminaBarScript.stamina<100)
            {
            StaminaBarScript.stamina+=0.07f;
            }*/
            ScoreScript.Score+=10;

    }

    

    

}
