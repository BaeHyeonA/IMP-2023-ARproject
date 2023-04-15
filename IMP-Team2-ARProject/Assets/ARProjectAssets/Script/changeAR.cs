using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeAR : MonoBehaviour
{
    public GameObject onemodel;
    public GameObject twomodel;
    public GameObject threemodel;
    public GameObject click;

    public bool oneclick;
    public bool twoclick;
    public bool threeclick;

    public void oneload(){
        if(oneclick == false){
            oneclick = true;
            twoclick = false;
            threeclick = false;
        }
    }

    public void twoload(){
        if(twoclick == false){
            oneclick = false;
            twoclick = true;
            threeclick = false;
        }
    }

    public void threeload(){
        if(threeclick == false){
            oneclick = false;
            twoclick = false;
            threeclick = true;
        }
    }

    public void changescene(){
        
        if(oneclick)
        {
            Debug.Log("1");
        }

        if(twoclick)
        {
            Debug.Log("2");
        }

        if(threeclick)
        {
            Debug.Log("3");
        }

        if(oneclick || twoclick || threeclick){
            SceneManager.LoadScene("MainScene");
            DontDestroyOnLoad(click);
        }
    }
}
