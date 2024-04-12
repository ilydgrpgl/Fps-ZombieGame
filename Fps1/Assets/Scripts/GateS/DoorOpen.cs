using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject actionText;
    public GameObject hinge;
    public GameObject activeCross;
    public AudioSource doorSound;
    

    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;
        
    }

     void OnMouseOver()
    {
        bool isCloseEnough = theDistance <= 2;
        actionKey.SetActive(isCloseEnough);
        actionText.SetActive(isCloseEnough);
        activeCross.SetActive(isCloseEnough);

        if (Input.GetButton("Action") && isCloseEnough)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (theDistance <= 2)
            {
                actionKey.SetActive(false);
                actionText.SetActive(false);
                hinge.GetComponent<Animation>().Play("MyDoorAnim");
                hinge.GetComponent<Animation>().Play("MyDoorAnim2");
                doorSound.Play();
            }
        }
         
    }
     void OnMouseExit()
    {
        actionKey.SetActive(false);
        actionText.SetActive(false);
        activeCross.SetActive(false);
    }
}
