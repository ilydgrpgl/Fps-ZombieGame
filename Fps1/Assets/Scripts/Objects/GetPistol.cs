using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPistol : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject pistol;
    public GameObject realPistol;
    public GameObject activeCross;
    public GameObject ammoPanel;
    // public AudioSource doorSound;

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);

            activeCross.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);

            activeCross.SetActive(false);
        }

        if (Input.GetButton("Action"))
        {
            
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (theDistance <= 2)
            {
                actionKey.SetActive(false);
            realPistol.SetActive(true);
           ammoPanel.SetActive(true);
               
                activeCross.SetActive(false);

                Destroy(pistol);

                //doorSound.Play();
            }
        }

    }
    void OnMouseExit()
    {
        actionKey.SetActive(false);

        activeCross.SetActive(false);
    }
   
}