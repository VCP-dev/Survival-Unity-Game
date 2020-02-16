using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladderspawnerscript : MonoBehaviour
{


    public GameObject ladder;
    Vector2 whereToSpawn;
   
   
   
public static bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        spawned=false;
       
        
    }

    // Update is called once per frame
    void Update()
    {
       if(PREVleveldestroyer.enemycount>=PREVleveldestroyer.enemylimit /* && spawned!=true */)
        {
        spawned=true;
        StartCoroutine(spawnladder());
        return;
        }
    }

    IEnumerator spawnladder()
    {
        whereToSpawn = new Vector2(Random.Range(-10f,-4.5f),transform.position.y);
        Instantiate(ladder,whereToSpawn,Quaternion.identity);
        yield return null;

    }


}
