using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Scene
{
    public class LoadSceneEvent : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            Application.LoadLevel(sceneName);
        }

        public void ReloadScene()
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
