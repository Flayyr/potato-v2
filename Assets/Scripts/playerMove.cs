using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rigidBody;
    private void Start() { 
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(x, -0.25f, 0.0f);
        rigidBody.velocity = movement * speed;
    }
}