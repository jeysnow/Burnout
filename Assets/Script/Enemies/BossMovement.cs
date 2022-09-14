using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public bool grounded, rightBlocked, leftBlocked,canMove = true;

    private Boss _boss;
    private GameObject _player;
    private Rigidbody2D _rb;
    private BossAnimation _animation;

    [SerializeField]
    private int _jumpForce, _speed = 10;

    private void Start()
    {
        _boss = GetComponent<Boss>();
        _rb = _boss.rb;
        _player = Player.instance.gameObject;
        _animation = GetComponent<BossAnimation>();
    }

    private void Update()
    {
        
        if (rightBlocked || leftBlocked)
        {
            jump();
            _animation.SetState(1);
        }
        if (_rb.velocity.y < -2)
        {
            _animation.SetState(2);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (_player && (!rightBlocked || !leftBlocked) && canMove)
        {
            Vector2 direction = Vector2.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
            direction.y = _rb.position.y;
            _rb.position = direction;
            _animation.SetState(0);
        }
        
    }

    public void jump()
    {
        if (grounded)
        {
            _rb.AddForce(new Vector2(0, _jumpForce));
            
        }

    }
}
