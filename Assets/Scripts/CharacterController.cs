using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float movSpeed;
    
    [SerializeField]
    private float rotSpeed;
    void Start()
    {
    }

    void Update()
    {

        if (Input.GetButton("WalkForward")) transform.Translate(0, movSpeed * Time.deltaTime, 0);
        if (Input.GetButton("WalkBackwards")) transform.Translate(0, -movSpeed * Time.deltaTime, 0);
        if (Input.GetButton("WalkRight")) transform.Rotate(new Vector3(0, 0, rotSpeed));
        if (Input.GetButton("WalkLeft")) transform.Rotate(new Vector3(0, 0, -rotSpeed));

    }
}
