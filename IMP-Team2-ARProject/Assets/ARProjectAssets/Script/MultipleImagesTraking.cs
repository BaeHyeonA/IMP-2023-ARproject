using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MultipleImagesTraking : MonoBehaviour
{
    public PlaceablePrefab[] placeablePrefabs; //prefabs to appear depending on the image

    private ARTrackedImageManager _imageManager;
    public Dictionary<string, GameObject> spawnedObjects = new Dictionary<string, GameObject>(); //spawned objects

    void Awake()
    {
        _imageManager = GetComponent<ARTrackedImageManager>();

        //instantiate prefabs and make setActive to false
        foreach (PlaceablePrefab pp in placeablePrefabs)
        {
            GameObject go = Instantiate(pp.prefab, new Vector3(0, -100, 0), Quaternion.identity);
            go.SetActive(false);
            go.name = pp.name; //make gameobject's name as placeable prefab's name
            spawnedObjects.Add(go.name, go); //add to dictionary for management
        }
        spawnedObjects["bathbrush"].transform.Rotate(new Vector3(0, 0, -90));
    }

    private void OnEnable() 
    {
        _imageManager.trackedImagesChanged += OnImageChanged; //subscribe
    }
    private void OnDisable()
    {
        _imageManager.trackedImagesChanged -= OnImageChanged; //unsubscribe
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        // instantiate the prefab at the position of the tracked image when it is detected
        foreach (ARTrackedImage img in args.added)
        {
            updateObject(img);
        }

        // update the prefab position when the tracked image is updated (e.g. position is changed)
        foreach (ARTrackedImage img in args.updated)
        {
            updateObject(img);
        }

        // disable spawned objects when the tracked image is not tracked anymore
        foreach (ARTrackedImage img in args.removed)
        {
            spawnedObjects[img.referenceImage.name].SetActive(false);
        }
    }

    private void updateObject(ARTrackedImage img)
    {
        //get spawned object from dictionary
        GameObject obj = spawnedObjects[img.referenceImage.name]; 

        // tracking works well, show the object at the tracked image's position
        if (img.trackingState == TrackingState.Tracking)
        {
            // move the spawned gameobject on top of the marker.
            obj.transform.position = img.transform.position;
            obj.SetActive(true);
        }
        // The tracking works somehow but may be poor quality, disable the spawned object then.
        else if (img.trackingState == TrackingState.Limited)
        {
            obj.SetActive(false);
        }
        // trackingState == None, disable the object
        else
        {
            obj.SetActive(false);
        }
    }
    
}

[System.Serializable]
public struct PlaceablePrefab
{
    public string name;
    public GameObject prefab;
}