using System;
using UnityEngine;

public class BossTriggerCheck : MonoBehaviour
{
    public string targetBoolean;
    private BossMovement movement;
    private Action<bool> SetBoolean;

    private void Start()
    {

        movement = transform.parent.gameObject.transform.parent.GetComponent<BossMovement>();

        switch (targetBoolean)
        {
            case "Left":
                SetBoolean = (bool check) => { movement.leftBlocked = check; };
                break;
            case "Right":
                SetBoolean = (bool check) => { movement.rightBlocked = check; };
                break;
            case "Ground":
                SetBoolean = (bool check) => {
                    movement.grounded = check;
                };
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Ground"))
        {
            SetBoolean(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SetBoolean(false);
    }

}
