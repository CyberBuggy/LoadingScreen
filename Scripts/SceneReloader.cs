using System.Collections.Generic;
using UnityEngine;

namespace CyberBuggy.LoadingScreen
{
    public class SceneReloader : MonoBehaviour
    {
        private LoadingManager _loadingManager;
        [SerializeField] private bool _invokeLoadingScreen = true;

        private void Start() => _loadingManager = LoadingManager.Instance;
        public void Reload()
        {
            var sceneList = new List<string>();
            sceneList.Add(gameObject.scene.path);

            var sceneReferenceList = LoadingSceneData.ConvertScenePathsIntoReferences(sceneList);

            var sceneData = new LoadingSceneData(sceneReferenceList, _invokeLoadingScreen);
            _loadingManager.InitiateReload(sceneData);
        }
    }
}
