using Project.Core.Misc;
using Project.Editor.Gameplay;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class FinalTransition : MonoBehaviour
    {
        [SerializeField] private int _goodSceneBuildIndex;
        [SerializeField] private int _badSceneBuildIndex;
        
        [Inject] private CollectablesModel _collectables;
        [Inject] private SceneLoader _sceneLoader;

        public void StartTransition()
        {
            if (_collectables.AllCollected())
                _sceneLoader.Load(_goodSceneBuildIndex);
            else
                _sceneLoader.Load(_badSceneBuildIndex);
        }
    }
}