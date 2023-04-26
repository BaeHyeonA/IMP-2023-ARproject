using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject CreditPanel;
    public AudioSource audio;
    //public AudioClip ClickSound;

    // Start is called before the first frame update
    void Start()
    {
        OptionPanel.SetActive(false);
        CreditPanel.SetActive(false);
        //audio.clip = ClickSound;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBtn()
    {
        audio.Play();
        SceneManager.LoadScene("SampleScene"); //move to select scene
    }

    public void OptBtn()
    {
        audio.Play();
        OptionPanel.SetActive(true);
    }

    public void CredBtn()
    {
        audio.Play();
        CreditPanel.SetActive(true);
    }

    public void OptOut()
    {
        audio.Play();
        OptionPanel.SetActive(false);
    }

    public void CredOut()
    {
        audio.Play();
        CreditPanel.SetActive(false);
    }
}
