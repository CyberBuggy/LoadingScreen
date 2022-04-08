using UnityEngine;

namespace CyberBuggy.LoadingScreen
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private SceneReference _sceneReference;

        private void Start()
        {
            Debug.Log(_sceneReference.ScenePath);
        }
    }
}
