using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlaneDetect : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject indicator;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject pet1; //step 1 pet
    public GameObject pet2; //step 2 pet
    public GameObject pet3; //step 3 pet
    public Camera camera;
    public GameObject pet;
    public bool condition = true;   //check indicator condition
    public bool check = true;   //check touch condition
    public bool check1 = true;  //make only one step 2 pet
    public bool check2 = true;  //make only one step 3 pet
    public bool step1 = true;
    public bool step2 = false;
    public Slider slider;

    void Start()
    {
        Transform target = camera.transform;

        raycastManager = FindObjectOfType<ARRaycastManager>();
        indicator = transform.GetChild(0).gameObject;   //get the child of PlaneDetect object
    }

    void Update()
    {
        Transform target = camera.transform;

        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            transform.position = hits[0].pose.position;
            indicator.SetActive(condition);  //when the plane is detected, indicator is visible
                                             //true but when check is false, condition is false
        }
        else
        {
            indicator.SetActive(false); //when the plane is not detected, indicator is invisible
        }


        if (check == true)
        {
            if (indicator.activeSelf && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                pet1.SetActive(true);   //step 1 pet is visible
                pet1.transform.position = transform.position;
                pet1.transform.LookAt(camera.transform);
                pet1.SetActive(true);

                check = false;  //stop creating step 1 pet
                condition = false;  //stop showing indicator
            }
        }

        if (slider.value >= 0.5)
        {
            step1 = false;
            step2 = true;
            pet1.SetActive(false);  //step 1 pet is invisible
            pet2.transform.position = pet1.transform.position;  //step 2 pet use the same position with step 1 pet
            pet2.transform.rotation = pet1.transform.rotation;
            pet2.SetActive(true);   //step 2 pet is visible
        }

        if (slider.value >= 0.99)
        {
            pet2.SetActive(false);  //step 2 pet is invisible
            pet3.transform.position = pet2.transform.position;  //step 3 pet use the same position with step 2 pet
            pet3.transform.rotation = pet2.transform.rotation;
            pet3.SetActive(true);   //step 3 pet is visible

            //Call after function time delay
            Invoke("finalScene", 5);
        }
    }

    //Final scene conversion according to pet type
    void finalScene()
    {
        if(pet3 == GameObject.Find("Rabby_Queen_Brown"))
        {
            SceneManager.LoadScene("Brown_Final");
        }
        if (pet3 == GameObject.Find("Rabby_Queen_White"))
        {
            SceneManager.LoadScene("White_Final");

        }
        if (pet3 == GameObject.Find("Rabby_Queen_Green"))
        {
            SceneManager.LoadScene("White_Final");

        }
    }
}