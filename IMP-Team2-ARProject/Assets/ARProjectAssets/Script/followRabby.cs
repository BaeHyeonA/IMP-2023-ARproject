using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followRabby : MonoBehaviour
{
    public GameObject rabby;
    void Update()
    {
        transform.position = rabby.transform.position;
    }
}
