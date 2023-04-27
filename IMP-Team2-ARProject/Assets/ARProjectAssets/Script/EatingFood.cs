using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EatingFood : MonoBehaviour
{
    public Slider slider;
    public ParticleSystem bubble;
    public GameObject color;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(color);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            transform.position = new Vector3(0, -0.35f, 3);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            //È¿°úÀ½
            Debug.Log(collision.gameObject.name);

            if (collision.gameObject.name == "apple" || collision.gameObject.name == "banana")
            {
                Debug.Log(collision.gameObject.name + "+1");
                slider.value += 0.05f;                
            }
            else if (collision.gameObject.name == "carrot")
            {
                Debug.Log(collision.gameObject.name + "-1");
                slider.value -= 0.05f;                
            }
            else if (collision.gameObject.name == "hamburger" || collision.gameObject.name == "pizza")
            {
                Debug.Log(collision.gameObject.name + "+2");
                slider.value += 0.1f;                
            }
            else if (collision.gameObject.name == "bathbrush")
            {
                slider.value += 0.1f;
                bubble.Play();                
            }

        }
    }

}
