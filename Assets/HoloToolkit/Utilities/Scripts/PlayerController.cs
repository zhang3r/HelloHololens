using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;


class PlayerController : MonoBehaviour
{
    public float speed;
    public Int32 count;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (count > 0)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Debug.Log("prem " + moveHorizontal + " : " + moveVertical);

            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 movement = new Vector3(0.0f, 0.0f, 2.0f);

            rb.AddForce(movement * speed);
            count--;
        }
    }
}

