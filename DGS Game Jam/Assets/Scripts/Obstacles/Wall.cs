using System;
using UnityEngine;

namespace Obstacles
{
    [System.Serializable]
    public class Wall
    {
        public Color wallColor;
        public float wallTolerance = DEFAULT_WALL_TOLERANCE;
        public const float DEFAULT_WALL_TOLERANCE = 0.1f;

        public Wall(Color wallColor, float wallTolerance = DEFAULT_WALL_TOLERANCE)
        {
            this.wallColor = wallColor;
            this.wallTolerance = wallTolerance;
        }

        public bool IsDestroyedByColor(Color color)
        {
            Color remainder = this.wallColor - color;
            LogHelper.Log(typeof(Wall), String.Format("{0} - {1} = {2}", this.wallColor , color, remainder));
            return remainder.RGBSum() <= this.wallTolerance;
        }
    }
}