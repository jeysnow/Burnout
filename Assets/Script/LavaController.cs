using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    public float speed = 0.1f;
    public float riseCooldown = 5f;
    public float timeRising = 5f;

    private bool isRising = false;
    private bool canRise = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Debug.Log("fixedUpdate" + isRising);

        if (isRising)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed, Space.World);

        } else if (canRise)
        {
            StartCoroutine(moveLava());
        }
        else
        {
            StartCoroutine(RiseCooldown());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().action.Die();
        }
    }

    IEnumerator moveLava()
    {
        isRising = true;
        yield return new WaitForSeconds(timeRising);
        isRising = false;
        canRise = false;
    }

    IEnumerator RiseCooldown()
    {
        canRise = false;
        yield return new WaitForSeconds(riseCooldown);
        canRise = true;
    }

}
