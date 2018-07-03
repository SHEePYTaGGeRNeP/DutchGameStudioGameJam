using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colors;

[RequireComponent(typeof(Rigidbody2D))]
public class Bomb : MonoBehaviour {

    [SerializeField]
    private SliderFillImage _cyanFill, _magentaFill, _yellowFill;
    [SerializeField]
    private float _decay, _force;

    private float _cyan, _magenta, _yellow;
    private bool isFired;
    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    private BombColors _bombColors;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.isKinematic = true;
    }

    public void Fire()
    {
        _rigidbody2D.isKinematic = false;
        GetAmounts();
        Dictionary<Color, float> temp = new Dictionary<Color, float>() { { Color.cyan, _cyan},
                                                                         { Color.magenta, _magenta},
                                                                         { Color.yellow, _yellow}};
        _bombColors = new BombColors(temp);
        isFired = true;
    }

    private void Update()
    {
        if (isFired)
        {
            Drain();
            if (_bombColors.CurrentThrust > 0)
            {
                _rigidbody2D.AddForce(-transform.up * _bombColors.CurrentThrust * _force, ForceMode2D.Force);
            }
        }
        
    }

    private void GetAmounts()
    {
        _cyan = _cyanFill.Slider.normalizedValue;
        _magenta = _magentaFill.Slider.normalizedValue;
        _yellow = _yellowFill.Slider.normalizedValue;
    }

    private void Drain()
    {
        _bombColors.DecreaseAll(_decay);
    }
}
