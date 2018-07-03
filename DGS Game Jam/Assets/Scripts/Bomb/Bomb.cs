﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colors;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Bomb : MonoBehaviour {

    [SerializeField]
    private SliderFillImage _cyanFill, _magentaFill, _yellowFill;

    [SerializeField]
    private SpriteRenderer _colorSprite;
    [SerializeField]
    private float _decay, _force;
    [SerializeField]
    private ParticleSystem thrust, content;
    [SerializeField]
    private BombColors _bombColors;

    public delegate void BombFireEventHandler();
    public static event BombFireEventHandler onFire;

    private float _cyan, _magenta, _yellow;
    private bool isFired;
    private Rigidbody2D _rigidbody2D;
    private ParticleSystem[] _thrustChildren;



    public Color CurrentColor { get { return this._bombColors.CurrentColorValue; } }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.isKinematic = true;
        _thrustChildren = thrust.GetComponentsInChildren<ParticleSystem>();
        _bombColors.OnEmpty += OnEmpty;
    }

    public void Fire()
    {
        onFire?.Invoke();
        thrust.Play();
        _rigidbody2D.isKinematic = false;
        GetAmounts();
        Dictionary<Color, float> temp = new Dictionary<Color, float>() { { Color.cyan, _cyan},
                                                                         { Color.magenta, _magenta},
                                                                         { Color.yellow, _yellow}};
        _bombColors = new BombColors(temp);
        isFired = true;
    }

    private void FixedUpdate()
    {
        if (isFired)
        {
            if (_bombColors.CurrentThrust > 0)
            {
                foreach(ParticleSystem p in _thrustChildren)
                {
                    p.SetStartColor(_bombColors.CurrentColorValue);
                }
                thrust.SetStartColor(_bombColors.CurrentColorValue);
                Drain();
                _rigidbody2D.AddForce(-transform.up * _bombColors.CurrentThrust * _force, ForceMode2D.Force);
            }
        }
        
    }

    private void OnEmpty(object sender, EventArgs e)
    {
        Debug.Log(1);
        thrust.Stop();
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
        _cyanFill.Slider.value = _bombColors.GetAmount(Color.cyan);
        _magentaFill.Slider.value = _bombColors.GetAmount(Color.magenta);
        _yellowFill.Slider.value = _bombColors.GetAmount(Color.yellow);
        _colorSprite.color = _bombColors.CurrentColorValue;
    }
}
