using Tymski;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CyberBuggy.LoadingScreen
{
    public class LoadingManagerCaller : MonoBehaviour
    {
        [SerializeField] private SceneLoader _loadingManagerSceneLoader;
        [SerializeField] private bool _callOnAwake;

        private void Awake()
        {
            if(!_callOnAwake)
                return;
            CheckIfLoadingManagerExists();
        }

        public void CheckIfLoadingManagerExists()
        {
            var loadingManager = LoadingManager.Instance;

            if(loadingManager == null)
                _loadingManagerSceneLoader.Load();
        }
    }
}
