using UnityEngine;

namespace Obstacles
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class WallMono : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        [SerializeField]
        private Wall _wall;

        private void Awake()
        {
            this._spriteRenderer = this.GetComponent<SpriteRenderer>();
            this.UpdateColor(this._wall.wallColor);
        }

        public void UpdateColor(Color c)
        {
            this._wall.wallColor = c;
            this._spriteRenderer.color = c;

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Bomb b = other.gameObject.GetComponent<Bomb>();
            if (b == null)
                return;
            if (!this._wall.IsDestroyedByColor(b.CurrentColor))
                return;
            Destroy(this.gameObject);
        }
                
    }
}