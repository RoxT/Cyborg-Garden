using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour
{

    private Vector3 mousePosition;
    private readonly float moveSpeed = 0.5f;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);

        }   
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D ballRB = collision.GetComponent<Rigidbody2D>();
        if (ballRB != null && collision.GetComponent<Ball>() != null)
        {
            ballRB.AddForce((transform.position - ballRB.transform.position) * force);
        }
    }
}
