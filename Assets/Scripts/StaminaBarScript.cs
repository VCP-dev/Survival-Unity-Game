using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarScript : MonoBehaviour
{

     Image staminabar;
    float maxstamina = 100f;
    public static float stamina;

    
    // Start is called before the first frame update
    void Start()
    {
        staminabar=GetComponent<Image>();
        stamina=maxstamina;
    }

    // Update is called once per frame
    void Update()
    {
       
        staminabar.fillAmount=stamina/maxstamina;
        if(stamina<100 && Character.isdead!=true && Time.timeScale!=0f)
        {
            StartCoroutine(regainstamina());
        }

        if(stamina>=20)
        {
             staminabar.GetComponent<Image>().color = new Color32(39,229,16,255);
        }
        else
        {
             staminabar.GetComponent<Image>().color = new Color32(221,245,17,255);
        }
       
    }

    IEnumerator regainstamina()
    {
        stamina+=0.089f;
        yield return null;
    }

   
   

}
