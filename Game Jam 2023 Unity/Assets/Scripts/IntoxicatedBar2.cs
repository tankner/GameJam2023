using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntoxicatedBar2 : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Floor floor;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 100;
        slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = floor.getCount();

        if (slider.value == 30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
