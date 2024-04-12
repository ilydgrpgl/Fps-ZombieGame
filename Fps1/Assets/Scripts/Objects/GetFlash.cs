using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlash : MonoBehaviour
{

    public float theDistance;
    public GameObject actionKey;
    public GameObject getFlashText;

    public GameObject activeCross;
    // public AudioSource doorSound;

    public bool flashTaken;
    public GameObject flashLight;
    public GameObject realflashLight;
    public GameObject flashActivision;




    private void Start()
    {
        flashTaken = false;
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
            flashTaken = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            if (theDistance <= 2)
            {
                actionKey.SetActive(false);
                getFlashText.SetActive(true);
                flashActivision.SetActive(true);
                StartCoroutine(KeyTakenText());
                activeCross.SetActive(false);
                flashLight.GetComponent<MeshRenderer>().enabled = false;
                realflashLight.SetActive(true);


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
        getFlashText.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        flashActivision.SetActive(false);

    }

}
