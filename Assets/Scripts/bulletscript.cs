using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{


     public float velx=5f;
    float vely=0;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velx,vely);
        Destroy(gameObject,1.9f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject,0f);
        }
    }
}
