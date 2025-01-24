using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
  Animator animator;

  public float moveSpeed = 0.2f;

  Vector3 stopPosition;

  float walkTime;
  public float walkCounter;
  float waitTime;
  public float waitCounter;

  int WalkDirection;

  public bool isWalking;

  float rabbitRotation = 0;

  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();

    //So that all the prefabs don't move/stop at the same time
    walkTime = Random.Range(3, 6);
    waitTime = Random.Range(2, 4);


    waitCounter = waitTime;
    walkCounter = walkTime;

    ChooseDirection();
  }

  // Update is called once per frame
  void Update()
  {
    if (isWalking)
    {
      animator.SetBool("isRunning", true);

      walkCounter -= Time.deltaTime;

      if (WalkDirection == 0) rabbitRotation = 0f;
      if (WalkDirection == 1) rabbitRotation = 90f;
      if (WalkDirection == 2) rabbitRotation = -90f;
      if (WalkDirection == 3) rabbitRotation = 180f;

      transform.localRotation = Quaternion.Euler(0f, rabbitRotation, 0f);
      transform.position += transform.forward * moveSpeed * Time.deltaTime;

      if (walkCounter <= 0)
      {
        stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        isWalking = false;

        //stop movement
        transform.position = stopPosition;
        animator.SetBool("isRunning", false);

        //reset the waitCounter
        waitCounter = waitTime;
      }
    }
    else
    {
      waitCounter -= Time.deltaTime;
      if (waitCounter <= 0) ChooseDirection();
    }
  }


  public void ChooseDirection()
  {
    WalkDirection = Random.Range(0, 4);
    isWalking = true;
    walkCounter = walkTime;
  }
}
