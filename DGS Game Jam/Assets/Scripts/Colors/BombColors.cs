using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Colors
{
    public class BombColors
    {
        private readonly Dictionary<Color, float> _currentColors = new Dictionary<Color, float>();

        public BombColors(Dictionary<Color, float> colors)
        {
            foreach (KeyValuePair<Color, float> pair in colors)
            {
                this._currentColors.Add(pair.Key, pair.Value);
            }
        }


        public Color CurrentColorValue { get { return CMYKColor.CombineColors(this._currentColors.Select(x => x)); } }
        public float CurrentThrust { get { return CMYKColor.ToForce(this.CurrentColorValue); } }

        public void Increase(Color color, float amount)
        {
            Assert.IsTrue(this._currentColors.ContainsKey(color));
            this._currentColors[color] += amount;
        }

        public void Decrease(Color color, float amount)
        {
            Assert.IsTrue(this._currentColors.ContainsKey(color));
            this._currentColors[color] -= Mathf.Max(0,amount);
        }

        public void DecreaseAll(float amount)
        {
            List<Color> keys = _currentColors.Keys.ToList();
            foreach(var key in keys)
            {
                Decrease(key, amount);
            }
        }
    }
}