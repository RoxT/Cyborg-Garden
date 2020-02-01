using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Trap : MonoBehaviour
{
    public bool shouldChangeMaterial;
    public bool shouldChangeType;

    public PhysicsMaterial2D trapMaterial;
    public BallType trapType;
    public int framesUntilChange;
    public float scaleVelocityBy;

    // Start is called before the first frame update
    void Start()
    {
        if (shouldChangeMaterial == true)
        {
            trapMaterial = GetComponent<Collider2D>().sharedMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Change_Material canChange = collision.GetComponent<Change_Material>();
        if (canChange != null)
        {
            canChange.NewMaterial(trapMaterial, scaleVelocityBy);
        }

        Ball isBall = collision.GetComponent<Ball>();
        if (isBall != null && shouldChangeType)
        {
            isBall.StartChanging(trapType, framesUntilChange);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Change_Material canChange = collision.GetComponent<Change_Material>();
        if (canChange != null)
        {
            canChange.ResetMaterial();
        }

        Ball isBall = collision.GetComponent<Ball>();
        if (isBall != null)
        {
            isBall.StopChanging();
        }
    }

}
