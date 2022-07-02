using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text txtTimer;
    public float time;
    public bool gameON;
    // Start is called before the first frame update
    void Start()
    {
        txtTimer = GetComponent<Text>();
        gameON = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameON)
        {
            time += Time.deltaTime;
            txtTimer.text = time.ToString("F2");
        }
        else
        {
            //nothing
        }
    }
}
