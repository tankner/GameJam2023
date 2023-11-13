using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }
}
