using UnityEngine;
using UnityEngine.UI;

public abstract class HealthBar : MonoBehaviour
{
    public Image healthBarFill;
    public Slider healthBarSlider;
    public Gradient healthGradient;

    public virtual void SetMaxHealth(float maxHealth)
    {
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = maxHealth;

        healthBarFill.color = healthGradient.Evaluate(1f);
    }

    public virtual void SetCurrentHealth(float currentHealth)
    {
        healthBarSlider.value = currentHealth;
        healthBarFill.color = healthGradient.Evaluate(healthBarSlider.normalizedValue);
    }
}
