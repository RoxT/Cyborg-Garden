using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModePlay : MonoBehaviour
{
    private bool isTopOn;
    private int powerWhenOn = 20;
    private int powerWhenOff = 5;
    Bumper[] topBumpers;
    Bumper[] bottomBumpers;
    SpriteRenderer button;
    private Color orange = new Color(1f, .6f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        topBumpers = transform.Find("Top Row").GetComponentsInChildren<Bumper>();
        bottomBumpers = transform.Find("Bottom Row").GetComponentsInChildren<Bumper>();
        button = transform.Find("PlayButton").GetComponent<SpriteRenderer>();
        TurnBottomOn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(isTopOn)
        {
            TurnBottomOn();
        } else
        {
            TurnTopOn();
        }
    }

    public void TurnTopOn()
    {
        ToggleRow(topBumpers, orange, powerWhenOn);
        ToggleRow(bottomBumpers, Color.gray, powerWhenOff);

        button.flipX = true;
        isTopOn = true;
    }

    public void TurnBottomOn()
    {
        ToggleRow(topBumpers, Color.gray, powerWhenOff);
        ToggleRow(bottomBumpers, orange, powerWhenOn);
        button.flipX = false;
        isTopOn = false;
    }

    private void ToggleRow(Bumper[] bumpers, Color color, int power)
    {
        foreach (Bumper bumper in bumpers)
        {
            bumper.forceMagnitude = power;
            bumper.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
