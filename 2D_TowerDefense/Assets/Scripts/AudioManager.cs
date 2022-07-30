using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager i;

    public AudioSource audioSrc;
    //public AudioSource[] audioS;

    public AudioClip sOne, sTwo, sThree, sFour, sFive, sSix, sSeven, sEigth, sNine;

    public enum Sound { one =1 ,  two , three , four, five, six,seven, eigth, nine}
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
        sSeven = Resources.Load<AudioClip>("7");
        sEigth = Resources.Load<AudioClip>("8");
        sNine = Resources.Load<AudioClip>("9");
    }
    public void Play(Sound s)
    {
        // Start to fix volume problem
        audioSrc.volume = 1;
        switch (s)
        {
            
            case Sound.one:
                audioSrc.PlayOneShot(sOne,0.012f);//launch star from tower
           
                break;
            case Sound.two:
                audioSrc.PlayOneShot(sTwo,0.12f);//die, enemy dies
        
                break;
            case Sound.three:
                audioSrc.PlayOneShot(sThree,0.7f);//hit, enemy is hit

                break;
            case Sound.four:
                audioSrc.PlayOneShot(sFour);//not used        like a virtual drop
                
                break;
            case Sound.five:
                audioSrc.PlayOneShot(sFive);//game over
             
                break;
            case Sound.six:
                audioSrc.PlayOneShot(sSix);//not used         like clacking key

                break;            
            case Sound.seven:
                audioSrc.PlayOneShot(sSeven);//explosion less one in health

                break;    
            case Sound.eigth:
                audioSrc.PlayOneShot(sEigth);//not used       like a teeny explosion

                break;            
            case Sound.nine:
                audioSrc.PlayOneShot(sNine,0.2f);//add point when a sun is hit

                break;

            default:
                break;
        }
    }

}
