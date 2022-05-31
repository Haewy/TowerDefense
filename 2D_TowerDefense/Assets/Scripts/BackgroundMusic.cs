using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //IF there is non instance, this instance will be created
        if (instance == null) { instance = this; }
        //IF there is already an instance of this, the second instance will detroy itself
        else { Destroy(gameObject); }
    }
}
