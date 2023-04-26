using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MultipleImagesTraking : MonoBehaviour
{
    public PlaceablePrefab[] placeablePrefabs;

    private ARTrackedImageManager _imageManager;
    public Dictionary<string, GameObject> spawnedObjects = new Dictionary<string, GameObject>();

    void Awake()
    {
        _imageManager = GetComponent<ARTrackedImageManager>();

        foreach (PlaceablePrefab pp in placeablePrefabs)
        {
            GameObject go = Instantiate(pp.prefab, new Vector3(0, -100, 0), Quaternion.identity);
            go.SetActive(false);
            go.name = pp.name;
            spawnedObjects.Add(go.name, go);
        }
        spawnedObjects["bathbrush"].transform.Rotate(new Vector3(0, 0, -90));
    }

    private void OnEnable()
    {
        _imageManager.trackedImagesChanged += OnImageChanged;
    }
    private void OnDisable()
    {
        _imageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(ARTrackedImage img in args.added)
        {
            updateObject(img);
        }
        foreach (ARTrackedImage img in args.updated)
        {
            updateObject(img);
        }
        foreach (ARTrackedImage img in args.removed)
        {
            spawnedObjects[img.referenceImage.name].SetActive(false);
        }
    }

    private void updateObject(ARTrackedImage img)
    {
        GameObject obj = spawnedObjects[img.referenceImage.name];

        if(img.trackingState == TrackingState.Tracking)
        {
            obj.transform.position = img.transform.position;
            obj.SetActive(true);
        }
        else if(img.trackingState == TrackingState.Limited)
        {
            obj.SetActive(false);
        }
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