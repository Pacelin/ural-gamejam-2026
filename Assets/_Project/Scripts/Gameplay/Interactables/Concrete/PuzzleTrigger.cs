using UnityEngine;

namespace Project.Gameplay.Interactables
{
    public class PuzzleTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject[] _activateObjects;
        [SerializeField] private GameObject[] _destroyObjects;
        [SerializeField] private LockedPuzzleObject[] _unlockObjects;

        private void Awake()
        {
            foreach (var activateObject in _activateObjects)
                activateObject.gameObject.SetActive(false);
        }

        public void OnComplete()
        {
            foreach (var activateObject in _activateObjects)
                if (activateObject)
                    activateObject.gameObject.SetActive(true);
            foreach (var unlockObject in _unlockObjects) 
                if (unlockObject)
                    unlockObject.Unlock();
            foreach (var destroyObject in _destroyObjects)
                if (destroyObject)
                    Destroy(destroyObject);
        }
    }
}
