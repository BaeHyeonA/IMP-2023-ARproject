using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeAR : MonoBehaviour
{
    public bool oneclick;
    public bool twoclick;
    public bool threeclick;

    //Run when white pets are selected
    public void oneload(){
        if(oneclick == false){
            oneclick = true;
            twoclick = false;
            threeclick = false;
        }
    }
    //Run when brown pets are selected
    public void twoload(){
        if(twoclick == false){
            oneclick = false;
            twoclick = true;
            threeclick = false;
        }
    }
    //Run when green pets are selected
    public void threeload(){
        if(threeclick == false){
            oneclick = false;
            twoclick = false;
            threeclick = true;
        }
    }

    public void changescene(){

        //Switch to white scene when white pet is selected
        if (oneclick)
        {
            SceneManager.LoadScene("White");
        }
        //Switch to brown scene when brown pet is selected
        if (twoclick)
        {
            SceneManager.LoadScene("Brown");
        }
        //Switch to green scene when green pet is selected
        if (threeclick)
        {
            SceneManager.LoadScene("Green");
        }
    }
}
