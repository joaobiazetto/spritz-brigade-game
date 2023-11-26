using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;

    public Image fill;
    
    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetCurrentHealth(float maxHealth)
    {
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
