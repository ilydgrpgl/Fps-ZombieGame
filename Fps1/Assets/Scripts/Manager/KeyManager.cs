using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool isKeyObtained;
    public GameObject key;
    void Start()
    {
        isKeyObtained = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Keyone")
        {
            isKeyObtained = true;
            Destroy(key);
        }
    }

}
