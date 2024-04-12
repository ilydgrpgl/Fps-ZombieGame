using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    Light fLight;
    public bool drainOverTime;// true ise zamanla g�c� azal�cak. 
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
            fLight.enabled = !fLight.enabled;// kapat�p a�ma diye d���n
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
