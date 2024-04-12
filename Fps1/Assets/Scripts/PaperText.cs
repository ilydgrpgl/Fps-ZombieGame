using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperText : MonoBehaviour
{
    public GameObject Paper;
    public GameObject realPaper;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Paper.SetActive(true);
            realPaper.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Paper.SetActive(false);
            realPaper.SetActive(true);
        }
    }
}
