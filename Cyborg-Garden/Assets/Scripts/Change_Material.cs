using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Material : MonoBehaviour
{
    private new CircleCollider2D collider;
    private new Rigidbody2D rigidbody;
    public PhysicsMaterial2D originalMaterial;
    private bool slowDown;
    private float slowStrength;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        originalMaterial = collider.sharedMaterial;
        slowDown = false;
        
    }

    void Update()
    {
        if (slowDown)
        {
            Vector2 velocity = rigidbody.velocity;
            velocity = Vector2.Scale(velocity, new Vector2(slowStrength, slowStrength));
            rigidbody.velocity = velocity;
        }
    }

    public void NewMaterial(PhysicsMaterial2D newMaterial, float scaleVelocityBy)
    {
        if (newMaterial != null)
        {
            collider.sharedMaterial = newMaterial;
        }
        slowDown = true;
        slowStrength = scaleVelocityBy;
    }

    public void ResetMaterial()
    {
        collider.sharedMaterial = originalMaterial;
        slowDown = false;

    }
}
