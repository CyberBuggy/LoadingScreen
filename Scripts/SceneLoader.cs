using System.Collections.Generic;
using Tymski;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CyberBuggy.LoadingScreen
{
    public class SceneLoader : MonoBehaviour
    {
        private LoadingManager _loadingManager;
        
        [SerializeField] private LoadingSceneData _scenesToLoad;
        public LoadingSceneData ScenesToLoad { get => _scenesToLoad; set => _scenesToLoad = value; }
        [SerializeField] private bool _loadOnStart;
        [SerializeField] private bool _unloadCurrentScene;

        private void Start()
        {
            _loadingManager = LoadingManager.Instance;

            if(_loadOnStart)
                Load();
        }
        public void Load()
        {
            if(_unloadCurrentScene)
            {
                var sceneList = new List<string>();
                sceneList.Add(gameObject.scene.path);
                
                var sceneReferenceList = LoadingSceneData.ConvertScenePathsIntoReferences(sceneList);

                var sceneData = new LoadingSceneData(sceneReferenceList, false);
                _loadingManager.InitiateUnload(sceneData);
            }
            if(_loadingManager != null)
                _loadingManager.InitiateLoad(_scenesToLoad);
            else
                foreach (var scene in _scenesToLoad.scenes) SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive); 
        }
    }
}
