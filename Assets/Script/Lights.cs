using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private Player player;
    private SpriteRenderer[] lightSprites;
    private int lastLight=999;
    [SerializeField]
    private Color[] lightColors = new Color[3];
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        player.control.lights = this;
        lightSprites = GetComponentsInChildren<SpriteRenderer>();

    }

    public void ChangeLights(int colorNumber)
    {
        if(lastLight != colorNumber)
        {
            switch (colorNumber)
            {
                case 0:
                    AudioManager.PlaySound("Angry");
                    break;
                case 1:
                    AudioManager.PlaySound("Scared");
                    break;
                case 2:
                    AudioManager.PlaySound("Happy");
                    break;
                default:
                    AudioManager.PlaySound("Happy");
                    break;
            }
        }

        lastLight = colorNumber;

        foreach (SpriteRenderer s in lightSprites)
        {
            s.color = lightColors[colorNumber];
        }
    }
}
