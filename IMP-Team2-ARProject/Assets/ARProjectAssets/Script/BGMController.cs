using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMController : MonoBehaviour
{
    public GameObject BGM;
    public AudioSource audio;

    void Start()
    {
        audio = BGM.GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (audio.isPlaying) return;
        else
        {
            audio.Play();
        }
    }
}
