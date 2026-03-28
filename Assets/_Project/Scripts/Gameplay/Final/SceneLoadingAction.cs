using Project.Core.Misc;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class SceneLoadingAction : MonoBehaviour
    {
        [SerializeField] private int _sceneBuildIndex;

        [Inject] private SceneLoader _sceneLoader;

        public void Load()
        {
            _sceneLoader.Load(_sceneBuildIndex);
        }
    }
}