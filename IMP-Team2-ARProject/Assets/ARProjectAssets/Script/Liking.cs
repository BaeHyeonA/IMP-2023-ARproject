using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Liking : MonoBehaviour
{
    public Slider slider;
    public GameObject pet;
    public GameObject duck;

    public float shootLiking;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            if(GameObject.Find("Rabby_Young_White"))
            {
                pet = GameObject.Find("Rabby_Young_White");
                EatingFood liking = pet.GetComponent<EatingFood>();
                slider.value = liking.liking;
            }
            if(GameObject.Find("Rabby_White 1"))
            {
                pet = GameObject.Find("Rabby_White 1");
                EatingFood liking = pet.GetComponent<EatingFood>();
                slider.value = liking.liking;
            }

            if(GameObject.Find("Rabby_Young_Brown"))
            {
                pet = GameObject.Find("Rabby_Young_Brown");
                EatingFood liking = pet.GetComponent<EatingFood>();
                slider.value = liking.liking;
            }
            if(GameObject.Find("Rabby_Brown 1"))
            {
                pet = GameObject.Find("Rabby_Brown 1");
                EatingFood liking = pet.GetComponent<EatingFood>();
                slider.value = liking.liking;
            }

            if(GameObject.Find("Rabby_Young_Green"))
            {
                pet = GameObject.Find("Rabby_Young_Green");
                EatingFood liking = pet.GetComponent<EatingFood>();
                slider.value = liking.liking;
            }
            if(GameObject.Find("Rabby_Green 1"))
            {
                pet = GameObject.Find("Rabby_Green 1");
                EatingFood liking = pet.GetComponent<EatingFood>();
                slider.value = liking.liking;
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            // slider = GameObject.Find("Canvas").transform.Find("Slider");
            slider.value = duck.GetComponent<shoot>().shootLiking;
        }
    }
}
