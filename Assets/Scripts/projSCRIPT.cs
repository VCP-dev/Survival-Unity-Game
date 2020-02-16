using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// For the projectile shot by the shooting-enemy

public class projSCRIPT : MonoBehaviour
{
    public float velx=3.3f;
    float vely=0;
    Rigidbody2D rb;

   

    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        
        if(ShootingENEMYscript.localScale.x<0 )
        {
            velx=(-1)*Mathf.Abs(velx);
           
        }
        else if(ShootingENEMYscript.localScale.x>0  )
        {
            velx=(1)*Mathf.Abs(velx);
            
        }
 
        rb.velocity = new Vector2(velx,vely);
    }

    // Update is called once per frame
    void Update()
    {
        
        Destroy(gameObject,1.6f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject,0f);
        }
        if(col.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject,0f);
        }
    }
}
