using System;
using DefaultNamespace;
using UnityEngine;

namespace Obstacles
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class WallMono : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        public static event EventHandler OnBlockDestroyed;
            
        [SerializeField]
        private Wall _wall;

        private void Awake()
        {
            this._spriteRenderer = this.GetComponent<SpriteRenderer>();
            this.UpdateColor(this._spriteRenderer.color);
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
            OnBlockDestroyed?.Invoke(this, null);
            Destroy(this.gameObject);
        }
                
    }
}