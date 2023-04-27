using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shoot : MonoBehaviour
{
    public GameObject Duck;
    public Camera arcamera;
    Rigidbody rb;

    public Slider slider;

    public LayerMask shootable;
    public float range = 500;
    bool check;
    public Vector3 position;
    public Quaternion rotation;

    public float shootLiking;

    void Start()
    {
        DontDestroyOnLoad(this);
        check = false;
        position = Duck.transform.position;
        rotation = Duck.transform.rotation;
    }

    void Update()
    {
        shootLiking = slider.value;
        if(check)
        {
            Duck.transform.Translate(0.001f,0,0);
        }else{
            Duck.transform.Translate(-0.001f,0,0);
        }

        if(Duck.transform.position.x > 0.4)
        {
            check = true;
        }
        else if(Duck.transform.position.x < -0.4)
        {
            check = false;
        }

        if(Duck.transform.position.z > 4)
        {
            Duck.transform.position = position;
            Duck.transform.rotation = rotation;
            Duck.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            Duck.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
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
            Duck.transform.rotation = rotation;
            Duck.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            Duck.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
            slider.value += 0.05f;
        }
    }

    public void back()
    {
        if(GameObject.Find("White"))
        {
            if(GameObject.Find("Rabby_Young_White"))
            {
                Destroy(GameObject.Find("Rabby_Young_White"));
            }
            if(GameObject.Find("Rabby_White 1"))
            {
                Destroy(GameObject.Find("Rabby_White 1"));
            }
            SceneManager.LoadScene("White");
        }

        if(GameObject.Find("Brown"))
        {
            if(GameObject.Find("Rabby_Young_Brown"))
            {
                Destroy(GameObject.Find("Rabby_Young_Brown"));
            }
            if(GameObject.Find("Rabby_Brown 1"))
            {
                Destroy(GameObject.Find("Rabby_Brown 1"));
            }
            SceneManager.LoadScene("Brown");
        }

        if(GameObject.Find("Green"))
        {
            if(GameObject.Find("Rabby_Young_Green"))
            {
                Destroy(GameObject.Find("Rabby_Young_Green"));
            }
            if(GameObject.Find("Rabby_Green 1"))
            {
                Destroy(GameObject.Find("Rabby_Green 1"));
            }
            SceneManager.LoadScene("Green");
        }
    }

}
