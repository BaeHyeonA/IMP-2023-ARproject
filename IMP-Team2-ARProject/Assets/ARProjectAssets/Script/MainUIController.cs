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

    // Start is called before the first frame update
    void Start()
    {
        OptionPanel.SetActive(false);
        CreditPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBtn()  //when click the start button
    {
        audio.Play();
        SceneManager.LoadScene("Select"); //move to select scene
    }

    public void OptBtn()    //when click the option button
    {
        audio.Play();
        OptionPanel.SetActive(true);
    }

    public void CredBtn()   //when click the credit button
    {
        audio.Play();
        CreditPanel.SetActive(true);
    }

    public void OptOut()    //when click the close button in option panel
    {
        audio.Play();
        OptionPanel.SetActive(false);
    }

    public void CredOut()   //when click the close button in credit panel
    {
        audio.Play();
        CreditPanel.SetActive(false);
    }
}
