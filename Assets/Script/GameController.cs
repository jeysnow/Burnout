using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class GameController : MonoBehaviour
{
    private Player _player;
    private UI ui;    
    private bool _gameStarted = false;
    private CinemachineVirtualCamera cameraVirtual;
    private PlayableDirector intro;


    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 0;
        _player = Player.instance;
        ui = UI.instance;
        intro = GetComponentInChildren<PlayableDirector>();
        cameraVirtual = intro.GetComponentInChildren<CinemachineVirtualCamera>();
        
        ui.ShowText("Use the arrows keys to move");
        
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    



    IEnumerator StartGame()
    {
        
        while (true)
        {            
            if (Input.anyKey)
            {
                Debug.Log("pressed");
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        

        
        ui.ShowText("");
        if (!MyPersistentData.instance.replay)
        {
            intro.enabled = true;
            yield return new WaitForSecondsRealtime((float)intro.duration);
        }
        _player.control.StartRandom();
        Time.timeScale = 1;
        AudioManager.PlayerBackgroundMusic();
        //StartCoroutine(SetVirtualCamera());
        cameraVirtual.Follow = _player.transform;
    }

    IEnumerator SetVirtualCamera()
    {
        
        while (true)
        {
            Vector2 target = _player.transform.position;
            Vector2 camera = cameraVirtual.transform.position;
            camera = Vector3.MoveTowards(camera, target, 10*Time.deltaTime);

            if(camera.x - target.x> -1 && camera.x - target.x < 1)
            {
                break;
            }
                
            yield return new WaitForEndOfFrame();
            
        }
        
        cameraVirtual.Follow = _player.transform;
    }

}
