using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPersistentData : MonoBehaviour
{
    public static MyPersistentData instance;

    public bool replay = false;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance != this && instance != null)
        {
            Destroy(this.gameObject);
            Debug.Log("trying to die");
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
