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
        vol = GameObject.Find("Volume");
        StoreVolume bgmScript = vol.GetComponent<StoreVolume>();
        bgmScript.Update();

        bgm.value = bgmScript.bgmvalue;
        effect.value = bgmScript.effectvalue;
    }

    // Update is called once per frame
    void Update()
    {
        /*vol = GameObject.Find("Volume");
        StoreVolume bgmScript = vol.GetComponent<StoreVolume>();
        bgmScript.Update();

        bgm.value = bgmScript.bgmvalue;
        effect.value = bgmScript.effectvalue;*/
    }
}
