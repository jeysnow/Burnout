using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    private Player _player;
    private PlayerMovement _movement;
    UI ui;
    // Start is called before the first frame update
    void Start()
    {
        _player = Player.instance;
        ui = UI.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                Win();
                break;
            default:
                break;
        }
    }

    public void Die()
    {
        _player.dead = true;
        Time.timeScale = 0;
        ui.Text.enabled = true;
        ui.Text.text = "press R to replay";
        AudioManager.StopBackgroundMusic();
    }

    public void Revive(){
        MyPersistentData.instance.replay = true;
        Debug.Log(MyPersistentData.instance.replay);
        SceneManager.LoadScene(0);
        
    }


    public void Slow(int slowScale)
    {
        _player.movement.slowly = slowScale;
        StartCoroutine(ResetSlow());
    }


    public void Win()
    {
        Time.timeScale = 0;
        ui.Win();
    }

    IEnumerator ResetSlow()
    {
        yield return new WaitForSeconds(3);
        _player.movement.slowly = 0;
    }
}
