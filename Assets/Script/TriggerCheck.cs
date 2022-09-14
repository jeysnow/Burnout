using UnityEngine;
using System;

public class TriggerCheck : MonoBehaviour
{
    public string targetBoolean;
    private PlayerMovement movement;
    private Action<bool,string> SetBoolean;
    private void Start()
    {
        movement = Player.instance.movement;

        //sets up which PlayerMovement booleans will be checked when this trigger is activated
        switch (targetBoolean)
        {
            case "Left":
                SetBoolean = (bool check, string tag) => { movement.leftBlocked = check; };                
                break;
            case "Right":
                SetBoolean = (bool check, string tag) => { movement.rightBlocked = check; };
                break;
            case "Ground":
                SetBoolean = (bool check, string tag) => {
                    if (tag == "Ground" || tag == "Obstacle")
                    {
                        movement.grounded = check;
                    }
                };                    
                break;
        }
    }

    //sets the booleans as the trigger is activated
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((targetBoolean == "Left" || targetBoolean == "Right") && collision.CompareTag("Ground"))
        {
            return;
        }

        else
        {
            SetBoolean(true, collision.gameObject.tag);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((targetBoolean == "Left" || targetBoolean == "Right") && collision.CompareTag("Ground"))
        {
            return;
        }

        SetBoolean(false, collision.gameObject.tag);
    }

}
