using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager i;

    public AudioSource audioSrc;
    //public AudioSource[] audioS;

    public AudioClip sOne, sTwo, sThree, sFour, sFive, sSix;

    public enum Sound { one =1 ,  two , three , four, five, six}
    // Start is called before the first frame update
    private void Awake()
    {
        if (i==null)
        {
            i = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        //audioS = new AudioSource[6];
        sOne = Resources.Load<AudioClip>("1");
        sTwo = Resources.Load<AudioClip>("2");
        sThree = Resources.Load<AudioClip>("3");
        sFour = Resources.Load<AudioClip>("4");
        sFive = Resources.Load<AudioClip>("5");
        sSix = Resources.Load<AudioClip>("6");
    }
    public void Play(Sound s)
    {
        // Start to fix volume problem
        audioSrc.volume = 1;
        switch (s)
        {
            
            case Sound.one:
                audioSrc.volume = 0.2f;
                audioSrc.PlayOneShot(sOne);
              
                break;
            case Sound.two:
                audioSrc.PlayOneShot(sTwo);
        
                break;
            case Sound.three:
                audioSrc.PlayOneShot(sThree);

                break;
            case Sound.four:
                audioSrc.PlayOneShot(sFour);
                
                break;
            case Sound.five:
                audioSrc.PlayOneShot(sFive);
             
                break;
            case Sound.six:
                audioSrc.PlayOneShot(sSix);

                break;
            default:
                break;
        }
    }

}
