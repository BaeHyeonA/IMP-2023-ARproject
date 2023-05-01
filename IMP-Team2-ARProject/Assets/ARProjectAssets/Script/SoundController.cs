using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bgm;
    public Slider effect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBGM()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(bgm.value) * 20);    //control the bgm sound
    }

    public void SetEffect()
    {
        audioMixer.SetFloat("Effect", Mathf.Log10(effect.value) * 20);  //control the effect sound
    }
}
