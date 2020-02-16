using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class remainingammo : MonoBehaviour
{

    Text ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammo.text="    Ammo : "+Character.currentammo+" / "+Character.totalammo;
    }
}
