using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [SerializeField] float speed = 5f;
    
    [SerializeField] float drag = 5f;
    float baseDrag;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        baseDrag = rb2D.drag;
    }

    private void Update()
    {
        // menghaluskan pengereman ketika pergerakan dihentikan
        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            rb2D.drag = 5f;
            return;
        }
        KeyboardMove();
        //Debug.Log(rb2D.velocity.magnitude);
    }

    private void KeyboardMove()
    {
        rb2D.drag = baseDrag;
        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(xDirection, yDirection).normalized;
        rb2D.velocity = moveDirection * speed;

        //Debug.Log(xDirection + "," + yDirection);
        //Debug.Log(Input.GetButton("Horizontal"));
        //Debug.Log(rb2D.velocity.magnitude);
    }
}
