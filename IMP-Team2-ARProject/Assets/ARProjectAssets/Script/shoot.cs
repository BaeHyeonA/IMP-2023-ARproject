using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    public GameObject rabby;
    public Camera arcamera;
    public LayerMask shootable;
    public Button PlayButton;
    public Button BackButton;
    public AudioSource audioSource;
    public Slider slider; //liking value

    private float range = 500;

    private float movedir = -1; //move direction of rubberduck


    void Update()
    {
        //rubberDuck repeat from side to side
        if (transform.position.x > 0.15)
        {
            movedir = -1;
        }
        else if (transform.position.x < -0.15)
        {
            movedir = 1;
        }
        transform.Translate(0.001f * movedir, 0, 0);

        // return rubberduck's posiion when fly far away
        if (transform.position.z > 2)
        {
            transform.position = rabby.transform.position + new Vector3(0, 0, -0.5f);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        //Trowimg rubberDuck using touch
        RaycastHit hit;  
        for(int i = 0; i < Input.touchCount; ++i)
        {
            if(Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = arcamera.ScreenPointToRay(Input.GetTouch(0).position);

                if(Physics.Raycast(ray, out hit, range, shootable)) //when ray touches shootable layer
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        GetComponent<Rigidbody>().AddForce(Vector3.forward * 50f); //trowing rubberDuck
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pet")) //if rubberDuck touches rabby
        {
            audioSource.Play();//Play sound when it collides with rubberduck
            Debug.Log("Bomb");

            // return rubberduck's posiion
            transform.position = rabby.transform.position + new Vector3(0, 0, -0.5f);
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            //increase liking value
            slider.value += 0.05f;
        }
    }

    public void back()//when click backButton
    {
        this.gameObject.SetActive(false); //hide rubburDuck 
        PlayButton.gameObject.SetActive(true); //show playButton
        BackButton.gameObject.SetActive(false); //hide backButton
    }
    public void play()//when click playButton
    {
        this.gameObject.SetActive(true); //show rubburDuck 
        PlayButton.gameObject.SetActive(false); //hide playButton
        BackButton.gameObject.SetActive(true); //show backButton
        transform.position = rabby.transform.position + new Vector3(0, 0, -0.5f);//set rubburDuck's posiion
    }

}
