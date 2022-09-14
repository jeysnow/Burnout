using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{
    public static Boss instance;
    public BossMovement movement;
    public Rigidbody2D rb;
    private GameObject _player;
    private bool canGrowl = true;
    // Awake is called before Start
    private void Awake()
    {
       
        instance = this;

        movement = GetComponent<BossMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canGrowl && Time.timeScale == 1)
        {
            canGrowl = false;
            StartCoroutine(Growl());
        }
    }

    IEnumerator Growl()
    {
        AudioManager.PlaySound("Growl");
        yield return new WaitForSeconds(5);
        canGrowl = true;
    }
}
