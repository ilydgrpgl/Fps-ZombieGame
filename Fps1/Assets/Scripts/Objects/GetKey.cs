using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject getKeyText;

    public GameObject activeCross;
   // public AudioSource doorSound;

    public bool keyTaken;
    public GameObject key;




    private void Start()
    {
        keyTaken = false;
    }

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
         
            activeCross.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
           
            activeCross.SetActive(false);
        }

        if (Input.GetButton("Action"))
        {
            keyTaken=true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (theDistance <= 2)
            {
                actionKey.SetActive(false);
                getKeyText.SetActive(true);
                StartCoroutine(KeyTakenText());
                activeCross.SetActive(false);
                key.GetComponent<MeshRenderer>().enabled = false;
              
              
                //doorSound.Play();
            }
        }

    }
    void OnMouseExit()
    {
        actionKey.SetActive(false);
       
        activeCross.SetActive(false);
    }
    IEnumerator KeyTakenText() 
    { 
        yield return new WaitForSeconds(2.0f);
        getKeyText.SetActive(false);
    
    }
}
