using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ReloadButton : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}