using System;
using System.Collections;
using System.Collections.Generic;
using Tymski;

namespace CyberBuggy.LoadingScreen
{
    [Serializable]
    public class LoadingSceneData : IEnumerable
    {
        public List<SceneReference> scenes;
        public bool invokeLoadingScreen; 

        public LoadingSceneData(List<SceneReference> scenes, bool invokeLoadingScreen)
        {
            this.scenes = scenes;
            this.invokeLoadingScreen = invokeLoadingScreen;
        }

        public static List<SceneReference> ConvertScenePathsIntoReferences(List<string> scenePaths)
        {
            var sceneReferenceList = new List<SceneReference>();
            foreach (var scenePath in scenePaths)
            {
                var sceneReference = new SceneReference();
                sceneReference.ScenePath = scenePath;
                sceneReferenceList.Add(sceneReference);
            }
            return sceneReferenceList;
        }

        public IEnumerator GetEnumerator()
        {
            var sceneList = new List<string>();

            foreach (var scene in scenes)
            {
                sceneList.Add(scene.ScenePath);
            }
            return sceneList.GetEnumerator();
        }

        
    }
}

