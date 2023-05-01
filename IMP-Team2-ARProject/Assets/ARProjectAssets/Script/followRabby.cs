using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class followRabby : MonoBehaviour
{
    public GameObject rabby;

    void Update()
    {
        //set the bubble particle is in the rabby's position
        transform.position = rabby.transform.position;
    }

}
