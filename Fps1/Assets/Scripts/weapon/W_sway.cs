using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_sway : MonoBehaviour
{

    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
        Quaternion targetRot = rotationX * rotationY;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, smooth * Time.deltaTime);
    }
}