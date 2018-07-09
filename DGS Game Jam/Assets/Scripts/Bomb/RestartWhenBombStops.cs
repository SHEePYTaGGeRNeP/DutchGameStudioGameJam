using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartWhenBombStops : MonoBehaviour
    {
        [SerializeField]
        private Bomb _bomb;

        [SerializeField]
        private float _stopTime = 2f;
        
        private Vector3 _lastPosition;
        private bool _counting;

        private float _startCountingTime;

        
        private void Update()
        {
            Vector3 currentPos = this._bomb.transform.position;

            if (currentPos == this._lastPosition && !this._counting)
            {
                this._counting = true;
                this._startCountingTime = Time.time;
            }
            else if (this._counting)
            {
                if (currentPos != this._lastPosition)
                    this._counting = false;
                else if (Time.time - this._startCountingTime >= this._stopTime)
                {
                    this.enabled = false;
                    LogHelper.Log(typeof(RestartWhenBombStops), "Reloading scene");
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

            this._lastPosition = currentPos;
        }
    }