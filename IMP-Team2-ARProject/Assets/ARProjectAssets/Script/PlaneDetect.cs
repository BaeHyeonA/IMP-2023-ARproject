using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

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
        indicator = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        Transform target = camera.transform;

        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            transform.position = hits[0].pose.position;
            //transform.rotation = hits[0].pose.rotation;

            //pet1.transform.Rotate(0, 150f, 0);
            //pet1.transform.LookAt(camera.transform);
            
            indicator.SetActive(condition);  //true but when check is false, condition is false
        }
        else
        {
            indicator.SetActive(false);
        }


        if (check == true)
        {
            if (indicator.activeSelf && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //pet = Instantiate(pet1, transform.position, transform.rotation);
                pet1.SetActive(true);
                pet1.transform.position = transform.position;
                //pet1.transform.rotation = transform.rotation;
                pet1.transform.LookAt(camera.transform);
                pet1.SetActive(true);

                check = false;
                condition = false;
            }
        }

        if (slider.value >= 0.5)
        {
            step1 = false;
            step2 = true;
            //pet.SetActive(false);
            //pet2.SetActive(true);   // step 2 pet is active
            //if (check1 == true)
            //{
            //    Instantiate(pet2, pet.transform.position, pet.transform.rotation);
            //    check1 = false;
            //}
            //pet2.transform.localScale = pet.transform.localScale;
            pet1.SetActive(false);
            pet2.transform.position = pet1.transform.position;
            pet2.transform.rotation = pet1.transform.rotation;
            pet2.SetActive(true);
        }

        if (slider.value >= 0.99)
        {
            //pet2.SetActive(false);
            //pet3.SetActive(true);   // step 3 pet is active
            //if (check2 == true)
            //{
            //    Instantiate(pet3, pet.transform.position, pet.transform.rotation);
            //    check2 = false;
            //}
            //pet3.transform.localScale = pet2.transform.localScale;

            //slider.value = 0;
            pet2.SetActive(false);
            pet3.transform.position = pet2.transform.position;
            pet3.transform.rotation = pet2.transform.rotation;
            pet3.SetActive(true);
        }
    }
}