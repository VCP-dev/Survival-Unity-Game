using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camerapos : MonoBehaviour
{

    //public Transform target;
    private Vector3 offset;

// public GameObject ground;
     Transform ground;
   // Transform bossground;

    AudioSource asrc;

    public GameObject player,topfloor;
    
   

    // Start is called before the first frame update
    void Start()
    {
        
        asrc = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Floorcounterscript.floornumber==0 && player!=null)
        {
            
            asrc.Play();
            asrc.loop=true;
        }
        if(/* Character.isdead!=true */ player!=null)
        {
        ground=GameObject.FindGameObjectWithTag("ground").GetComponent<Transform>();
        transform.position=new Vector3(ground.position.x,ground.position.y+1.75f,-5);
       
        }
        else if(player==null)
        {
            asrc.Stop();

        }


        /* if(ground!=null && Character.isdead!=true )
        {
            transform.position=new Vector3(ground.transform.position.x,ground.transform.position.y+1.75f,-5);

        }
        else
        {}*/
        // else if(Character.isdead!=true && !ground.activeSelf /* && Ladderspawnerscript.spawned==true  */)
        //{
        //transform.position = new Vector3(transform.position.x,target.position.y+0.6f,-5);
        //}

        
        
    }
}
