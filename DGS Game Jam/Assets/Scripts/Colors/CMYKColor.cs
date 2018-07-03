using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.WSA;

namespace Colors
{
    [System.Serializable]
    public class CMYKColor : IEquatable<CMYKColor>
    {
        public float c;
        public float m;
        public float y;
        public float k;

        public CMYKColor(Color rgbColor)
        {
            this.k = 1f - Mathf.Max(rgbColor.r, rgbColor.g, rgbColor.b);
            this.c = (1f - rgbColor.r - this.k) / (1f - this.k);
            this.m = (1f - rgbColor.g - this.k) / (1f - this.k);
            this.y = (1f - rgbColor.b - this.k) / (1f - this.k);            
        }

        public CMYKColor(float c, float m, float y, float k)
        {
            this.c = c;
            this.m = m;
            this.y = y;
            this.k = k;
        }

        public static Color CombineColors(IEnumerable<KeyValuePair<Color, float>> aColors)
        {
            Color result = new Color(0,0,0,0);
            KeyValuePair<Color, float>[] notEmpty = aColors.Where(x => x.Value > 0).ToArray();
            foreach(KeyValuePair<Color, float> col in notEmpty)
            {
                result += (col.Key * col.Value);
            }
            result /= notEmpty.Length;
            float max = GetHighestColorValue(result);
            float scale = 1 / max;
            result.r *= scale;
            result.g *= scale;
            result.b *= scale;
            return result;
        }

        private static float GetHighestColorValue(Color color)
        {
            float max = color.r;
            max = Mathf.Max(max, color.g);
            max = Mathf.Max(max, color.b);
            return max;
        }

        public Color ToUnityColor()
        {
            return new Color((1f - this.c) * (1f - this.k), (1f - this.m) * (1 - this.k),
                (1f - this.y) * (1f - this.k));
        }

        public float ToForce()
        {
            Color color = this.ToUnityColor();
            return ToForce(color);
        }

        public static float ToForce(Color color)
        {
            return color.r + color.g + color.b;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", this.c, this.m, this.y, this.k);
        }

        #region Equal Overrides

        public static bool operator ==(CMYKColor cc1, CMYKColor cc2)
        {
            if (ReferenceEquals(cc1, null))
                return ReferenceEquals(cc2, null);

            return cc1.Equals(cc2);
        }

        public static bool operator !=(CMYKColor cc1, CMYKColor cc2)
        {
            return !(cc1 == cc2);
        }

        public bool Equals(CMYKColor other)
        {
            if (other == null)
                return false;
            return this.c.AboutEqualTo(other.c) && this.m.AboutEqualTo(other.m)
                   && this.y.AboutEqualTo(other.y) && this.k.AboutEqualTo(other.k);
        }

        public override bool Equals(object obj)
        {           
            if (!(obj is CMYKColor))
                return false;
            CMYKColor other = (CMYKColor) obj;
            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            return (int) (this.c + this.m + this.y + this.k);
        }

        #endregion
    }
}