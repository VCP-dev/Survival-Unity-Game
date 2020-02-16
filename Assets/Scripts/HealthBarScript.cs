using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    Image healthbar;
    float maxhealth = 100f;
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
        healthbar=GetComponent<Image>();
        health=maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount=health/maxhealth;
    }
}
