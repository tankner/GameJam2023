using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntoxicatedBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private Floor floor;

    public void setMaxLiquor()
	{
        slider.maxValue = 10;
        slider.value = 0;
	}

    public void SetLiquor()
	{
        slider.value = floor.getCount();
	}
    
}
