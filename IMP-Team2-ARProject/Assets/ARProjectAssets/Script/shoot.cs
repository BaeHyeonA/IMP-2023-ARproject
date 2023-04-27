using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    public GameObject Duck;
    public Camera arcamera;
    Rigidbody rb;

    public LayerMask shootable;
    public float range = 500;
    bool check;
    public Vector3 position;
    public Quaternion rotation;

    public Slider slider2;

    void Start()
    {
        check = false;
        position = Duck.transform.position;
        rotation = Duck.transform.rotation;
    }

    void Update()
    {
        if(check)
        {
            Duck.transform.Translate(0.001f,0,0);
        }else{
            Duck.transform.Translate(-0.001f,0,0);
        }

        if(Duck.transform.position.x > 0.2)
        {
            check = true;
        }
        else if(Duck.transform.position.x < -0.2)
        {
            check = false;
        }

        if(Duck.transform.position.z > 4)
        {
            Duck.transform.position = position;
            Duck.GetComponent<Rigidbody>().AddForce(-transform.up * 100f);
        }

        RaycastHit hit;

        for(int i = 0; i < Input.touchCount; ++i)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = arcamera.ScreenPointToRay(Input.GetTouch(0).position);

                if(Physics.Raycast(ray, out hit, range, shootable))
                {
                    if(hit.collider.gameObject == Duck)
                    {
                        Debug.Log("hit1");
                        Duck.GetComponent<Rigidbody>().AddForce(transform.up * 100f);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pet"))
        {
            Debug.Log("Bomb");
            Duck.transform.position = position;
            Duck.GetComponent<Rigidbody>().AddForce(-transform.up * 100f);
            slider2.value += 0.05f;
        }
    }
}
