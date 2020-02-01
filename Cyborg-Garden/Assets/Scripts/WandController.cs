using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour
{

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    public float strength;
    public Rigidbody2D ball;


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

            ball.AddForce((transform.position - ball.transform.position) * strength);
        }   
    }
}
