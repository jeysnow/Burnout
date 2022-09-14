using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public PlayerAction action;
    public PlayerControl control;
    public PlayerMovement movement;
    public PlayerAnimation animation;
    public Rigidbody2D rb;
    public bool dead;

    // Awake is called before Start
    private void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        

        action = GetComponent<PlayerAction>();
        control = GetComponent<PlayerControl>();
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<PlayerAnimation>();
    }
    

    
}
