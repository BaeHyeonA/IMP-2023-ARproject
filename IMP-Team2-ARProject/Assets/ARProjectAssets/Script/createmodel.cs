using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class createmodel : MonoBehaviour
{   
    public GameObject checkmodel;

    bool one;
    bool two;
    bool three;
    // Start is called before the first frame update

    public GameObject onemodel;
    public GameObject twomodel;
    public GameObject threemodel;


    void Start()
    {
        checkmodel = GameObject.Find("click");
        create();
    }

    public void create()
    {
        changeAR script = checkmodel.GetComponent<changeAR>();

        one = script.oneclick;
        two = script.twoclick;
        three = script.oneclick;

        if(one)
        {
            Instantiate(onemodel,new Vector3(0,0,1), Quaternion.identity);
        }else if(two){
            Instantiate(twomodel,new Vector3(0,0,1), Quaternion.identity);
        }else if(three){
            Instantiate(threemodel,new Vector3(0,0,1), Quaternion.identity);
        }

    }
}
