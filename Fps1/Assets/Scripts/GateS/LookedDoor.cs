using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookedDoor : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject lookedDoortext;
    public AudioSource doorSound;


    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
          
        }
        else
        {
            actionKey.SetActive(false);
           
        }

        if (Input.GetButton("Action"))
        {
            
            if (theDistance <= 2)
            {
                actionKey.SetActive(false);
                lookedDoortext.SetActive(true);
                StartCoroutine(DoorLooked());
                doorSound.Play();
            }
        }

    }
    void OnMouseExit()
    {
        actionKey.SetActive(false);
        
    }
    IEnumerator DoorLooked()
    {
        yield return new WaitForSeconds(1.5f);
        lookedDoortext.SetActive(false);
    }
}
