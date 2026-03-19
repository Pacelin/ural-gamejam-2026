using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class ActivateTrigger : PuzzleTrigger
    {
        [SerializeField] private GameObject[] _activateObjects;

        private void Awake()
        {
            foreach (var activateObject in _activateObjects)
                activateObject.gameObject.SetActive(false);
        }

        public override void OnComplete()
        {
            foreach (var activateObject in _activateObjects)
                activateObject.gameObject.SetActive(true);
        }
    }
}