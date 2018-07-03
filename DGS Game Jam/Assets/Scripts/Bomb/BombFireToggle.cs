using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFireToggle : MonoBehaviour {

    [SerializeField]
    private MonoBehaviour _component;

    private void Awake()
    {
        _component.enabled = false;
        Bomb.onFire += Enable;
    }

    private void Enable()
    {
        _component.enabled = true;
    }
}
