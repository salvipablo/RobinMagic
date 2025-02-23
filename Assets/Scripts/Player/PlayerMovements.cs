using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
  public CharacterController controller;

  public float speed = 12f;
  public float gravity = -9.81f * 2;
  public float jumpHeight = 3f;

  public Transform groundCheck;
  public float groundDistance = 0.4f;
  public LayerMask groundMask;

  private Vector3 velocity;

  private bool isGrounded;

  private Vector3 lastPosition = new Vector3(0, 0, 0);
  public bool isMoving;

  void Update()
  {
    // Checking if we hit ground to reset our falling velocity, otherwise we will fall faster the next time.
    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    if (isGrounded && velocity.y < 0) velocity.y = -2f;

    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    // Right is the red Axis, foward is the blue axis.
    Vector3 move = transform.right * x + transform.forward * z;

    controller.Move(move * speed * Time.deltaTime);

    // Check if the player is on the ground so he can jump.
    if (Input.GetButtonDown("Jump") && isGrounded) velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);  // The equation for jumping.

    velocity.y += gravity * Time.deltaTime;

    controller.Move(velocity * Time.deltaTime);

    if (lastPosition != gameObject.transform.position && isGrounded)
    {
      isMoving = true;
      SoundManager.Instance.PlaySound(SoundManager.Instance.grassWalkSound);
    } 
    else
    {
      isMoving = false;
      SoundManager.Instance.grassWalkSound.Stop();
    }
    lastPosition = gameObject.transform.position;
  }
}
