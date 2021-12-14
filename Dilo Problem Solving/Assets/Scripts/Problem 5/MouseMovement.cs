using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] float speed = 5f;

    //private bool isMoving = false;
    private bool isDashing = false;
    [SerializeField] float dashTime = 0.1f;
    [SerializeField] float dashDelay = 3f;
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] GameObject dashParticlePrefab;

    private Slider dashGauge;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        dashGauge = FindObjectOfType<Slider>();
        dashGauge.value = dashDelay;
    }

    void FixedUpdate()
    {
        // Testing output posisi mouse
        //if (Input.GetButtonDown("Fire1")) GetScreenPoint();

        // menghitung delay sampai dash tersedia
        if (dashDelay < 3f)
        {
            dashDelay += Time.deltaTime;
            dashGauge.value = dashDelay;
        }

        

        // Menggerakkan Player ke posisi mouse jika klik kiri dan tidak sedang dash
        if (Input.GetButtonDown("Fire1") && !isDashing) MouseMove();

        // dash ketika space ditekan, player bergerak dan dash sudah tersedia
        else if (Input.GetButtonDown("Jump") && (dashDelay >= 3) && (rb2D.velocity != Vector2.zero)) StartCoroutine(Dash()); // && isMoving

        // Menghentikan Pergerakan ketika mouse di klik kanan dan tidak sedang dash
        else if (Input.GetButtonDown("Fire2") && !isDashing) StopMovement();

        //Debug.Log(rb2D.velocity.magnitude);
    }

    private IEnumerator Dash()
    {
        isDashing = true;

        GameObject dashParticle =  Instantiate(dashParticlePrefab);
        dashParticle.transform.position = transform.position;
        dashParticle.GetComponent<ParticleSystem>().Play();
        StartCoroutine(DestroyParticle(dashParticle));

        // tambahkan kecepatan selama "dashTime"
        rb2D.velocity = rb2D.velocity.normalized * dashSpeed;
        // reset dash delay
        dashDelay = 0;

        yield return new WaitForSeconds(dashTime);
        
        // kembalikan kecepatan seperti semula setelah dash
        rb2D.velocity = rb2D.velocity.normalized * speed;
        isDashing = false;
    }

    private IEnumerator DestroyParticle(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    private void MouseMove()
    {
        //isMoving = true;

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

    private void StopMovement()
    {
        //isMoving = false;
        rb2D.velocity = Vector2.zero;
    }
}
