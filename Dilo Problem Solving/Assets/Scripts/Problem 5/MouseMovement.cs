using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] float speed = 5f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Testing output posisi mouse
        //if (Input.GetButtonDown("Fire1")) GetScreenPoint();

        // Menggerakkan Player ke posisi mouse jika klik kiri
        if (Input.GetButtonDown("Fire1")) MouseMove();
        //Debug.Log(rb2D.velocity.magnitude);
    }

    private void MouseMove()
    {
        Vector3 targetDestination = GetScreenPoint();

        // Menggerakkan player menuju posisi Klik
        Vector3 moveDirection = (targetDestination - transform.position).normalized;
        rb2D.velocity = moveDirection * speed;
    }

    private Vector3 GetScreenPoint()
    {
        // Mengambil posisi mouse
        Vector3 mousePos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        mouseWorldPos.z = 0f;
        return mouseWorldPos;
        //Debug.Log(mouseWorldPos);
    }
}
