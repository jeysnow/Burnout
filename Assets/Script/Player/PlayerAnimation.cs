using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;
    private PlayerMovement movement;
    private PlayerControl control;
    private Animator animator;
    private SpriteRenderer sprite;
    private Vector3 flipVector = new Vector3(-1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        movement = GetComponent<PlayerMovement>();
        control = GetComponent<PlayerControl>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(updateAnimation());
    }

    IEnumerator updateAnimation()
    {
        


        while(true)
        {
            animator.SetFloat("Horizontal", control.axis);
            if (control.axis < 0)
            {
                sprite.transform.localScale = flipVector;
            }
            if (control.axis > 0)
            {
                sprite.transform.localScale = Vector3.one;
            }
            if (movement.grounded)
            {
                animator.SetBool("Fall", false);
            }
            yield return new WaitForEndOfFrame();

        }
    }

    public void Jump(bool up)
    {
        if (up)
        {
            animator.SetBool("Fall", false);
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", true);
        }
    }

    public void Die(float positionDiference)
    {
        if (positionDiference >= 0)
        {
            sprite.transform.localScale = Vector3.one;
        }
        else
        {
            sprite.transform.localScale = flipVector;
        }
        animator.Play("die");
    }
}
