using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floorcounterscript : MonoBehaviour
{

    Text Floorcounter;
    public static float floornumber;
    // Start is called before the first frame update
    void Start()
    {
        floornumber=0;
        Floorcounter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(floornumber==0)
        {
            Floorcounter.text="TOP FLOOR";
        }
        else
        {
            Floorcounter.text="FLOOR  "+floornumber;
        }
        
    }
}
