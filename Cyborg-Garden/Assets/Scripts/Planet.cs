using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
