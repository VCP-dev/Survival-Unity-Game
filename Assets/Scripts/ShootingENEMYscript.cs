using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingENEMYscript : MonoBehaviour
{
    private Animator anim;
    private Transform target;
    public static Vector2 localScale;
    private bool facingright,incontactenemy;


    public GameObject ground;
    


    public GameObject projright,projleft,blood,spawnleft,spawnright;
    //Rigidbody2D rb;
    float spawnrate=0.7f;
    //  float speed;
    float nextspawn =0;
    Vector2 projpos;


    public static float health;


    public GameObject scorekill;
    


    // Start is called before the first frame update
    void Start()
    {
        incontactenemy=false;
        health=100f;
        facingright = true;
        anim=GetComponent<Animator>();
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        localScale = transform.localScale;
        //rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

   void LateUpdate()
   {
       if(target.position.x<transform.position.x)
        {
            facingright=false;
           
           
        }
        else if(target.position.x>=transform.position.x)              // Used to check the direction the player is in and face it
        {
            facingright=true;
           

        }
        if(((facingright) && (localScale.x<0)) || ((!facingright) && (localScale.x>0)))
        {
            localScale.x*=-1;
        }
        transform.localScale=localScale;

   }


    void Update()
    {
        if(incontactenemy)
        {
            health-=0.8f;
        }
        if(health<=0)
        {
            Destroy(gameObject,0f);
        }
        if(!ground.activeSelf)
        {
            gameObject.SetActive(false);
             Instantiate(blood,transform.position,Quaternion.identity);
        }
        
        if(Time.time>nextspawn && Character.isdead!=true) 
        {
              nextspawn = Time.time + spawnrate;
              projpos=transform.position;
                           if(facingright)
                            {
                              projpos+=new Vector2(+0.28f,+0.094f);
                              Instantiate(projright,projpos,Quaternion.identity);
                             // rb.velocity = new Vector2(localScale.x*speed,rb.velocity.y);
            
                            //bulletscript.velx=Mathf.Abs(bulletscript.velx);
                            }
                            else
                            {
                              projpos+=new Vector2(-0.28f,+0.096f);
                              Instantiate(projleft,projpos,Quaternion.identity);
                             // rb.velocity = new Vector2(localScale.x*speed,rb.velocity.y);
            
                               //bulletscript.velx=(-1)*Mathf.Abs(bulletscript.velx);
                            }              

        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject,0f);
            Instantiate(blood,transform.position,Quaternion.identity);
            Instantiate(scorekill,transform.position,Quaternion.identity);
            PREVleveldestroyer.enemycount+=1;
            ScoreScript.Score+=100;
        }
        if(col.gameObject.CompareTag("Player") && Character.hasknife==true)
        {
            Destroy(gameObject,0f);
            Instantiate(blood,transform.position,Quaternion.identity);
            Instantiate(scorekill,transform.position,Quaternion.identity);
            PREVleveldestroyer.enemycount+=1;
            ScoreScript.Score+=100;
        }
        if(col.gameObject.CompareTag("enemy"))
        {
            incontactenemy=true;
        }
        else
        {
            incontactenemy=false;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
          {
              if(!spawnleft.activeSelf && !spawnright.activeSelf)
              {
                  spawnleft.SetActive(true);
                  spawnright.SetActive(true);
              }

          } 
    }

        

}
