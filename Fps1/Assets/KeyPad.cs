using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class KeyPad : MonoBehaviour
{
    public MainDoor doorController;
    public GameObject keyPadUI;
    public Text passwordText;
    public string password;
    public FirstPersonController playerScript;
    public GameObject dropText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            playerScript.enabled = true;
            keyPadUI.SetActive(false);
        }
        
    }
   private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            keyPadUI.SetActive(true);
            playerScript.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            dropText.SetActive(true);
        }
    }

    public void KeyButton(string key)
    {
        passwordText.text=passwordText.text + key;
    }
    public void ResetPassword()
    {
        passwordText.text = "";
    }
    public void CheckPassword()
    {
        if(passwordText.text==password)
        {
            doorController.isLocked = false;
            doorController.CheckDoor();
            keyPadUI.SetActive(false);
            playerScript.enabled = true;
        }
        else
        {
            ResetPassword();
        }
     
    }
    
}
