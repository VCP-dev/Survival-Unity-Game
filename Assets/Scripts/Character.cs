using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;



                               //                 Controls are currently set for pc



/*As of now for pc
'Z' is the key to shoot which can be held down for rapid fire
'X'is the key to reload
Movement is with direction keys

 */



public class Character : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float climbspeed=4f;
    private float dirX;
    private bool facingRight=true;
    private bool isgrounded,isreloading;
    private Vector2 localScale;

    public GameObject bulletleft,bulletright;
    Vector2 bulletpos;
    public float firerate=0.1f;
    public float nextfire=0.0f;
    public LayerMask whatisladder;
    private bool isclimbing;
    private float inputVertical;

    public GameObject blood,head,gun,legs;

    public static int totalammo;
    public static int currentammo;

    public static bool isdead,hasknife;

    public GameObject rel;

    public GameObject gameover,knife;



    public Text highscore,lowestfloor;


    float timeleft;
  
      // Start is called before the first frame update
    void Start()
    {
        timeleft=5;
        hasknife=false;
        knife.SetActive(false);
        gameover.SetActive(false);
        rel.SetActive(false);
        isdead = false;
        totalammo=16;
        currentammo=8;
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed=4.1f;
        isgrounded=true;
        isclimbing = false;
        highscore.text="High Score: "+PlayerPrefs.GetInt("HighScore",0).ToString();
        lowestfloor.text="Lowest floor: "+PlayerPrefs.GetInt("LowestFloor",0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(knife.activeSelf)
        {
            hasknife=true;
            timeleft-=Time.deltaTime;
            if(timeleft<0)
              {
                  knife.SetActive(false);
                  hasknife=false;
                  timeleft=5;
              }

        }
        if(isreloading)
        {
            anim.SetBool("isshooting",false);
            anim.SetBool("isreloading",true);
            if(  Input.GetKeyDown(KeyCode.UpArrow)  /*  CrossPlatformInputManager.GetButtonDown("JUMP") */ && isgrounded==true && isclimbing==false &&  StaminaBarScript.stamina>=20)
             {
                  SoundManagerScript.PlaySound("jump");
                  rb.AddForce(Vector2.up * 522f);
                  isgrounded=false;
                  if(totalammo==0 && StaminaBarScript.stamina>=10)
                    {
                     StaminaBarScript.stamina-=6f;
                    }
                 else
                    {
                      StaminaBarScript.stamina-=19f;
                    }
             }
            return;
        }
        if(currentammo>0)
        {
            anim.SetBool("isreloading",false);
        }
       // dirX=Input.GetAxisRaw("Horizontal")*moveSpeed;
        if(Mathf.Abs(dirX)>0)
          {
              anim.SetBool("Isrunning",true);
          }
        else
          {
              anim.SetBool("Isrunning",false);
          }
        if(  Input.GetKeyDown(KeyCode.UpArrow) /*CrossPlatformInputManager.GetButtonDown("JUMP")*/ && isgrounded==true && isclimbing==false && StaminaBarScript.stamina>=20)
          {
              SoundManagerScript.PlaySound("jump");
              rb.AddForce(Vector2.up * 524f);
              isgrounded=false;
              if(totalammo==0 && StaminaBarScript.stamina>=10)
              {
                  StaminaBarScript.stamina-=6f;
                  
              }
              else
              {
              StaminaBarScript.stamina-=19f;
              }

          }

        if(  Input.GetKeyDown(KeyCode.UpArrow)  /* CrossPlatformInputManager.GetButtonDown("JUMP")*/ && isgrounded==true && isreloading==true)
          {
              SoundManagerScript.PlaySound("jump");
              rb.AddForce(Vector2.up * 549f);
              isgrounded=false;
              StaminaBarScript.stamina-=19f;

          }  

       
        if(Input.GetKey(KeyCode.Z) /* CrossPlatformInputManager.GetButton("SHOOT")*/ && Time.time>nextfire && currentammo!=0)
          {
             
              anim.SetBool("isshooting",true);
              anim.SetBool("Isrunning",false);
              nextfire=Time.time+firerate;
              fire();

          }   
        else
          {
              anim.SetBool("isshooting",false);
          } 
          
        if(currentammo==0 && totalammo!=0)
         {
             rel.SetActive(true);
             StartCoroutine("reload");
             return;
         }

         if(  Input.GetKeyDown(KeyCode.X)  /* CrossPlatformInputManager.GetButton("RELOAD")*/ && currentammo!=8 && totalammo>0)
        {
            rel.SetActive(true);
             StartCoroutine("reload");
             return;

        }    
       
    }

 
    IEnumerator reload()
    {
      isreloading=true;
      yield return new WaitForSeconds(1.4f);
      if(totalammo<8)
      {
          currentammo+=totalammo;
          totalammo=0;
          isreloading=false;
          rel.SetActive(false);
      }
      else
      {
          totalammo-=(8-currentammo);
          currentammo=8;
          isreloading=false;
          rel.SetActive(false);
      } 
    }   

    
    void OnCollisionEnter2D(Collision2D col)
       {
           if(col.gameObject.CompareTag("ground") || col.gameObject.CompareTag("enemy-ground"))
           {
              isgrounded=true;
           }
           if(col.gameObject.CompareTag("enemy"))
           {
            HealthBarScript.health-=0.89f;
           
           }
           if(col.gameObject.CompareTag("projectile"))
           {
                SoundManagerScript.PlaySound("projhitplayer");
               HealthBarScript.health-=18f;
           }

           if(col.gameObject.CompareTag("knifeadder"))
           {
               knife.SetActive(true);
                SoundManagerScript.PlaySound("cratesound");
           }
           
    
           
       }

    void OnTriggerEnter2D(Collider2D col)
    {
         if(col.gameObject.CompareTag("knifeadder"))
           {
               knife.SetActive(true);
               col.gameObject.SetActive(false);
           }
    }   

    private void FixedUpdate()
    {
        dirX=Input.GetAxisRaw("Horizontal")*moveSpeed;
        //dirX=CrossPlatformInputManager.GetAxis("Horizontal")*moveSpeed;
        SoundManagerScript.PlaySound("Playerwalkingsound");
        rb.velocity=new Vector2(dirX,rb.velocity.y);
         RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.up,3,whatisladder);
         if(hitInfo.collider!=null)
         {
             if(Input.GetKeyDown(KeyCode.UpArrow) || !isgrounded)
             {
                 isclimbing = true;
             }
            /*  else
             {
                 isclimbing = false;
             }*/
            
         }
           else
             {
                 isclimbing = false;
             }
        

         if(isclimbing==true)
         {
             inputVertical=Input.GetAxisRaw("Vertical");
             rb.velocity = new Vector2(rb.velocity.x,inputVertical*climbspeed);
             rb.gravityScale = 0;
         }
         else
         {
             rb.gravityScale=2.5f;
         }
          if(HealthBarScript.health<=1)
          {
             SoundManagerScript.PlaySound("playerdeathmusic"); 
            Destroy(gameObject,0f);
            Instantiate(blood,transform.position,Quaternion.identity);
            Instantiate(head,transform.position,Quaternion.identity);
            Instantiate(gun,transform.position,Quaternion.identity);
            Instantiate(legs,transform.position,Quaternion.identity);
            isdead = true;
            gameover.SetActive(true);
            Cursor.visible=true;


             if(PlayerPrefs.GetInt("HighScore",0)<ScoreScript.Score)
              {
               PlayerPrefs.SetInt("HighScore",ScoreScript.Score);
              }

             if(PlayerPrefs.GetInt("LowestFloor",0)<Floorcounterscript.floornumber)
              {
                PlayerPrefs.SetInt("LowestFloor",(int)Floorcounterscript.floornumber);
              }
                 
            
          }
    } 



         

    private void LateUpdate()
    {
        if(dirX>0)
        {
            facingRight=true;
        }
        else if(dirX<0)
        {
            facingRight=false;
        }
        if(((facingRight) && (localScale.x<0)) || ((!facingRight) && (localScale.x>0)))
        {
            localScale.x*=-1;
        }
        transform.localScale=localScale;

    }

    void fire()
    {
        bulletpos=transform.position;
        if(facingRight)
        {
            bulletpos+=new Vector2(+0.012f,-0.01f);
            Instantiate(bulletright,bulletpos,Quaternion.identity);
             SoundManagerScript.PlaySound("gunfire");
            //bulletscript.velx=Mathf.Abs(bulletscript.velx);
        }
        else
        {
            bulletpos+=new Vector2(-0.012f,-0.01f);
            Instantiate(bulletleft,bulletpos,Quaternion.identity);
             SoundManagerScript.PlaySound("gunfire");
            //bulletscript.velx=(-1)*Mathf.Abs(bulletscript.velx);
        }
        currentammo-=1;

    }



}
