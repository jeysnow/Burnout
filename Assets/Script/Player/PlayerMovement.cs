using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //the variables are set by the checkers    
    public bool grounded, rightBlocked, leftBlocked;
    private Player _player;
    private Rigidbody2D _rb;
    private Vector2 _finalMovememt = Vector2.zero;
    [SerializeField]
    private int _jumpForce, _speed = 10;
    public int slowly = 0;
    private PlayerAnimation animation;
    


    //get components
    private void Start()
    {
        _player = GetComponent<Player>();
        _rb = _player.rb;
        animation = GetComponent<PlayerAnimation>();
    }
    private void Update()
    {
       
    }
    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        //overwrites physics velocity and adds gravity
        _rb.velocity = _finalMovememt;
        if (_rb.velocity.y < -2)
        {
            animation.Jump(false);
        }
        //Debug.Log(_rb.velocity);
    }    
    
    public void Walk(float howmuch=0)
    {
        //checks for extremities of the control
        if (howmuch > 0.8f)
        {
            howmuch = 0.8f;
            if (rightBlocked)
            {
                howmuch = 0;
            }
        }
        if (howmuch < -0.8f)
        {
            howmuch = -0.8f;
            if (leftBlocked)
            {
                howmuch = 0;
            }
        }
        //sets values for movement that will be called on fixed update
        _finalMovememt.x = howmuch*(_speed - slowly);
        _finalMovememt.y = _rb.velocity.y+ Physics2D.gravity.y/3;
    }

    public void jump()
    {
        //checks if the character is on ground
        if (grounded){
            StartCoroutine(WaitToJump());            
            
        }
    }

    IEnumerator WaitToJump()
    {
        yield return new WaitForFixedUpdate();
        
        _rb.AddForce(new Vector2(0,_jumpForce));
        animation.Jump(true);
        
    }

}
