﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[ExecuteInEditMode]
public class SliderFillImage : MonoBehaviour {

    [SerializeField]
    private Slider _slider;

    private Image _image;

    public Slider Slider
    {
        get
        {
            return _slider;
        }
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _slider.onValueChanged.AddListener(delegate { SetFill(); });
        SetFill();
    }

    public void SetFill()
    {
        _image.fillAmount = _slider.normalizedValue;
    }

    public void SetFill(float fill)
    {
        _image.fillAmount = Mathf.Clamp01(fill);
    }
}
