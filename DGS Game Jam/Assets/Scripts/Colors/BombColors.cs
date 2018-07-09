using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Colors
{
    [System.Serializable]
    public class BombColors
    {
        private readonly Dictionary<Color, float> _currentColors = new Dictionary<Color, float>();

        public event EventHandler OnEmpty;
        private bool _invokedEvent;
        
        [System.Serializable]
        private class BombInspector
        {
            public Color color;
            public float amount;

            public BombInspector(Color color, float amount)
            {
                this.color = color;
                this.amount = amount;
            }
        }

        [Header("Debug")]
        [SerializeField]
        private BombInspector[] _bombInspector;

        public BombColors(Dictionary<Color, float> colors)
        {
            this._bombInspector = new BombInspector[colors.Count];
            int index = 0;
            foreach (KeyValuePair<Color, float> pair in colors)
            {
                this._currentColors.Add(pair.Key, pair.Value);
                this._bombInspector[index] = new BombInspector(pair.Key, pair.Value);
                index++;
            }
        }

        
        public Color CurrentColorValue { get { return CMYKColor.CombineColors(this._currentColors.Select(x => x)); } }
        public float CurrentThrust { get { return this._currentColors.All(x => x.Value <= 0) ? 0f : 2f; } }

        public float GetAmount(Color color)
        {
            Assert.IsTrue(this._currentColors.ContainsKey(color));
            return this._currentColors[color];
        }

        public void Increase(Color color, float amount)
        {
            Assert.IsTrue(this._currentColors.ContainsKey(color));
            this._currentColors[color] += amount;
            this._bombInspector.First(x => x.color == color).amount = this._currentColors[color];
            if (amount > 0)
                this._invokedEvent = false;
        }

        public void Decrease(Color color, float amount)
        {
            Assert.IsTrue(this._currentColors.ContainsKey(color));
            this._currentColors[color] = Mathf.Max(0, this._currentColors[color] - amount);
            this._bombInspector.First(x => x.color == color).amount = this._currentColors[color];
            if (this._invokedEvent || !this._bombInspector.All(x => x.amount <= 0))
                return;
            this._invokedEvent = true;
            this.OnEmpty?.Invoke(this, null);
        }

        public void DecreaseAll(float amount)
        {
            List<Color> keys = this._currentColors.Keys.ToList();
            foreach (var key in keys)
            {
                this.Decrease(key, amount);
            }
        }
    }
}