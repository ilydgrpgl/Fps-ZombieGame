using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityGate : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject actionText;
    public GameObject door;
    public GameObject activeCross;
    public AudioSource doorSound;
     GetKey key;


    private void Start()
    {
        key = FindObjectOfType<GetKey>();//"Object Referencing" olarak adland�r�l�r. Bir nesnenin ba�ka bir nesneye referans al�nmas� anlam�na gelir.
    }
    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
            actionText.SetActive(true);
            activeCross.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
            actionText.SetActive(false);
            activeCross.SetActive(false);
        }

        if (Input.GetButton("Action")&& key.keyTaken==true)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (theDistance <= 2)
            {
                actionKey.SetActive(false);
                actionText.SetActive(false);
                door.GetComponent<Animation>().Play("SecurityGate");
               
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
