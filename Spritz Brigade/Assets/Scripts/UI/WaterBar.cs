using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    public Image waterhBarFill;
    public Slider waterBarSlider;

    private Canvas _canvas;

    private void Awake()
    {
        if (GameObject.FindWithTag("Canvas").TryGetComponent<Canvas>(out _canvas))
        {
            transform.SetParent(_canvas.transform, false);

            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector3(181f, -44f, 0f);
        }
    }

    public virtual void SetMaxWaterAmmo(float maxWaterAmmo)
    {
        waterBarSlider.maxValue = maxWaterAmmo;
        waterBarSlider.value = maxWaterAmmo;
    }

    public virtual void SetCurrentWaterAmmo(float currentWaterAmmo)
    {
        waterBarSlider.value = currentWaterAmmo;
    }
}
