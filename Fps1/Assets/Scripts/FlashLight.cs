using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light fLight;
    public bool drainOverTime;// true ise zamanla gücü azalýcak. 
    public float maxBright;
    public float minBright;
    public float drainRate;

    public AudioSource flashAS;
    public AudioClip flashAC;


    void Start()
    {
        fLight = GetComponent<Light>();
        flashAS=GetComponent<AudioSource>();

    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            fLight.enabled = !fLight.enabled;// kapatýp açma diye düþün
            flashAS.PlayOneShot(flashAC);
        }
        if(drainOverTime==true&& fLight.enabled==true)
        {
            fLight.intensity = Mathf.Clamp(fLight.intensity, minBright, maxBright);
            if(fLight.intensity>minBright)
            {
                fLight.intensity -= Time.deltaTime * (drainRate / 1000);
            }
            
        }
        else if(drainOverTime==true && fLight.enabled==false)
        {
            fLight.intensity += Time.deltaTime * (drainRate / 1000);
        }
    }
}
