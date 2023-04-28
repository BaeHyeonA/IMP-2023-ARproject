using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class followRabby : MonoBehaviour
{
    public GameObject rabby;

    void Update()
    {
        transform.position = rabby.transform.position;
    }

}
