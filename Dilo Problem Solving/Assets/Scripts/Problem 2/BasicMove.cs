using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    private Rigidbody2D rb2D;
    float xDirection = 1;
    float yDirection = 1;
    [SerializeField] float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        InitiateMove();
    }

    private void InitiateMove()
    {
        float xRandomDirection = Random.Range(-xDirection, xDirection);
        float yRandomDirection = Random.Range(-yDirection, yDirection);

        Vector2 moveDirection = new Vector2(xRandomDirection, yRandomDirection).normalized;

        // Menggerakkan dengan addforce
        //rb2D.AddForce(moveDirection * speed);

        // Menggerakkan dengan set velocity
        rb2D.velocity = moveDirection * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb2D.velocity.magnitude);
    }
}
