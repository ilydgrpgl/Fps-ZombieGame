using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]// audiosourceyi ekliyor otomatik

public class TypeWriter : MonoBehaviour
{

    public float delay;

    public AudioClip TypeSound;
    AudioSource audSrc;
    [Multiline]
    public string text;
    Text thisText;


    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
        thisText = GetComponent<Text>();
        StartCoroutine(TypeWrite());
    }
    IEnumerator TypeWrite()
    {
        foreach(char i in text)
        {
            thisText.text += i.ToString();
            audSrc.pitch=Random.Range(0.8f, 1.2f);
            audSrc.PlayOneShot(TypeSound);
            if(i.ToString()==".")
            {
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
           
        }
    }

}
