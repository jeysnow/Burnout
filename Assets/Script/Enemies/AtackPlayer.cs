using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackPlayer : MonoBehaviour
{
    public string _action;
    public int _slowScale;
    public float atackTime;
    private BossMovement movement;
    private BossAnimation _animation;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        //você pode usar um método chamando getComponentInParent, 
        //que vai buscar o primeiro componente que achar do tipo especificado
        movement = transform.parent.gameObject.transform.parent.GetComponent<BossMovement>();
        _player = Player.instance.gameObject;
        _animation = GetComponentInParent<BossAnimation>();
    }
        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_action == "Slow") collision.GetComponent<Player>().action.Slow(_slowScale);

            if (_action == "Kill")
            {
                _animation.Kill();
                Player.instance.animation.Die(transform.position.x-Player.instance.transform.position.x);
                StartCoroutine(WaitToKill());                
            }            

            movement.canMove = false;

            StartCoroutine(canMoveCoolDown());
        }

    }

    IEnumerator canMoveCoolDown()
    {
        yield return new WaitForSeconds(2);
        movement.canMove = true;
    }

    IEnumerator WaitToKill()
    {        
        
        AudioManager.PlaySound("Punch");
        yield return new WaitForSeconds(atackTime);
        Player.instance.action.Die();
    }
}
