using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
        
{

    public AudioClip musicClipOne;
    public AudioSource BackgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusic.clip = musicClipOne;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            BackgroundMusic.clip = musicClipOne;
            BackgroundMusic.Play();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            BackgroundMusic.clip = musicClipOne;
            BackgroundMusic.Play();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            BackgroundMusic.loop = true;
        }
    }
}
