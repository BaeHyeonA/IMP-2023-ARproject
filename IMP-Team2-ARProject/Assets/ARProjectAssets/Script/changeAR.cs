using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeAR : MonoBehaviour
{
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
            SceneManager.LoadScene("White");
        }

        if(twoclick)
        {
            SceneManager.LoadScene("Brown");
        }

        if(threeclick)
        {
            SceneManager.LoadScene("Green");
        }
    }
}
