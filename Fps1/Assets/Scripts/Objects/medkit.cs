using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkit : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject activeCross;

    public GameObject medKitBox;
    public GameObject fullText;
    PlayerHealth player;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }


    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

    }

    void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            if (player.currentHealth == 100)
            {
                actionKey.SetActive(false);

                activeCross.SetActive(true);
                fullText.SetActive(true);

            }
            else if (player.currentHealth < 100)
            {
                actionKey.SetActive(true);
                activeCross.SetActive(true);
            }

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
                if (player.currentHealth < 100)
                {
                    player.currentHealth += 25;
                    player.healthBar.value += 25;

                    actionKey.SetActive(false);


                    activeCross.SetActive(false);

                    Destroy(medKitBox);

                }



            }
        }

    }

   
    void OnMouseExit()
    {
        actionKey.SetActive(false);

        activeCross.SetActive(false);
        fullText.SetActive(false);
    }
}
