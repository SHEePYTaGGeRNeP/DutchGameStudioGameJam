using System;
using Obstacles;
using UnityEngine;

namespace DefaultNamespace
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField]
        private UnityEngine.UI.Text _text;

        private int _score = 0;

        private void Awake()
        {
            WallMono.OnBlockDestroyed += this.WallMonoOnOnBlockDestroyed;
        }

        private void WallMonoOnOnBlockDestroyed(object sender, EventArgs eventArgs)
        {
            this._score++;
            this._text.text = "Score: " + this._score;
        }

        private void OnDestroy()
        {
            WallMono.OnBlockDestroyed -= this.WallMonoOnOnBlockDestroyed;
        }
    }
}