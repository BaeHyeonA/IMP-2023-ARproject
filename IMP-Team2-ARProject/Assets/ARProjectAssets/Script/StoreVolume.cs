using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreVolume : MonoBehaviour
{
    public GameObject vol;
    public Slider bgm;
    public Slider effect;
    public float bgmvalue;
    public float effectvalue;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        vol = GameObject.Find("Volume");
    }

    public void Update()
    {
        bgmvalue = bgm.value;
        effectvalue = effect.value;
    }
}
