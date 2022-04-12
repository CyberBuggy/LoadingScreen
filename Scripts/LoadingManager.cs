using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;

namespace CyberBuggy.LoadingScreen
{
        
    public class LoadingManager : MonoBehaviour
    {
        private static LoadingManager _instance;
        public static LoadingManager Instance { get => _instance; private set => _instance = value; }
        private List<AsyncOperation> _loadingOperations = new List<AsyncOperation>();
        private Coroutine _loadingCoroutine;
        [SerializeField] private bool _callMainSceneAtAwake = true;
        [SerializeField] private LoadingSceneData _mainScenes;
        public UnityEvent LoadingScreenInitiated;
        public UnityEvent LoadingScreenFinished;

        private void Awake()
        {
            Instance = this;

            if(_callMainSceneAtAwake)
                InitiateLoad(_mainScenes);

        }
        public void InitiateLoad(LoadingSceneData scenes)
        {
            _loadingOperations = new List<AsyncOperation>();

            if(scenes.invokeLoadingScreen)
                LoadingScreenInitiated?.Invoke();

            foreach (var scene in scenes) _loadingOperations.Add(Load((string)scene));

            _loadingCoroutine = StartCoroutine(Co_GetSceneLoadingProgress(scenes.invokeLoadingScreen));
        }
        public void InitiateReload(LoadingSceneData scenes)
        {
            _loadingOperations = new List<AsyncOperation>();

            if(scenes.invokeLoadingScreen)
                LoadingScreenInitiated?.Invoke();

            foreach (var scene in scenes)
            {
                _loadingOperations.Add(Unload((string)scene));
                _loadingOperations.Add(Load((string)scene));
            } 
            _loadingCoroutine = StartCoroutine(Co_GetSceneLoadingProgress(scenes.invokeLoadingScreen));
        }
        public void InitiateUnload(LoadingSceneData scenes)
        {
            _loadingOperations = new List<AsyncOperation>();

            if(scenes.invokeLoadingScreen)
                LoadingScreenInitiated?.Invoke();

            foreach (var scene in scenes) _loadingOperations.Add(Unload((string)scene));

            _loadingCoroutine = StartCoroutine(Co_GetSceneLoadingProgress(scenes.invokeLoadingScreen));
        }
        private AsyncOperation Load(string scene)
        {
            return SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }
        private AsyncOperation Unload(string scene)
        {
            return SceneManager.UnloadSceneAsync(scene);
        }

        private IEnumerator Co_GetSceneLoadingProgress(bool invokeLoadingScreen)
        {
            foreach (var loadingScene in _loadingOperations)
            {
                while (!loadingScene.isDone) yield return null;
            }

            if(invokeLoadingScreen)
                LoadingScreenFinished?.Invoke();
        }
    }

}
