using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : HealthBar
{
    private Canvas _canvas;

    private void Awake()
    {
        if (GameObject.FindWithTag("Canvas").TryGetComponent<Canvas>(out _canvas))
        {
            transform.SetParent(_canvas.transform, false);

            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector3(181f, -30f, 0f);
        }
    }
}
