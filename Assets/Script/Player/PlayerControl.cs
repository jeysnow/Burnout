using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float axisSensibility;
    [SerializeField]
    private float[] rndTimeRange = { 0, 1 };
    [SerializeField]
    private bool random;

    public float axis;
    private string[] currentKeys = new string[4];

    private string[][] keys =
    {
        new string[]{ "up", "down", "left", "right" },
        new string[]{ "left", "up", "right", "up" },
        new string[]{ "right", "up", "up", "left" }
        
        //new string[]{ "w", "s", "a", "d" },
        //new string[]{ "u", "j", "h", "k" }
    };

    #region instance references
    private Player player;
    private UI ui;
    public Lights lights;
    
    #endregion


    private void Start()
    {
        //get instance references
        player = Player.instance;
        ui = UI.instance;

        //temporary
        currentKeys = keys[0];       
        
    }

    public void StartRandom()
    {
        if (random)
        {
            StartCoroutine(RandomizeControls());
        }
    }



    private void Update()
    {
        GetKeys();
        player.movement.Walk(axis);        
        //Debug.Log(axis);
    }

    //Checks if keys are pressed from the Input manager. Must be called on Update
    public void GetKeys()
    {
        //Debug.Log(Time.timeScale);

        if (Input.GetKeyDown(currentKeys[0]))
        {
            player.movement.jump();
        }        
        if (Input.GetKey(currentKeys[2]))
        {
            TargetForAxis(-1);            
        }
        if (Input.GetKey(currentKeys[3]))
        {
            TargetForAxis(1);
        }
        if (!Input.GetKey(currentKeys[2])&&!Input.GetKey(currentKeys[3]))
        {
            TargetForAxis(0);
        }
        if (Input.GetKeyDown("r")&&player.dead)
        {
            player.action.Revive();
        }
    }

    //moves the axis 1 sensibility closer to the target number
    public void TargetForAxis(int target)
    {

        switch (target)
        {
            case 1:
                axis += axisSensibility;
                if (axis > 1)
                {
                    axis=1;
                }
                break;
            case -1:
                axis -= axisSensibility;
                if (axis < -1)
                {
                    axis = -1;
                }
                break;
            case 0:
                if (axis > 0)
                {
                    axis -= axisSensibility*2;
                    if (axis < 0.1)
                    {
                        axis = 0;
                    }
                }
                else if(axis < 0)
                {
                    axis += axisSensibility*2;
                    if (axis > -0.1)
                    {
                        axis = 0;
                    }
                }
                else
                {
                    axis = 0;
                }
                break;
        }
    }

    //changes controls or mappings randonly over random time
    IEnumerator RandomizeControls()
    {
        while (true)
        {            
            float rnd = Random.Range(rndTimeRange[0], rndTimeRange[1]);
            yield return new WaitForSecondsRealtime(rnd);
            //Debug.Log("changed");
            int controlsIndex = Random.Range(0, keys.Length);
            currentKeys = keys[controlsIndex];
            //ui.ColorSwap(controlsIndex);
            lights.ChangeLights(controlsIndex);
        }
    }


}
