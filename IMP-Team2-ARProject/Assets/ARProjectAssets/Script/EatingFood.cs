using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EatingFood : MonoBehaviour
{
    public Slider slider; //liking value
    public ParticleSystem bubble; //bubble particle
    public GameObject color;
    public AudioSource audio;
    public AudioSource audio2;
    public AudioSource audio3;



    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(color);
    }

    private void Update()
    {
        //setting position
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            transform.position = new Vector3(0, -0.35f, 3);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("food")) //when rabby eats food (& takes a wash)
        {
            // apple and banana increase liking value by 0.05
            if (collision.gameObject.name == "apple" || collision.gameObject.name == "banana") 
            {
                audio2.Play();
                slider.value += 0.05f;
            }

            // carrot decreases liking value by 0.05
            else if (collision.gameObject.name == "carrot")
            {
                audio.Play();
                slider.value -= 0.05f;
            }

            // hamburger and pizza increase liking value by 0.1
            else if (collision.gameObject.name == "hamburger" || collision.gameObject.name == "pizza")
            {
                audio2.Play();
                slider.value += 0.1f;
            }

            // bathbrush increases liking value by 0.05 and plays bubble particle
            else if (collision.gameObject.name == "bathbrush")
            {
                audio3.Play();
                bubble.Play();
                slider.value += 0.1f;
            }

        }
    }

}
