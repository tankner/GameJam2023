using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntoxicatedBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    
    
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
