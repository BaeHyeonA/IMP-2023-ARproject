using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public GameObject vol;
    public Slider bgm;
    public Slider effect;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        vol = GameObject.Find("Volume");
        StoreVolume bgmScript = vol.GetComponent<StoreVolume>();    //get the bgm & effect volume value

        bgm.value = bgmScript.bgmvalue;    //use the stored bgm sound value
        effect.value = bgmScript.effectvalue;   //use the stored effect sound value
    }
}
