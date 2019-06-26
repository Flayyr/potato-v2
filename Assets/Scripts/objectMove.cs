using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMove : MonoBehaviour
{
    private float speed = 0.0f;
    private Rigidbody rigidbody;
    public float maxXspeed = 20.0f;
    public float minXspeed = 5.0f;
    private float xspeed;
    public float acceleration = 6.0f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        xspeed = Random.Range(minXspeed, maxXspeed);
    }

    private void FixedUpdate()
    { 
        speed += acceleration;
        acceleration -= 0.15f;

        rigidbody.velocity = new Vector3(-xspeed, speed, 0.0f);
    }

    private void Update()
    {
        if (rigidbody.position.y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
