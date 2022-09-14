using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    Animator _animator;
    BossMovement _movement;
    public int currentState;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<BossMovement>();
    }

    public void Kill()
    {
        _animator.SetBool("Atack", true);
    }

    public void SetState(int state)
    {
        _animator.SetInteger("State", state);
        currentState = state;
    }
}
