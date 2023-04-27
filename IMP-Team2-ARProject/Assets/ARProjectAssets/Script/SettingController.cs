using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public GameObject SettingPanel;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        SettingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBtn()
    {
        audio.Play();
        SettingPanel.SetActive(true);
    }

    public void SetOut()
    {
        audio.Play();
        SettingPanel.SetActive(false);
    }
}
