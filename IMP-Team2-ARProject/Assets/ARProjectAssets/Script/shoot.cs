using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shoot : MonoBehaviour
{
    public GameObject rabby;
    public Camera arcamera;
    public LayerMask shootable;
    public Button PlayButton;
    public Button BackButton;

    private float range = 500;
    private float movedir = -1;

    public Slider slider;

    void Update()
    {
        if (transform.position.x > 0.15)
        {
            movedir = -1;
        }
        else if (transform.position.x < -0.15)
        {
            movedir = 1;
        }
        transform.Translate(0.001f * movedir, 0, 0);

        if (transform.position.z > 2)
        {
            transform.position = rabby.transform.position + new Vector3(0, 0, -0.5f);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        RaycastHit hit;

        for(int i = 0; i < Input.touchCount; ++i)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = arcamera.ScreenPointToRay(Input.GetTouch(0).position);

                if(Physics.Raycast(ray, out hit, range, shootable))
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        GetComponent<Rigidbody>().AddForce(Vector3.forward * 50f);
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
            transform.position = rabby.transform.position + new Vector3(0, 0, -0.5f);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            slider.value += 0.05f;
        }
    }

    public void back()
    {
        this.gameObject.SetActive(false);
        PlayButton.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(false);
    }
    public void play()
    {
        this.gameObject.SetActive(true);
        PlayButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(true);
        transform.position = rabby.transform.position + new Vector3(0, 0, -0.5f);
    }

}
