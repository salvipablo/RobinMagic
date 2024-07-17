using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
  public float mouseSensitivity = 100f;

  float xRotation = 0f;
  float yRotation = 0f;
    
  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
  }
  
  void Update()
  {
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; 
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    // Control rotation around x axis (Look up and down)
    xRotation -= mouseY;

    // We clamp the rotation so we cant Over-rotate (Like in real life)
    xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    
    // Control rotation around y axis (Look up and down)
    yRotation += mouseX;

    // Applying both rotations
    transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
  }
}
