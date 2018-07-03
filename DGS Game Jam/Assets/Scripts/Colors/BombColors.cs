using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Colors
{
    [SerializeField]
    public class BombColors
    {
        private readonly Dictionary<Color, float> _currentColors = new Dictionary<Color, float>();


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
    }
}