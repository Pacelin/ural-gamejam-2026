using Project.Editor.Gameplay;
using UnityEngine;
using UnityEngine.Playables;
using VContainer;

namespace Project.Gameplay.Basement
{
    public class FinalCutScenePlayer : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _goodDirector;
        [SerializeField] private PlayableDirector _badDirector;

        [Inject]
        private void Construct(CollectablesModel collectablesModel)
        {
            if (collectablesModel.AllCollected())
                _goodDirector.Play();
            else
                _badDirector.Play();
        }
    }
}