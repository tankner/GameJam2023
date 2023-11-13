using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntoxicatedBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private GameObject floor;

    public void setMaxLiquor(int liquor)
	{
        slider.maxValue = liquor;
        slider.value = liquor;
	}

    public void SetLiquor(int liquor)
	{
        slider.value = liquor;
	}
    
}
