using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public GameObject player;
    public GameObject fadeScreen;
  
    void Start()
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1f);
        fadeScreen.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;


    }
}
