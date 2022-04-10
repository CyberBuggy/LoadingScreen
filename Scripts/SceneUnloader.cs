using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CyberBuggy.LoadingScreen
{
    public class SceneUnloader : MonoBehaviour
    {
        private LoadingManager _loadingManager;
        
        [SerializeField] private LoadingSceneData _scenesToUnload;
        public LoadingSceneData ScenesToLoad { get => _scenesToUnload; set => _scenesToUnload = value; }

        private void Start() => _loadingManager = LoadingManager.Instance;
        public void Unload()
        {
            if(_loadingManager != null)
                _loadingManager.InitiateUnload(_scenesToUnload);
            else
                foreach (var scene in _scenesToUnload.scenes) SceneManager.UnloadSceneAsync(scene); 
        }
    }
}
