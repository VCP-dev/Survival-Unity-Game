using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSShealthscript : MonoBehaviour
{
      Vector2 localScale;
    // Start is called before the first frame update
    void Start()
    {
        
        localScale=transform.localScale;
       
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x=BOSSscript.healthamount;
        transform.localScale=localScale;
    }
}
