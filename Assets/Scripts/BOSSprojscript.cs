using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSprojscript : MonoBehaviour
{

    float velx=5.2f;
    float vely=0;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        
        if(BOSSscript.localScale.x<0 )
        {
            velx=(-1)*Mathf.Abs(velx);
           
        }
        else if(BOSSscript.localScale.x>0  )
        {
            velx=(1)*Mathf.Abs(velx);
            
        }
 
        rb.velocity = new Vector2(velx,vely);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,1.2f);
    }

     void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
             HealthBarScript.health-=6f;
            Destroy(gameObject,0f);
        }
        if(col.gameObject.CompareTag("wall-left") || col.gameObject.CompareTag("wall-right"))
        {
            Destroy(gameObject,0f);
        }
       
    }
}
