using UnityEngine;

namespace Obstacles
{
    [System.Serializable]
    public class Wall
    {
        public Color wallColor;
        public float wallTolerance;
        public const float DEFAULT_WALL_TOLERANCE = 0.1f;

        public Wall(Color wallColor, float wallTolerance = DEFAULT_WALL_TOLERANCE)
        {
            this.wallColor = wallColor;
            this.wallTolerance = wallTolerance;
        }

        public bool IsDestroyedByColor(Color color)
        {
            return (this.wallColor - color).RGBSum() <= this.wallTolerance;
        }
    }
}