using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetection : MonoBehaviour
{
    public GameObject pet;

    private ARPlaneManager planeManager;
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public Camera camera;

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        Transform target = camera.transform;

        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            pet.SetActive(true);
            pet.transform.LookAt(target);
        }
        else
        {
            //pet.SetActive(false);
        }
    }
}
