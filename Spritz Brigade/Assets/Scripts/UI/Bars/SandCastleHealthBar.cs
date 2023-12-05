using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCastleHealthBar : HealthBar
{
    private Canvas _canvas;

    private void Awake()
    {
        if (GameObject.FindWithTag("Canvas").TryGetComponent<Canvas>(out _canvas))
        {
            transform.SetParent(_canvas.transform, false);

            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector3(0f, -440f, 0f);
        }
    }
}
