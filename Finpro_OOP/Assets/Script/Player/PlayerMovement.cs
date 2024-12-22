using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //fields
    public float speed = 5.0f;
    public bool isMoving = false;
    Rigidbody2D rb;
    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (moveDir != Vector2.zero)
        {
            isMoving = true;
            rb.velocity = moveDir.normalized * speed;
        }
        else
        {
            isMoving = false;
            transform.position = transform.position;
            rb.velocity = Vector2.zero;
        }
        Debug.Log(isMoving);
    }
}
