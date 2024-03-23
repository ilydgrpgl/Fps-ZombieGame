using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSystem : MonoBehaviour
{
   

    Animator animator;
    public AudioSource sliderDoorSound;
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.SetBool("Gate", true);
            sliderDoorSound.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Gate", false);
            sliderDoorSound.Play();
        }
    }

}
