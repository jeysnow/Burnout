using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class AudioManager : MonoBehaviour
{
    public static AudioClip punch, growl, backgroundMusic, happy, angry, scared;
    static AudioSource audioSrc;
    static AudioSource audioSrcLoop;

    // Start is called before the first frame update
    void Start()
    {
        punch = Resources.Load<AudioClip>("punch1");
        growl = Resources.Load<AudioClip>("boss_growl");
        backgroundMusic = Resources.Load<AudioClip>("bgmusic");
        happy = Resources.Load<AudioClip>("HappySqueal");
        scared = Resources.Load<AudioClip>("ScaredSqueal");
        angry = Resources.Load<AudioClip>("AngrySqueal");

        audioSrcLoop = GetComponent<AudioSource>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame


    public static void PlayerBackgroundMusic()
    {
        audioSrcLoop.loop = true;
        audioSrcLoop.volume = 0.6f;
        audioSrcLoop.clip = backgroundMusic;
        audioSrc.Play();
    }

    public static void StopBackgroundMusic()
    {
        audioSrcLoop.Stop();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Punch":
                audioSrc.PlayOneShot(punch);
                break;
            case "Growl":
                audioSrc.PlayOneShot(growl);
                break;
            case "Happy":
                audioSrc.PlayOneShot(happy);
                break;
            case "Angry":
                audioSrc.PlayOneShot(angry);
                break;
            case "Scared":
                audioSrc.PlayOneShot(scared);
                break;

        }
    }
}
