using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreVolume : MonoBehaviour
{
    //public GameObject vol;
    public Slider bgm;
    public Slider effect;
    public float bgmvalue;
    public float effectvalue;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);    //prevent the volume game object destroy
    }

    void OnEnable()
    {
        bgm.onValueChanged.AddListener(delegate { Check(); });      //when the value is changed, update the value
        effect.onValueChanged.AddListener(delegate { Check(); });
    }

    public void Check()
    {
        bgmvalue = bgm.value;
        effectvalue = effect.value;
    }
}
