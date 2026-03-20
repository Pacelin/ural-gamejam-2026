using Plugins.Audio;
using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class SortingPuzzleController : MonoBehaviour
    {
        public enum EBehaviour
        {
            DisableOneWhenCorrectOne,
            DisableAllWhenComplete
        }

        [SerializeField] private EBehaviour _behaviour;
        [SerializeField] private SortingPuzzleItemInteractableObject[] _interactables;
        [SerializeField] private PuzzleTrigger _trigger;

        private void OnEnable()
        {
            foreach (var interactable in _interactables)
                interactable.OnChanged += OnInteractableChanged;
        }

        private void OnDisable()
        {
            foreach (var interactable in _interactables)
                if (interactable)
                    interactable.OnChanged -= OnInteractableChanged;
        }

        private void OnInteractableChanged(SortingPuzzleItemInteractableObject interactable)
        {
            if (_behaviour == EBehaviour.DisableOneWhenCorrectOne &&
                interactable.IsComplete)
            {
                interactable.OnChanged -= OnInteractableChanged;
                Destroy(interactable.gameObject);
            }
            CheckComplete();
        }

        private void CheckComplete()
        {
            bool complete = true;
            foreach (var interactable in _interactables)
            {
                if (!interactable.IsComplete)
                {
                    complete = false;
                    break;
                }
            }

            if (complete)
            {
                AudioSystem.Game_Misc_PuzzleComplete.PlayOneShot();
                if (_trigger)
                    _trigger.OnComplete();
                if (_behaviour == EBehaviour.DisableAllWhenComplete)
                {
                    foreach (var interactable in _interactables)
                    {
                        interactable.OnChanged -= OnInteractableChanged;
                        Destroy(interactable.gameObject);
                    }
                }
            }
        }
    }
}