using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class playerJump : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 movement;
    private bool isGrounded = true;
    private bool reached = false;
    public float speed = 10;
    public Boundary boundary;
    public GameObject controller;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!controller.GetComponent<gameController>().GetStopGame())
        {
            if (reached)
            {

                isGrounded = true;
                Debug.Log(isGrounded);
                reached = false;
            }
        }
    }

    private void Update()
    {
        if (!controller.GetComponent<gameController>().GetStopGame())
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isGrounded = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!controller.GetComponent<gameController>().GetStopGame())
        {
            float x = Input.GetAxisRaw("Horizontal");
            if (!isGrounded)
            {
                if (!isGrounded && !reached && transform.position.y < 3)
                {

                    movement = new Vector3(x, 0.5f, 0.0f);
                }
                else if (transform.position.y >= 3)
                {
                    reached = true;
                    movement = new Vector3(x, -0.2f, 0.0f);
                }
                else
                {
                    movement = new Vector3(x, -0.2f, 0.0f);
                }
            }
            else
            {
                movement = new Vector3(x, -0.25f, 0.0f);
            }


            rigidbody.velocity = movement * speed;

            rigidbody.position = new Vector3
            (
                Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rigidbody.position.y, boundary.yMin, boundary.yMax),
                0.0f

            );
        }
    }
}