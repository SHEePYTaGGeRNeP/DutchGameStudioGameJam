using System;
using Obstacles;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField]
        private UnityEngine.UI.Text _text;

        private int score = 0;

        private void Awake()
        {
            WallMono.OnBlockDestroyed += (sender, args) =>
            {
                this.score++;
                this._text.text = "Score: " + this.score;
            };
        }
    }
}