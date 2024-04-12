using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jill : MonoBehaviour
{
    AudioSource jillAS;
    public AudioClip screamAC;
    public AudioClip punchAC;
    void Start()
    {
        jillAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Scream()
    {
        jillAS.PlayOneShot(screamAC);
    }
    public void punch()
    {
        jillAS.PlayOneShot(punchAC);
    }

}
