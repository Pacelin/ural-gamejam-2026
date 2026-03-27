using Project.Editor.Gameplay;
using UnityEngine;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class FinalCollectables : MonoBehaviour
    {
        [SerializeField] private GameObject[] _gameObjects;
        
        [Inject]
        private void Construct(CollectablesModel collectables)
        {
            for (int i = 0; i < collectables.Current; i++)
                _gameObjects[i].SetActive(true);
            for (int i = collectables.Current; i < _gameObjects.Length; i++)
                _gameObjects[i].SetActive(false);
        }
    }
}