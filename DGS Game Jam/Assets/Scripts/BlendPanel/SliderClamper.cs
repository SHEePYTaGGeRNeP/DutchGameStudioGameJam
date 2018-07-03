using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderClamper : MonoBehaviour {

    [SerializeField]
    SliderPreviousValue[] _sliders;
    [SerializeField]
    int _maxTotal;

    private void Awake()
    {
       foreach(SliderPreviousValue s in _sliders)
        {
            s.Slider.onValueChanged.AddListener(delegate{ ClampSlider(); });
        }
    }

    private void ClampSlider()
    {
        if(SlideTotal() > 1)
        {
            SetSlidersToPreviousValue();
            return;
        }
        SetSliderPreviousValueToCurrent();
    }

    private float SlideTotal()
    {
        float total = 0;
        foreach (SliderPreviousValue s in _sliders)
        {
            total += s.Slider.normalizedValue;
        }
        Debug.Log(total);
        return total;
    }

    private void SetSlidersToPreviousValue()
    {
        foreach (SliderPreviousValue s in _sliders)
        {
            s.SetSliderToPreviousValue();
        }
    }

    private void SetSliderPreviousValueToCurrent()
    {
        foreach (SliderPreviousValue s in _sliders)
        {
            s.SetPreviousValueToCurrent();
        }
    }

    [System.Serializable]
    private class SliderPreviousValue
    {
        [SerializeField]
        private Slider _slider;

        private int _previousValue;

        public Slider Slider
        {
            get
            {
                return _slider;
            }
        }

        public void SetPreviousValueToCurrent()
        {
            _previousValue = (int)_slider.value;
        }

        public void SetSliderToPreviousValue()
        {
            _slider.value = _previousValue;
        }
    }


}
