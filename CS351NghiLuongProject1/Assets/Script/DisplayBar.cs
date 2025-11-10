using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBar : MonoBehaviour
{

    public Slider slider;

    public Gradient gradient;

    public Image fill;

    public void setValue(float value)
    {
        slider.value = value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxValue(float Value)
    {
        slider.maxValue = Value;
        slider.value = Value;
        fill.color = gradient.Evaluate(1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
