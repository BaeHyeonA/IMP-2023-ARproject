using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool white;
    public bool brown;
    public bool green;

    public GameObject white1;
    public GameObject white2;
    public GameObject green1;
    public GameObject green2;
    public GameObject brown1;
    public GameObject brown2;

    public GameObject plane;
    public PlaneDetect planede;
    bool check1;
    bool check2;

    void Start()
    {
        white1.SetActive(false);
        white2.SetActive(false);
        brown1.SetActive(false);
        brown2.SetActive(false);
        green1.SetActive(false);
        green2.SetActive(false);

        planede = plane.GetComponent<PlaneDetect>();
        check1 = planede.check1;
        check2 = planede.check2;
    }

    public void whiteload()
    {
        if (white == false)
        {
            white = true;
        }
    }

    public void brownload()
    {
        if (brown == false)
        {
            brown = true;
        }
    }

    public void greenload()
    {
        if (green == false)
        {
            green = true;
        }
    }

    public void active()
    {
        if(check1 == true && white == true)
        {
            white1.SetActive(true);
        }

        if(check2 == true && white == true)
        {
            white2.SetActive(true);
        }

        if (check1 == true && brown == true)
        {
            brown1.SetActive(true);
        }

        if (check2 == true && brown == true)
        {
            brown2.SetActive(true);
        }

        if (check1 == true && green == true)
        {
            green1.SetActive(true);
        }

        if (check2 == true && green == true)
        {
            green2.SetActive(true);
        }
    }

    public void change()
    {
        SceneManager.LoadScene("MainShoot");
    }
}