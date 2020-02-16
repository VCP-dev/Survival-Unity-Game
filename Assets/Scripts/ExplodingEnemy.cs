using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX,dirY,torque;
    

    // Start is called before the first frame update
    void Start()
    {
        dirX=Random.Range(-4,4);
        dirY=Random.Range(3,7);
        torque=Random.Range(5,9);
        rb=GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(dirX,dirY), ForceMode2D.Impulse);
        rb.AddTorque(torque,ForceMode2D.Force);
        
        Destroy(gameObject,0.89f);

        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
